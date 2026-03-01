namespace gradeCheck
{
    partial class addGradeForm2
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
            textBox1 = new TextBox();
            categoryUpDown = new DomainUpDown();
            textBox2 = new TextBox();
            gradeUpDown = new NumericUpDown();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)gradeUpDown).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 30);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(690, 43);
            textBox1.TabIndex = 13;
            textBox1.Text = "What category does the grade belong to?";
            // 
            // categoryUpDown
            // 
            categoryUpDown.Location = new Point(12, 101);
            categoryUpDown.Name = "categoryUpDown";
            categoryUpDown.Size = new Size(270, 43);
            categoryUpDown.TabIndex = 14;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 182);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(690, 43);
            textBox2.TabIndex = 15;
            textBox2.Text = "What is the grade?";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // gradeUpDown
            // 
            gradeUpDown.Location = new Point(12, 259);
            gradeUpDown.Name = "gradeUpDown";
            gradeUpDown.Size = new Size(270, 43);
            gradeUpDown.TabIndex = 16;
            // 
            // button1
            // 
            button1.Location = new Point(12, 350);
            button1.Name = "button1";
            button1.Size = new Size(169, 52);
            button1.TabIndex = 17;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // addGradeForm2
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(gradeUpDown);
            Controls.Add(textBox2);
            Controls.Add(categoryUpDown);
            Controls.Add(textBox1);
            Name = "addGradeForm2";
            Text = "Add Grade";
            ((System.ComponentModel.ISupportInitialize)gradeUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private DomainUpDown categoryUpDown;
        private TextBox textBox2;
        private NumericUpDown gradeUpDown;
        private Button button1;
    }
}