namespace gradeCheck
{
    partial class addClassForm2
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
            textBox2 = new TextBox();
            gradeUpDown = new DomainUpDown();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 184);
            button1.Name = "button1";
            button1.Size = new Size(169, 52);
            button1.TabIndex = 20;
            button1.Text = "Create";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 16);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(690, 43);
            textBox2.TabIndex = 18;
            textBox2.Text = "What is the final grade?";
            // 
            // gradeUpDown
            // 
            gradeUpDown.Location = new Point(12, 85);
            gradeUpDown.Name = "gradeUpDown";
            gradeUpDown.Size = new Size(270, 43);
            gradeUpDown.TabIndex = 21;
            gradeUpDown.Text = "Grade";
            // 
            // addClassForm2
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 277);
            Controls.Add(gradeUpDown);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Name = "addClassForm2";
            Text = "addClassForm2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox2;
        private DomainUpDown gradeUpDown;
    }
}