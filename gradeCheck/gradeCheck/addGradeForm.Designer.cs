namespace gradeCheck
{
    partial class addGradeForm
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
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            seasonUpDown = new DomainUpDown();
            yearUpDown = new NumericUpDown();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            searchClassButton = new Button();
            ((System.ComponentModel.ISupportInitialize)yearUpDown).BeginInit();
            SuspendLayout();
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 407);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(225, 43);
            textBox4.TabIndex = 23;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 341);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(690, 43);
            textBox3.TabIndex = 22;
            textBox3.Text = "What is the name of the class the grade belongs to?";
            // 
            // seasonUpDown
            // 
            seasonUpDown.Location = new Point(12, 86);
            seasonUpDown.Name = "seasonUpDown";
            seasonUpDown.Size = new Size(270, 43);
            seasonUpDown.TabIndex = 21;
            seasonUpDown.Text = "Season";
            // 
            // yearUpDown
            // 
            yearUpDown.Location = new Point(12, 239);
            yearUpDown.Name = "yearUpDown";
            yearUpDown.Size = new Size(270, 43);
            yearUpDown.TabIndex = 20;
            yearUpDown.ValueChanged += yearUpDown_ValueChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 173);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(776, 43);
            textBox2.TabIndex = 19;
            textBox2.Text = "What is the semsters year that the class for the grade belongs to?";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 21);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(826, 43);
            textBox1.TabIndex = 18;
            textBox1.Text = "What is the semesters season that the class for the grade belongs to?";
            // 
            // searchClassButton
            // 
            searchClassButton.Location = new Point(12, 494);
            searchClassButton.Name = "searchClassButton";
            searchClassButton.Size = new Size(169, 52);
            searchClassButton.TabIndex = 24;
            searchClassButton.Text = "Search";
            searchClassButton.UseVisualStyleBackColor = true;
            searchClassButton.Click += searchClassButton_Click;
            // 
            // addGradeForm
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(924, 589);
            Controls.Add(searchClassButton);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(seasonUpDown);
            Controls.Add(yearUpDown);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "addGradeForm";
            Text = "Add Grade";
            ((System.ComponentModel.ISupportInitialize)yearUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox4;
        private TextBox textBox3;
        private DomainUpDown seasonUpDown;
        private NumericUpDown yearUpDown;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button searchClassButton;
    }
}