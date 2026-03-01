namespace gradeCheck
{
    partial class Start
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        private TextBox GetTextBox1()
        {
            return textBox1;
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            checkGradeButton = new Button();
            addGradeButtom = new Button();
            removeGradeButton = new Button();
            addClassButton = new Button();
            removeClassButton = new Button();
            removeSemesterButton = new Button();
            addSemesterButton = new Button();
            displayGradeButton = new Button();
            calculateGPA = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(117, 73);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(486, 43);
            textBox1.TabIndex = 0;
            textBox1.Text = "What would you like to do?";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // checkGradeButton
            // 
            checkGradeButton.Location = new Point(233, 547);
            checkGradeButton.Name = "checkGradeButton";
            checkGradeButton.Size = new Size(238, 52);
            checkGradeButton.TabIndex = 1;
            checkGradeButton.Text = "Calculate Grade";
            checkGradeButton.UseVisualStyleBackColor = true;
            checkGradeButton.Click += button1_Click;
            // 
            // addGradeButtom
            // 
            addGradeButtom.Location = new Point(255, 373);
            addGradeButtom.Name = "addGradeButtom";
            addGradeButtom.Size = new Size(206, 52);
            addGradeButtom.TabIndex = 2;
            addGradeButtom.Text = "Add Grade";
            addGradeButtom.UseVisualStyleBackColor = true;
            addGradeButtom.Click += addGradeButtom_Click;
            // 
            // removeGradeButton
            // 
            removeGradeButton.Location = new Point(255, 431);
            removeGradeButton.Name = "removeGradeButton";
            removeGradeButton.Size = new Size(206, 52);
            removeGradeButton.TabIndex = 3;
            removeGradeButton.Text = "Remove Grade";
            removeGradeButton.UseVisualStyleBackColor = true;
            removeGradeButton.Click += removeGradeButton_Click;
            // 
            // addClassButton
            // 
            addClassButton.Location = new Point(255, 257);
            addClassButton.Name = "addClassButton";
            addClassButton.Size = new Size(206, 52);
            addClassButton.TabIndex = 4;
            addClassButton.Text = "Add Class";
            addClassButton.UseVisualStyleBackColor = true;
            addClassButton.Click += addClassButton_Click;
            // 
            // removeClassButton
            // 
            removeClassButton.Location = new Point(255, 315);
            removeClassButton.Name = "removeClassButton";
            removeClassButton.Size = new Size(206, 52);
            removeClassButton.TabIndex = 5;
            removeClassButton.Text = "Remove Class";
            removeClassButton.UseVisualStyleBackColor = true;
            removeClassButton.Click += removeClassButton_Click;
            // 
            // removeSemesterButton
            // 
            removeSemesterButton.Location = new Point(233, 199);
            removeSemesterButton.Name = "removeSemesterButton";
            removeSemesterButton.Size = new Size(249, 52);
            removeSemesterButton.TabIndex = 7;
            removeSemesterButton.Text = "Remove Semester";
            removeSemesterButton.UseVisualStyleBackColor = true;
            removeSemesterButton.Click += removeSemesterButton_Click;
            // 
            // addSemesterButton
            // 
            addSemesterButton.Location = new Point(255, 141);
            addSemesterButton.Name = "addSemesterButton";
            addSemesterButton.Size = new Size(206, 52);
            addSemesterButton.TabIndex = 8;
            addSemesterButton.Text = "Add Semester";
            addSemesterButton.UseVisualStyleBackColor = true;
            addSemesterButton.Click += addSemesterButton_Click;
            // 
            // displayGradeButton
            // 
            displayGradeButton.Location = new Point(255, 489);
            displayGradeButton.Name = "displayGradeButton";
            displayGradeButton.Size = new Size(206, 52);
            displayGradeButton.TabIndex = 9;
            displayGradeButton.Text = "Display Grade";
            displayGradeButton.UseVisualStyleBackColor = true;
            displayGradeButton.Click += displayGradeButton_Click;
            // 
            // calculateGPA
            // 
            calculateGPA.Location = new Point(233, 605);
            calculateGPA.Name = "calculateGPA";
            calculateGPA.Size = new Size(238, 52);
            calculateGPA.TabIndex = 10;
            calculateGPA.Text = "Calculate GPA";
            calculateGPA.UseVisualStyleBackColor = true;
            calculateGPA.Click += calculateGPA_Click;
            // 
            // Start
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(742, 703);
            Controls.Add(calculateGPA);
            Controls.Add(displayGradeButton);
            Controls.Add(addSemesterButton);
            Controls.Add(removeSemesterButton);
            Controls.Add(removeClassButton);
            Controls.Add(addClassButton);
            Controls.Add(removeGradeButton);
            Controls.Add(addGradeButtom);
            Controls.Add(checkGradeButton);
            Controls.Add(textBox1);
            MaximizeBox = false;
            Name = "Start";
            Text = "Grade Checker";
            Load += Start_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button checkGradeButton;
        private Button addGradeButtom;
        private Button removeGradeButton;
        private Button addClassButton;
        private Button removeClassButton;
        private Button removeSemesterButton;
        private Button addSemesterButton;
        private Button displayGradeButton;
        private Button calculateGPA;
    }
}
