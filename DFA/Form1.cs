using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFile(ref string name)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                name = openfile.FileName;
            }
        }

        private void ReadFile(string name)
        {
            int counter = 0;
            StreamReader reader = File.OpenText(name);
            StreamReader reader2 = File.OpenText(name);
            string str = "";

            while ((str = reader.ReadLine()) != null)
            {
                counter++;
            }

            Parts.condition = new int[counter, Parts.alphabet.Length];
            Parts.finished = new bool[counter];

            counter = 0;

            while ((str = reader2.ReadLine()) != null)
            {
                string[] split = str.Split(' ');

                for (int i = 0; i < Parts.alphabet.Length; i++)
                {
                    Parts.condition[counter, i] = Convert.ToInt32(split[i]);
                }

                if (split[Parts.alphabet.Length].Equals("f"))
                {
                    Parts.finished[counter] = false;
                }
                else
                {
                    Parts.finished[counter] = true;
                }
                counter++;
            }
        }

        public int StatesCounter()
        {
            int max = -99;
            for (int i = 0; i < Parts.condition.GetLength(0); i++)
            {
                for (int j = 0; j < Parts.condition.GetLength(1); j++)
                {
                    if (max < Parts.condition[i, j])
                    {
                        max = Parts.condition[i, j] + 1;
                    }
                }
            }
            return max + 1;
        }

        public void ReadFileForNFA(string nameread)
        {
            StreamReader reader = File.OpenText(nameread);
            string str = "";
            int count = 0;

            List<int> l = new List<int>();

            while ((str = reader.ReadLine()) != null)
            {
                if (count == 0) //считываем сначала 1 строку файла
                {
                    string[] fsplit = str.Split(',');

                    for (int i = 0; i < fsplit.Length; i++)
                    {
                        Parts.startList.Add(Convert.ToInt32(fsplit[i]));
                    }
                }
                else
                {

                    string[] split = str.Split(' ');

                    for (int i = 0; i < split.Length - 1; i++)
                    {
                        List<int> list = new List<int>();
                        string[] stringSplit = split[i].Split(',');

                        for (int j = 0; j < stringSplit.Length; j++)
                        {
                            list.Add(Convert.ToInt32(stringSplit[j]));
                        }

                        Parts.nfaStates.Add(list);
                    }


                    if (split[Parts.alphabet.Length].Equals("f"))
                    {
                        Parts.finish.Add(false);
                    }
                    else
                    {
                        Parts.finish.Add(true);
                    }
                }
                count++;
            }

        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                string str = InputBox.Text;
                if (str.Length == 0)
                {
                    MessageBox.Show("Wrong alphabet input!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (str.Length > 1)
                {
                    for (int i = 1; i < str.Length; i = i + 2)
                    {
                        if (!str[i].Equals(';'))
                        {
                            MessageBox.Show("Wrong alphabet input!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                Parts.alphabet = str.Split(';');
                FileLoad.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Wrong alphabet reading!", "Check ur alphabet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FileLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string file = "";
                OpenFile(ref file);
                ReadFile(file);
            }
            catch
            {
                MessageBox.Show("File reading violation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            for (int i = 0; i < Parts.alphabet.Length; i++)
            {
                if (i == Parts.alphabet.Length - 1)
                {
                    AlphabetShow.Text += Parts.alphabet[i];
                }
                else AlphabetShow.Text += Parts.alphabet[i] + ";";
            }
        }


        public void AppendTable()
        {
            int max = StatesCounter();
            Parts.table = new int[max, max];

            for (int i = 0; i < max; i++) // заполняем всё -1
            {
                for (int j = 0; j < max; j++)
                {
                    Parts.table[i, j] = -1;
                }
            }

            for (int i = 0; i < max; i++) // заполняем -99 ниже главной диагонали
            {
                for (int j = 0; j < max; j++)
                {
                    if (i > j)
                    {
                        Parts.table[i, j] = -99;
                    }
                }
            }

            for (int i = 0; i < max; i++)  //заполняем 0лями главную диагональ
            {
                Parts.table[i, i] = 2;
            }

            for (int i = 0; i < Parts.finished.Length; i++)  //узнаем конечные и не конечные состояния и кидаем их в список
            {
                if (Parts.finished[i] == true)
                {
                    Parts.finiteState.Add(i);
                }
                else
                {
                    Parts.nonfiniteState.Add(i);
                }
            }

            for (int i = 0; i < Parts.finiteState.Count; i++) //доб в пары где сначала фигальные сост и заносим в таблицу
            {
                for (int j = 0; j < Parts.nonfiniteState.Count; j++)
                {
                    if (Parts.finiteState[i] < Parts.nonfiniteState[j])
                    {
                        Parts.table[Parts.finiteState[i], Parts.nonfiniteState[j]] = 1;
                    }
                }
            }

            for (int k = 0; k < Parts.nonfiniteState.Count; k++)  // доб в пары где сначала нефинальные сост и заносим в таблицу
            {
                for (int f = 0; f < Parts.finiteState.Count; f++)
                {
                    if (Parts.nonfiniteState[k] < Parts.finiteState[f])
                    {
                        Parts.table[Parts.nonfiniteState[k], Parts.finiteState[f]] = 1;
                    }
                }
            }

            for (int i = 0; i < max; i++)  // добавляем в пары пустые места в таблице
            {
                for (int j = 0; j < max; j++)
                {
                    if (Parts.table[i, j] == -1)
                    {
                        Parts.Twos.Add(new Two(i, j));
                    }
                }
            }

            Parts.seekState = new Two[Parts.Twos.Count, Parts.alphabet.Length + 1];

            for (int i = 0; i < Parts.Twos.Count; i++)  // ищем переходы по буквам и загружаем в массив seekState
            {
                int first = Parts.Twos[i].FirstIndex;
                int second = Parts.Twos[i].SecondIndex;

                int first1 = Parts.condition[first, 0];
                int second1 = Parts.condition[second, 0];

                int first2 = Parts.condition[first, 1];
                int second2 = Parts.condition[second, 1];

                Parts.seekState[i, 0] = new Two(first, second);

                if (first1 < second1)
                {
                    Parts.seekState[i, 1] = new Two(first1, second1);
                }
                else
                {
                    Parts.seekState[i, 1] = new Two(second1, first1);
                }



                if (first2 < second2)
                {
                    Parts.seekState[i, 2] = new Two(first2, second2);
                }
                else
                {
                    Parts.seekState[i, 2] = new Two(second2, first2);
                }
            }

            int flag = 0;
            while (flag < 8)
            {
                for (int i = 0; i < Parts.Twos.Count; i++) // Переводим состояния в обозначения и заносим таблицу
                {
                    int one = Parts.seekState[i, 1].FirstIndex;
                    int two = Parts.seekState[i, 1].SecondIndex;

                    int three = Parts.seekState[i, 2].FirstIndex;
                    int four = Parts.seekState[i, 2].SecondIndex;


                    int sign1 = Parts.table[one, two];
                    int sign2 = Parts.table[three, four];

                    if (sign1 == 1 || sign2 == 1)
                    {
                        Parts.table[Parts.seekState[i, 0].FirstIndex, Parts.seekState[i, 0].SecondIndex] = 1;
                    }
                    if (sign1 == 0 || sign2 == 0)
                    {
                        Parts.table[Parts.seekState[i, 0].FirstIndex, Parts.seekState[i, 0].SecondIndex] = 2;
                    }
                }
                flag++;
            }

            for (int i = 0; i < Parts.table.GetLength(0); i++) // если остались пустые клетки в таблице
            {
                for (int j = 0; j < Parts.table.GetLength(1); j++)
                {
                    if (Parts.table[i, j] == -1)
                    {
                        Parts.table[i, j] = 2;
                    }
                }
            }
        }

        public void CreateMin()
        {
            List<List<int>> pairs = new List<List<int>>();
            int i = 0;

            while (i < Parts.table.GetLength(0)) // проходим по строкам, while чтобы можно было перескочить строку, если такое состояние уже было в списке
            {
                List<int> list = new List<int>();
                for (int j = 0; j < Parts.table.GetLength(1); j++) //по столбцам
                {
                    if (Parts.table[i, j] == 2)
                    {
                        if (!list.Contains(i))
                        {
                            list.Add(i);
                        }
                        if (!list.Contains(j))
                        {
                            list.Add(j);
                        }

                        for (int k = 0; k < Parts.table.GetLength(1); k++)
                        {
                            if (Parts.table[k, j] == 2)
                            {
                                if (!list.Contains(k))
                                {
                                    list.Add(k);
                                }
                                if (!list.Contains(j))
                                {
                                    list.Add(j);
                                }
                            }
                        }
                    }
                }
                pairs.Add(list);
                i++;


                List<int> buff = new List<int>(); // созд лист куда поместим все состояния которые уже есть в листах
                for (int x = 0; x < pairs.Count; x++)
                {
                    for (int y = 0; y < pairs[x].Count; y++)
                    {
                        buff.Add(pairs[x][y]);
                    }
                }

                bool flag = true;

                while (flag)
                {
                    if (buff.Contains(i))
                    {
                        i++;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }

            List<int> shifr = new List<int>();

            for (int a = 0; a < pairs.Count; a++) //добавляем в конец шифрование для каждого состояния
            {
                shifr.Add(a);
            }
            pairs.Add(shifr);


            Parts.finishedPartsMin = new bool[pairs.Count - 1];

            for (int x = 0; x < pairs.Count - 1; x++)
            {
                int e = pairs[x][0];
                Parts.finishedPartsMin[x] = Parts.finished[e];
            }

            //составляем финальную табличку с минимальным колличеством переходов

            Parts.mintable = new int[pairs.Count - 1, Parts.alphabet.Length];

            for (int c = 0; c < pairs.Count - 1; c++) //идем по всем листам
            {
                for (int j = 0; j < pairs[c].Count; j++) //по всем элементам листа
                {
                    int k = pairs[c][j];

                    int a = Parts.condition[k, 0];
                    int b = Parts.condition[k, 1];


                    for (int q = 0; q < pairs.Count - 1; q++)
                    {
                        for (int x = 0; x < pairs[q].Count; x++)
                        {
                            if (pairs[q][x] == a)
                            {
                                Parts.mintable[c, 0] = pairs[pairs.Count - 1][q];
                            }
                            if (pairs[q][x] == b)
                            {
                                Parts.mintable[c, 1] = pairs[pairs.Count - 1][q];
                            }
                        }
                    }
                }
            }
        }

        public void InsertMinInFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("C:\\Users\\User\\Desktop\\Min\\MinAvtomat.txt", false, System.Text.Encoding.Default))
                {
                    for (int i = 0; i < Parts.mintable.GetLength(0); i++)
                    {
                        string str = "";
                        if (Parts.finishedPartsMin[i])
                        {
                            str = "t";
                        }
                        if (!Parts.finishedPartsMin[i])
                        {
                            str = "f";
                        }
                        sw.WriteLine(Parts.mintable[i, 0] + " " + Parts.mintable[i, 1] + " " + str);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Determinization()
        {
            bool flag = true;

            Parts.toDfaTable.Add(Parts.startList);

            int k = 0;

            int z = 1;

            List<List<int>> ostatok = new List<List<int>>();

            while (flag)
            {
                for (int s = 0; s < Parts.alphabet.Length; s++)
                {
                    List<int> list = new List<int>();
                    for (int i = 0; i < Parts.toDfaTable[k].Count; i++)
                    {
                        int x = Parts.toDfaTable[k][i];
                        for (int j = 0; j < Parts.nfaStates[Parts.alphabet.Length * x + s].Count; j++)
                        {
                            if (!list.Contains(Parts.nfaStates[Parts.alphabet.Length * x + s][j]) && Parts.nfaStates[Parts.alphabet.Length * x + s][j] != -1)
                            {
                                list.Add(Parts.nfaStates[Parts.alphabet.Length * x + s][j]);
                            }
                        }
                    }

                    list.Sort();
                    Parts.toDfaTable.Add(list);
                }

                int count = 0;

                for (int s = 0; s < Parts.alphabet.Length; s++)
                {
                    for (int a = 0; a < Parts.toDfaTable.Count; a = a + Parts.alphabet.Length + 1) // проверка на совпадение списков состояний
                    {
                        if (Parts.toDfaTable[a].Count == Parts.toDfaTable[k + 1 + s].Count)
                        {
                            for (int p = 0; p < Parts.toDfaTable[a].Count; p++)
                            {
                                if (Parts.toDfaTable[a][p] == Parts.toDfaTable[k + 1 + s][p])
                                {

                                }
                            }
                        }

                        else
                        {
                            count++;
                        }
                    }

                    if (count == z)
                    {
                        ostatok.Add(Parts.toDfaTable[k + 1 + s]);
                        count = 0;
                    }
                }
                if (ostatok.Count == 0)
                {
                    flag = false;
                }

                else
                {
                    Parts.toDfaTable.Add(ostatok[0]);
                    ostatok.RemoveAt(0);
                    k = k + Parts.alphabet.Length + 1;
                    z++;
                }
            }


        }

        public void Encrypt()
        {
            int count = 0;

            int b = 0;

            for (int i = 0; i < Parts.toDfaTable.Count; i++)
            {
                Parts.resultDFA.Add(i);
            }

            for (int j = 0; j < Parts.toDfaTable.Count; j = j + Parts.alphabet.Length + 1, count++)
            {
                for (int k = 0; k < Parts.toDfaTable.Count; k++)
                {
                    if (Parts.toDfaTable[j].Count == Parts.toDfaTable[k].Count)
                    {
                        if (Parts.toDfaTable[j].All(Parts.toDfaTable[k].Contains))
                        {
                            Parts.resultDFA[k] = b;
                        }
                    }

                }
                b++;
            }
        }

        public void ResultStatesDFA()
        {
            int count = 0;

            for (int i = 0; i < Parts.toDfaTable.Count; i = i + Parts.alphabet.Length + 1)
            {
                for (int j = 0; j < Parts.toDfaTable[i].Count; j++)
                {
                    int k = Parts.toDfaTable[i][j];

                    if (Parts.finish[k] == false)
                    {
                        count++;
                    }
                }

                if (count == Parts.toDfaTable[i].Count)
                {
                    Parts.resultfinishDFA.Add(false);
                }
                else
                {
                    Parts.resultfinishDFA.Add(true);
                }
                count = 0;
            }
        }

        public void ConvenientRecord()// для удобной записи в файл
        {
            //List<int>shoudaliat = new List<int>();
            for (int h = 0; h < Parts.resultDFA.Count; h = h + Parts.alphabet.Length)
            {
                Parts.resultDFA.RemoveAt(h);
            }

        }

        public void WriteDFAInFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("C:\\Users\\User\\Desktop\\NFA\\DFA.txt", false, System.Text.Encoding.Default))
                {
                    if (Parts.alphabet.Length == 2)
                    {
                        for (int i = 0; i < Parts.resultfinishDFA.Count; i++)
                        {
                            string s = "";
                            if (Parts.resultfinishDFA[i])
                            {
                                s = "t";
                            }
                            if (!Parts.resultfinishDFA[i])
                            {
                                s = "f";
                            }
                            sw.WriteLine(Parts.resultDFA[2 * i] + " " + Parts.resultDFA[2 * i + 1] + " " + s);
                        }
                    }

                    if (Parts.alphabet.Length == 1)
                    {
                        for (int i = 0; i < Parts.resultfinishDFA.Count; i++)
                        {
                            string s = "";
                            if (Parts.resultfinishDFA[i])
                            {
                                s = "t";
                            }
                            if (!Parts.resultfinishDFA[i])
                            {
                                s = "f";
                            }
                            sw.WriteLine(Parts.resultDFA[2 * i] + " " + s);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        string str;
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            str = StringInput.Text;
            string alphabet = string.Join(null, Parts.alphabet);
            for (int i = 0; i < str.Length; i++)
            {
                if (!alphabet.Contains(str[i].ToString()))
                {
                    MessageBox.Show("These symbols aren't from the alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            PositionLabel.Text = "0";

            PositionCheck.Enabled = true;
            ApplyButton.Enabled = false;
            PositionString.Enabled = true;
        }

        int countLetter = 0;
        int currentState = 0;
        bool finished;

        private void PositionCheck_Click(object sender, EventArgs e)
        {
            if (str.Length == 0)
            {
                MessageBox.Show("Stopped at step " + currentState + Environment.NewLine + "This step isn't final -> automate doesn't accept this string", "Parts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PositionCheck.Enabled = false;
                ApplyButton.Enabled = true;
                return;
            }

            for (int i = 0; i < Parts.alphabet.Length; i++)
            {
                if (str[countLetter].ToString().Equals(Parts.alphabet[i]))
                {
                    currentState = Parts.condition[currentState, i];
                }
            }

            finished = Parts.finished[currentState];
            countLetter++;
            PositionCheck.Text = ("Check letter #" + (countLetter + 1)).ToString();

            PositionLabel.Text = currentState.ToString();
            if (finished)
            {
                PositionLabel.ForeColor = Color.Green;
            }
            else PositionLabel.ForeColor = Color.Black;
           
            if (str.Length == countLetter)
            {
                if (finished)
                {
                    MessageBox.Show("Stopped at step " + currentState + Environment.NewLine + "This step is final -> automate accepts this string", "Parts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    currentState = 0;
                    countLetter = 0;
                    PositionCheck.Text = ("Check letter #" + (countLetter + 1)).ToString();

                    PositionCheck.Enabled = false;
                    ApplyButton.Enabled = true;
                }
                if (!finished)
                {
                    MessageBox.Show("Stopped at step " + currentState + Environment.NewLine + "This step isn't final -> automate doesn't accept this string", "Parts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    currentState = 0;
                    countLetter = 0;
                    PositionCheck.Text = ("Check letter #" + (countLetter + 1)).ToString();
                    PositionLabel.ForeColor = Color.Black;

                    PositionCheck.Enabled = false;
                    ApplyButton.Enabled = true;
                }
            }
        }

        private void RefreshAll_Click(object sender, EventArgs e)
        {
            AlphabetShow.ResetText();
            StringInput.Clear();
            PositionLabel.ResetText();
            MinLabel.ResetText();
            MinInput.Clear();
            ApplyButton.Enabled = true;
        }

        private void PositionString_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < str.Length; j++)
            {
                if (str.Length == 0)
                {
                    MessageBox.Show("Stopped at step " + currentState + Environment.NewLine + "This step isn't final -> automate doesn't accept this string", "Parts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PositionCheck.Enabled = false;
                    ApplyButton.Enabled = true;
                    return;
                }


                for (int i = 0; i < Parts.alphabet.Length; i++)
                {
                    if (str[countLetter].ToString().Equals(Parts.alphabet[i]))
                    {
                        currentState = Parts.condition[currentState, i];
                    }
                }

                finished = Parts.finished[currentState];
                countLetter++;

                PositionLabel.Text = currentState.ToString();
                if (finished)
                {
                    PositionLabel.ForeColor = Color.Green;
                }
                else PositionLabel.ForeColor = Color.Black;

                if (str.Length == countLetter)
                {
                    if (finished)
                    {
                        MessageBox.Show("Stopped at step " + currentState + Environment.NewLine + "This step is final -> automate accepts this string", "Parts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        currentState = 0;
                        countLetter = 0;


                        PositionCheck.Enabled = false;
                        ApplyButton.Enabled = true;
                        PositionString.Enabled = false;

                    }
                    if (!finished)
                    {
                        MessageBox.Show("Stopped at step " + currentState + Environment.NewLine + "This step isn't final -> automate doesn't accept this string", "Parts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        currentState = 0;
                        countLetter = 0;

                        PositionLabel.ForeColor = Color.Black;

                        PositionCheck.Enabled = false;
                        ApplyButton.Enabled = true;
                        PositionString.Enabled = false;
                    }
                }
            }
        }

        private void ApplyMinButton_Click(object sender, EventArgs e)
        {
            string alphabet = string.Join(null, Parts.alphabet);
            str = MinInput.Text;

            for (int i = 0; i < str.Length; i++)
            {
                if (!alphabet.Contains(str[i].ToString()))
                {
                    MessageBox.Show("These symbols aren't from the alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MinLabel.Text = "0";

            PositionMinCheck.Enabled = true;
            ApplyMinButton.Enabled = false;
            PositionMinString.Enabled = true;
        }

        private void PositionMinCheck_Click(object sender, EventArgs e)
        {
            if (str.Length == 0)
            {
                MessageBox.Show("Stopped at step " + currentState + Environment.NewLine + "This step isn't final -> automate doesn't accept this string", "Parts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PositionMinCheck.Enabled = false;
                ApplyMinButton.Enabled = true;
                return;
            }


            for (int i = 0; i < Parts.alphabet.Length; i++)
            {
                if (str[countLetter].ToString().Equals(Parts.alphabet[i]))
                {
                    currentState = Parts.mintable[currentState, i];
                }
            }
            finished = Parts.finishedPartsMin[currentState];
            countLetter++;
            PositionMinCheck.Text = ("Check letter #" + (countLetter + 1)).ToString();

            MinLabel.Text = currentState.ToString();
            if (finished)
            {
                MinLabel.ForeColor = Color.Green;
            }
            else MinLabel.ForeColor = Color.Black;



            if (str.Length == countLetter)
            {
                if (finished)
                {
                    MessageBox.Show("Stopped at step " + currentState + Environment.NewLine + "This step is final -> automate accepts this string", "Parts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    currentState = 0;
                    countLetter = 0;
                    PositionMinCheck.Text = ("Check letter #" + (countLetter + 1)).ToString();

                    PositionMinCheck.Enabled = false;
                    ApplyMinButton.Enabled = true;
                    PositionMinString.Enabled = false;

                }
                if (!finished)
                {
                    MessageBox.Show("Stopped at step " + currentState + Environment.NewLine + "This step isn't final -> automate doesn't accept this string", "Parts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    currentState = 0;
                    countLetter = 0;
                    PositionMinCheck.Text = ("Check letter #" + (countLetter + 1)).ToString();

                    MinLabel.ForeColor = Color.Black;

                    PositionMinCheck.Enabled = false;
                    ApplyMinButton.Enabled = true;
                    PositionMinString.Enabled = false;
                }
            }
        }

        private void PositionMinString_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < str.Length; j++)
            {
                if (str.Length == 0)
                {
                    MessageBox.Show("Stopped at step " + currentState + Environment.NewLine + "This step isn't final -> automate doesn't accept this string", "Parts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PositionMinCheck.Enabled = false;
                    ApplyMinButton.Enabled = true;
                    return;
                }


                for (int i = 0; i < Parts.alphabet.Length; i++)
                {
                    if (str[countLetter].ToString().Equals(Parts.alphabet[i]))
                    {
                        currentState = Parts.mintable[currentState, i];
                    }
                }

                finished = Parts.finishedPartsMin[currentState];


                countLetter++;

                PositionMinCheck.Text = ("Check letter #" + (countLetter + 1)).ToString();



                MinLabel.Text = currentState.ToString();
                if (finished)
                {
                    MinLabel.ForeColor = Color.Green;
                }
                else MinLabel.ForeColor = Color.Black;



                if (str.Length == countLetter)
                {
                    if (finished)
                    {
                        MessageBox.Show("Stopped at step " + currentState + Environment.NewLine + "This step is final -> automate accepts this string", "Parts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        currentState = 0;
                        countLetter = 0;
                        PositionMinCheck.Text = ("Check letter #" + (countLetter + 1)).ToString();

                        PositionMinCheck.Enabled = false;
                        ApplyMinButton.Enabled = true;
                        PositionMinString.Enabled = false;

                    }
                    if (!finished)
                    {
                        MessageBox.Show("Stopped at step " + currentState + Environment.NewLine + "This step isn't final -> automate doesn't accept this string", "Parts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        currentState = 0;
                        countLetter = 0;
                        PositionMinCheck.Text = ("Check letter #" + (countLetter + 1)).ToString();

                        MinLabel.ForeColor = Color.Black;

                        PositionMinCheck.Enabled = false;
                        ApplyMinButton.Enabled = true;
                        PositionMinString.Enabled = false;
                    }
                }
            }
        }

        private void ConvertToDFA_Click(object sender, EventArgs e)
        {
            Determinization();
            Encrypt();
            ResultStatesDFA();
            ConvenientRecord();
            WriteDFAInFile();

            string path = "D:\\UNIVER\\Кузнецоффф\\MinDFANFASliunkov\\DFA.txt";
            ReadFile(path);
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            AppendTable();
            CreateMin();
            InsertMinInFile();
            ApplyMinButton.Enabled = true;
        }
    }
}
