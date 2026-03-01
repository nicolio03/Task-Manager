namespace gradeCheck
{
    partial class addSemester
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
            button1 = new Button();
            yearUpDown = new NumericUpDown();
            seasonUpDown = new DomainUpDown();
            ((System.ComponentModel.ISupportInitialize)yearUpDown).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(77, 69);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(424, 43);
            textBox1.TabIndex = 0;
            textBox1.Text = "What season is this semester?";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(77, 221);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(424, 43);
            textBox2.TabIndex = 2;
            textBox2.Text = "What year is this semester?";
            // 
            // button1
            // 
            button1.Location = new Point(77, 407);
            button1.Name = "button1";
            button1.Size = new Size(169, 52);
            button1.TabIndex = 4;
            button1.Text = "Create";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // yearUpDown
            // 
            yearUpDown.Location = new Point(77, 287);
            yearUpDown.Name = "yearUpDown";
            yearUpDown.Size = new Size(270, 43);
            yearUpDown.TabIndex = 5;
            // 
            // seasonUpDown
            // 
            seasonUpDown.Location = new Point(77, 134);
            seasonUpDown.Name = "seasonUpDown";
            seasonUpDown.Size = new Size(270, 43);
            seasonUpDown.TabIndex = 6;
            seasonUpDown.Text = "Season";
            // 
            // addSemester
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 521);
            Controls.Add(seasonUpDown);
            Controls.Add(yearUpDown);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "addSemester";
            Text = "addSemester";
            Load += addSemester_Load;
            ((System.ComponentModel.ISupportInitialize)yearUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private NumericUpDown yearUpDown;
        private DomainUpDown seasonUpDown;
    }
}