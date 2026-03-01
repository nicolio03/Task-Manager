namespace gradeCheck
{
    partial class removeGradeForm2
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
            removeButton = new Button();
            numericUpDown1 = new NumericUpDown();
            textBox2 = new TextBox();
            categoryUpDown = new DomainUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(29, 168);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(486, 43);
            textBox1.TabIndex = 1;
            textBox1.Text = "Which grade would you like to remove?";
            // 
            // removeButton
            // 
            removeButton.Location = new Point(29, 308);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(169, 52);
            removeButton.TabIndex = 2;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(29, 228);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(270, 43);
            numericUpDown1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(29, 48);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(664, 43);
            textBox2.TabIndex = 4;
            textBox2.Text = "From which grade category would you like to remove?";
            // 
            // categoryUpDown
            // 
            categoryUpDown.Location = new Point(29, 108);
            categoryUpDown.Name = "categoryUpDown";
            categoryUpDown.Size = new Size(270, 43);
            categoryUpDown.TabIndex = 5;
            categoryUpDown.Text = "Category";
            // 
            // removeGradeForm2
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 453);
            Controls.Add(categoryUpDown);
            Controls.Add(textBox2);
            Controls.Add(numericUpDown1);
            Controls.Add(removeButton);
            Controls.Add(textBox1);
            Name = "removeGradeForm2";
            Text = "Remove Grade";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button removeButton;
        private NumericUpDown numericUpDown1;
        private TextBox textBox2;
        private DomainUpDown categoryUpDown;
    }
}