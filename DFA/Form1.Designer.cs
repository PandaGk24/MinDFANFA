namespace DFA
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.AlphabetInputLabel = new System.Windows.Forms.Label();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.FileLoad = new System.Windows.Forms.Button();
            this.StringInput = new System.Windows.Forms.TextBox();
            this.StringInputLabel = new System.Windows.Forms.Label();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.PositionLabel = new System.Windows.Forms.Label();
            this.AlphabetLabel = new System.Windows.Forms.Label();
            this.AlphabetShow = new System.Windows.Forms.Label();
            this.PositionCheck = new System.Windows.Forms.Button();
            this.RefreshAll = new System.Windows.Forms.Button();
            this.PositionString = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.InputLabel2 = new System.Windows.Forms.Label();
            this.MinInput = new System.Windows.Forms.TextBox();
            this.ApplyMinButton = new System.Windows.Forms.Button();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.PositionMinCheck = new System.Windows.Forms.Button();
            this.MinLabel = new System.Windows.Forms.Label();
            this.PositionMinString = new System.Windows.Forms.Button();
            this.ConvertToDFA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AlphabetInputLabel
            // 
            this.AlphabetInputLabel.AutoSize = true;
            this.AlphabetInputLabel.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AlphabetInputLabel.Location = new System.Drawing.Point(30, 40);
            this.AlphabetInputLabel.Name = "AlphabetInputLabel";
            this.AlphabetInputLabel.Size = new System.Drawing.Size(187, 28);
            this.AlphabetInputLabel.TabIndex = 1;
            this.AlphabetInputLabel.Text = "Input ur alphabet";
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(35, 71);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(139, 20);
            this.InputBox.TabIndex = 2;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConfirmButton.Location = new System.Drawing.Point(35, 108);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(157, 36);
            this.ConfirmButton.TabIndex = 3;
            this.ConfirmButton.Text = "confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // FileLoad
            // 
            this.FileLoad.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileLoad.Location = new System.Drawing.Point(35, 150);
            this.FileLoad.Name = "FileLoad";
            this.FileLoad.Size = new System.Drawing.Size(235, 36);
            this.FileLoad.TabIndex = 4;
            this.FileLoad.Text = "download a file";
            this.FileLoad.UseVisualStyleBackColor = true;
            this.FileLoad.Click += new System.EventHandler(this.FileLoad_Click);
            // 
            // StringInput
            // 
            this.StringInput.Location = new System.Drawing.Point(35, 244);
            this.StringInput.Name = "StringInput";
            this.StringInput.Size = new System.Drawing.Size(139, 20);
            this.StringInput.TabIndex = 5;
            // 
            // StringInputLabel
            // 
            this.StringInputLabel.AutoSize = true;
            this.StringInputLabel.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StringInputLabel.Location = new System.Drawing.Point(35, 213);
            this.StringInputLabel.Name = "StringInputLabel";
            this.StringInputLabel.Size = new System.Drawing.Size(157, 28);
            this.StringInputLabel.TabIndex = 6;
            this.StringInputLabel.Text = "Input ur string";
            // 
            // ApplyButton
            // 
            this.ApplyButton.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApplyButton.Location = new System.Drawing.Point(35, 270);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(125, 40);
            this.ApplyButton.TabIndex = 7;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // PositionLabel
            // 
            this.PositionLabel.AutoSize = true;
            this.PositionLabel.Font = new System.Drawing.Font("Papyrus", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionLabel.Location = new System.Drawing.Point(263, 316);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(33, 33);
            this.PositionLabel.TabIndex = 9;
            this.PositionLabel.Text = ":p";
            // 
            // AlphabetLabel
            // 
            this.AlphabetLabel.AutoSize = true;
            this.AlphabetLabel.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlphabetLabel.Location = new System.Drawing.Point(35, 464);
            this.AlphabetLabel.Name = "AlphabetLabel";
            this.AlphabetLabel.Size = new System.Drawing.Size(104, 28);
            this.AlphabetLabel.TabIndex = 10;
            this.AlphabetLabel.Text = "Alphabet";
            // 
            // AlphabetShow
            // 
            this.AlphabetShow.AutoSize = true;
            this.AlphabetShow.Font = new System.Drawing.Font("Nirmala UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlphabetShow.Location = new System.Drawing.Point(174, 464);
            this.AlphabetShow.Name = "AlphabetShow";
            this.AlphabetShow.Size = new System.Drawing.Size(0, 30);
            this.AlphabetShow.TabIndex = 11;
            // 
            // PositionCheck
            // 
            this.PositionCheck.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PositionCheck.Location = new System.Drawing.Point(35, 316);
            this.PositionCheck.Name = "PositionCheck";
            this.PositionCheck.Size = new System.Drawing.Size(222, 36);
            this.PositionCheck.TabIndex = 12;
            this.PositionCheck.Text = "Check ur position";
            this.PositionCheck.UseVisualStyleBackColor = true;
            this.PositionCheck.Click += new System.EventHandler(this.PositionCheck_Click);
            // 
            // RefreshAll
            // 
            this.RefreshAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RefreshAll.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RefreshAll.Location = new System.Drawing.Point(594, 459);
            this.RefreshAll.Name = "RefreshAll";
            this.RefreshAll.Size = new System.Drawing.Size(139, 38);
            this.RefreshAll.TabIndex = 13;
            this.RefreshAll.Text = "Refresh all";
            this.RefreshAll.UseVisualStyleBackColor = true;
            this.RefreshAll.Click += new System.EventHandler(this.RefreshAll_Click);
            // 
            // PositionString
            // 
            this.PositionString.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PositionString.Location = new System.Drawing.Point(35, 358);
            this.PositionString.Name = "PositionString";
            this.PositionString.Size = new System.Drawing.Size(222, 36);
            this.PositionString.TabIndex = 14;
            this.PositionString.Text = "Check ur string";
            this.PositionString.UseVisualStyleBackColor = true;
            this.PositionString.Click += new System.EventHandler(this.PositionString_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(536, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 28);
            this.label1.TabIndex = 15;
            this.label1.Text = "Minimization";
            // 
            // InputLabel2
            // 
            this.InputLabel2.AutoSize = true;
            this.InputLabel2.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputLabel2.Location = new System.Drawing.Point(519, 50);
            this.InputLabel2.Name = "InputLabel2";
            this.InputLabel2.Size = new System.Drawing.Size(157, 28);
            this.InputLabel2.TabIndex = 16;
            this.InputLabel2.Text = "Input ur string";
            // 
            // MinInput
            // 
            this.MinInput.Location = new System.Drawing.Point(551, 81);
            this.MinInput.Name = "MinInput";
            this.MinInput.Size = new System.Drawing.Size(155, 20);
            this.MinInput.TabIndex = 17;
            // 
            // ApplyMinButton
            // 
            this.ApplyMinButton.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApplyMinButton.Location = new System.Drawing.Point(594, 108);
            this.ApplyMinButton.Name = "ApplyMinButton";
            this.ApplyMinButton.Size = new System.Drawing.Size(126, 47);
            this.ApplyMinButton.TabIndex = 18;
            this.ApplyMinButton.Text = "Apply";
            this.ApplyMinButton.UseVisualStyleBackColor = true;
            this.ApplyMinButton.Click += new System.EventHandler(this.ApplyMinButton_Click);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimizeButton.Location = new System.Drawing.Point(447, 108);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(130, 47);
            this.MinimizeButton.TabIndex = 19;
            this.MinimizeButton.Text = "Minimize";
            this.MinimizeButton.UseVisualStyleBackColor = true;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // PositionMinCheck
            // 
            this.PositionMinCheck.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PositionMinCheck.Location = new System.Drawing.Point(447, 162);
            this.PositionMinCheck.Name = "PositionMinCheck";
            this.PositionMinCheck.Size = new System.Drawing.Size(207, 41);
            this.PositionMinCheck.TabIndex = 20;
            this.PositionMinCheck.Text = "Check ur position";
            this.PositionMinCheck.UseVisualStyleBackColor = true;
            this.PositionMinCheck.Click += new System.EventHandler(this.PositionMinCheck_Click);
            // 
            // MinLabel
            // 
            this.MinLabel.AutoSize = true;
            this.MinLabel.Font = new System.Drawing.Font("Papyrus", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinLabel.Location = new System.Drawing.Point(660, 162);
            this.MinLabel.Name = "MinLabel";
            this.MinLabel.Size = new System.Drawing.Size(33, 33);
            this.MinLabel.TabIndex = 21;
            this.MinLabel.Text = ";p";
            // 
            // PositionMinString
            // 
            this.PositionMinString.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PositionMinString.Location = new System.Drawing.Point(447, 217);
            this.PositionMinString.Name = "PositionMinString";
            this.PositionMinString.Size = new System.Drawing.Size(207, 47);
            this.PositionMinString.TabIndex = 22;
            this.PositionMinString.Text = "Check ur string";
            this.PositionMinString.UseVisualStyleBackColor = true;
            this.PositionMinString.Click += new System.EventHandler(this.PositionMinString_Click);
            // 
            // ConvertToDFA
            // 
            this.ConvertToDFA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConvertToDFA.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConvertToDFA.Location = new System.Drawing.Point(166, 270);
            this.ConvertToDFA.Name = "ConvertToDFA";
            this.ConvertToDFA.Size = new System.Drawing.Size(203, 40);
            this.ConvertToDFA.TabIndex = 23;
            this.ConvertToDFA.Text = "Convert to DFA";
            this.ConvertToDFA.UseVisualStyleBackColor = true;
            this.ConvertToDFA.Click += new System.EventHandler(this.ConvertToDFA_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DFA.Properties.Resources.minim;
            this.ClientSize = new System.Drawing.Size(745, 513);
            this.Controls.Add(this.ConvertToDFA);
            this.Controls.Add(this.PositionMinString);
            this.Controls.Add(this.MinLabel);
            this.Controls.Add(this.PositionMinCheck);
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.ApplyMinButton);
            this.Controls.Add(this.MinInput);
            this.Controls.Add(this.InputLabel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PositionString);
            this.Controls.Add(this.RefreshAll);
            this.Controls.Add(this.PositionCheck);
            this.Controls.Add(this.AlphabetShow);
            this.Controls.Add(this.AlphabetLabel);
            this.Controls.Add(this.PositionLabel);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.StringInputLabel);
            this.Controls.Add(this.StringInput);
            this.Controls.Add(this.FileLoad);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.AlphabetInputLabel);
            this.Name = "Form1";
            this.Text = "DFA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label AlphabetInputLabel;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button FileLoad;
        private System.Windows.Forms.TextBox StringInput;
        private System.Windows.Forms.Label StringInputLabel;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label PositionLabel;
        private System.Windows.Forms.Label AlphabetLabel;
        private System.Windows.Forms.Label AlphabetShow;
        private System.Windows.Forms.Button PositionCheck;
        private System.Windows.Forms.Button RefreshAll;
        private System.Windows.Forms.Button PositionString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label InputLabel2;
        private System.Windows.Forms.TextBox MinInput;
        private System.Windows.Forms.Button ApplyMinButton;
        private System.Windows.Forms.Button MinimizeButton;
        private System.Windows.Forms.Button PositionMinCheck;
        private System.Windows.Forms.Label MinLabel;
        private System.Windows.Forms.Button PositionMinString;
        private System.Windows.Forms.Button ConvertToDFA;
    }
}

