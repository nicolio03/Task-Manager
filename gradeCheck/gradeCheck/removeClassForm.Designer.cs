namespace gradeCheck
{
    partial class removeClassForm
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
            button1 = new Button();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            seasonUpDown = new DomainUpDown();
            yearUpDown = new NumericUpDown();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)yearUpDown).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 486);
            button1.Name = "button1";
            button1.Size = new Size(169, 52);
            button1.TabIndex = 25;
            button1.Text = "Remove";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 401);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(225, 43);
            textBox4.TabIndex = 24;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 335);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(690, 43);
            textBox3.TabIndex = 23;
            textBox3.Text = "What is the name of the class?";
            // 
            // seasonUpDown
            // 
            seasonUpDown.Location = new Point(12, 80);
            seasonUpDown.Name = "seasonUpDown";
            seasonUpDown.Size = new Size(270, 43);
            seasonUpDown.TabIndex = 22;
            seasonUpDown.Text = "Season";
            // 
            // yearUpDown
            // 
            yearUpDown.Location = new Point(12, 233);
            yearUpDown.Name = "yearUpDown";
            yearUpDown.Size = new Size(270, 43);
            yearUpDown.TabIndex = 21;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 167);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(690, 43);
            textBox2.TabIndex = 20;
            textBox2.Text = "What is the semsters year that the class belongs to?";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 15);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(690, 43);
            textBox1.TabIndex = 19;
            textBox1.Text = "What is the semesters season that the class belongs to?";
            // 
            // removeClassForm
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 570);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(seasonUpDown);
            Controls.Add(yearUpDown);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "removeClassForm";
            Text = "removeClassForm";
            ((System.ComponentModel.ISupportInitialize)yearUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox4;
        private TextBox textBox3;
        private DomainUpDown seasonUpDown;
        private NumericUpDown yearUpDown;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}