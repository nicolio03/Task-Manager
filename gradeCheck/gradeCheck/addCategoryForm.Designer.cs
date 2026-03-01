namespace gradeCheck
{
    partial class addCategoryForm
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
            textBox2 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            textBox5 = new TextBox();
            domainUpDown1 = new DomainUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 37);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(486, 43);
            textBox1.TabIndex = 1;
            textBox1.Text = "What is a grade category for this class?";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 189);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(486, 43);
            textBox2.TabIndex = 2;
            textBox2.Text = "What is that categories weight ?";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(12, 255);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(270, 43);
            numericUpDown1.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 99);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(225, 43);
            textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(288, 254);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(32, 43);
            textBox4.TabIndex = 5;
            textBox4.Text = "%";
            // 
            // button1
            // 
            button1.Location = new Point(12, 499);
            button1.Name = "button1";
            button1.Size = new Size(169, 52);
            button1.TabIndex = 6;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(12, 349);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(511, 43);
            textBox5.TabIndex = 7;
            textBox5.Text = "Does this category drop the lowest grade?";
            // 
            // domainUpDown1
            // 
            domainUpDown1.Location = new Point(12, 398);
            domainUpDown1.Name = "domainUpDown1";
            domainUpDown1.Size = new Size(270, 43);
            domainUpDown1.TabIndex = 8;
            domainUpDown1.Text = "Choose";
            // 
            // addCategoryForm
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 593);
            Controls.Add(domainUpDown1);
            Controls.Add(textBox5);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "addCategoryForm";
            Text = "Add Class";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private NumericUpDown numericUpDown1;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private TextBox textBox5;
        private DomainUpDown domainUpDown1;
    }
}