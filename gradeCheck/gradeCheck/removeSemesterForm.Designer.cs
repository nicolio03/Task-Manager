namespace gradeCheck
{
    partial class removeSemesterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            seasonUpDown = new DomainUpDown();
            yearUpDown = new NumericUpDown();
            button1 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)yearUpDown).BeginInit();
            SuspendLayout();
            // 
            // seasonUpDown
            // 
            seasonUpDown.Location = new Point(25, 98);
            seasonUpDown.Name = "seasonUpDown";
            seasonUpDown.Size = new Size(270, 43);
            seasonUpDown.TabIndex = 11;
            seasonUpDown.Text = "Season";
            // 
            // yearUpDown
            // 
            yearUpDown.Location = new Point(25, 251);
            yearUpDown.Name = "yearUpDown";
            yearUpDown.Size = new Size(270, 43);
            yearUpDown.TabIndex = 10;
            // 
            // button1
            // 
            button1.Location = new Point(25, 349);
            button1.Name = "button1";
            button1.Size = new Size(169, 52);
            button1.TabIndex = 9;
            button1.Text = "Remove";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(25, 185);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(424, 43);
            textBox2.TabIndex = 8;
            textBox2.Text = "What year is this semester?";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(25, 33);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(424, 43);
            textBox1.TabIndex = 7;
            textBox1.Text = "What season is this semester?";
            // 
            // removeSemesterForm
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(seasonUpDown);
            Controls.Add(yearUpDown);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "removeSemesterForm";
            Text = "Remove Semester";
            ((System.ComponentModel.ISupportInitialize)yearUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DomainUpDown seasonUpDown;
        private NumericUpDown yearUpDown;
        private Button button1;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}