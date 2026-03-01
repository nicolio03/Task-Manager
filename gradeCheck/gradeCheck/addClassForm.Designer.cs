namespace gradeCheck
{
    partial class addClassForm
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
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            textBox5 = new TextBox();
            ongoingUpDown = new DomainUpDown();
            creditUpDown = new NumericUpDown();
            textBox6 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)yearUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)creditUpDown).BeginInit();
            SuspendLayout();
            // 
            // seasonUpDown
            // 
            seasonUpDown.Location = new Point(12, 77);
            seasonUpDown.Name = "seasonUpDown";
            seasonUpDown.Size = new Size(270, 43);
            seasonUpDown.TabIndex = 15;
            seasonUpDown.Text = "Season";
            // 
            // yearUpDown
            // 
            yearUpDown.Location = new Point(12, 230);
            yearUpDown.Name = "yearUpDown";
            yearUpDown.Size = new Size(270, 43);
            yearUpDown.TabIndex = 14;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 164);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(690, 43);
            textBox2.TabIndex = 13;
            textBox2.Text = "What is the semsters year that the class belongs to?";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(690, 43);
            textBox1.TabIndex = 12;
            textBox1.Text = "What is the semesters season that the class belongs to?";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 332);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(690, 43);
            textBox3.TabIndex = 16;
            textBox3.Text = "What is the name of the class?";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 398);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(225, 43);
            textBox4.TabIndex = 17;
            // 
            // button1
            // 
            button1.Location = new Point(12, 756);
            button1.Name = "button1";
            button1.Size = new Size(169, 52);
            button1.TabIndex = 18;
            button1.Text = "Create";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(12, 610);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(690, 43);
            textBox5.TabIndex = 19;
            textBox5.Text = "Is the class ongoing?";
            // 
            // ongoingUpDown
            // 
            ongoingUpDown.Location = new Point(12, 659);
            ongoingUpDown.Name = "ongoingUpDown";
            ongoingUpDown.Size = new Size(270, 43);
            ongoingUpDown.TabIndex = 20;
            ongoingUpDown.Text = "Ongoing";
            // 
            // creditUpDown
            // 
            creditUpDown.Location = new Point(12, 538);
            creditUpDown.Name = "creditUpDown";
            creditUpDown.Size = new Size(270, 43);
            creditUpDown.TabIndex = 22;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(12, 472);
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new Size(690, 43);
            textBox6.TabIndex = 21;
            textBox6.Text = "What is the amount of credits this class is worth?";
            // 
            // addClassForm
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(747, 829);
            Controls.Add(creditUpDown);
            Controls.Add(textBox6);
            Controls.Add(ongoingUpDown);
            Controls.Add(textBox5);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(seasonUpDown);
            Controls.Add(yearUpDown);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "addClassForm";
            Text = "Add Class";
            ((System.ComponentModel.ISupportInitialize)yearUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)creditUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DomainUpDown seasonUpDown;
        private NumericUpDown yearUpDown;
        private TextBox textBox2;
        private TextBox textBox1;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private TextBox textBox5;
        private DomainUpDown ongoingUpDown;
        private NumericUpDown creditUpDown;
        private TextBox textBox6;
    }
}