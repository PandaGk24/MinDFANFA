using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFA
{
    static class Parts
    {
        public static string[] alphabet;
        public static int[,] condition;
        public static bool[] finished;

        public static int[,] table;

        public static List<int> finiteState = new List<int>();
        public static List<int> nonfiniteState = new List<int>();


        public static List<Two> Twos = new List<Two>();

        public static Two[,] seekState;

        public static int[,] mintable;
        public static bool[] finishedPartsMin;

        // FOR NFA->DFA CONVERSION
        public static List<List<int>> nfaStates = new List<List<int>>();
        public static List<int> startList = new List<int>();
        public static List<bool> finish = new List<bool>();

        public static List<List<int>> toDfaTable = new List<List<int>>();

        public static List<int> resultDFA = new List<int>();

        public static List<bool> resultfinishDFA = new List<bool>();
    }
}

class Two
{
    public int FirstIndex { get; set; }
    public int SecondIndex { get; set; }

    public Two(int first, int second)
    {
        FirstIndex = first;
        SecondIndex = second;
    }
}
