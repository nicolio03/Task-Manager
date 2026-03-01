using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tasks
{
    public class CompleteTaskForm : Form
    {
        private NumericUpDown minutesUpDown = new NumericUpDown();
        private Button okBtn = new Button();
        private Button cancelBtn = new Button();

        public int MinutesSpent => (int)minutesUpDown.Value;

        public CompleteTaskForm(string taskTitle)
        {
            Text = "Complete Task";

            // DPI-safe defaults
            AutoScaleMode = AutoScaleMode.Font;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;

            var titleLbl = new Label
            {
                Text = "How many minutes did this take?",
                AutoSize = true,
                Font = new Font(Font.FontFamily, 10, FontStyle.Bold),
                Anchor = AnchorStyles.Left
            };

            var taskLbl = new Label
            {
                Text = taskTitle ?? "",
                AutoSize = true,
                MaximumSize = new Size(650, 0), // wraps long titles
                Anchor = AnchorStyles.Left
            };

            var minutesLbl = new Label
            {
                Text = "Minutes spent:",
                AutoSize = true,
                Anchor = AnchorStyles.Left
            };

            minutesUpDown.Minimum = 1;
            minutesUpDown.Maximum = 24 * 60;
            minutesUpDown.Value = 30;
            minutesUpDown.Increment = 5;
            minutesUpDown.Dock = DockStyle.Fill;

            okBtn.Text = "OK";
            okBtn.AutoSize = true;
            okBtn.DialogResult = DialogResult.OK;

            cancelBtn.Text = "Cancel";
            cancelBtn.AutoSize = true;
            cancelBtn.DialogResult = DialogResult.Cancel;

            AcceptButton = okBtn;
            CancelButton = cancelBtn;

            // Layout grid
            var grid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(12),
                ColumnCount = 2,
                RowCount = 4
            };

            grid.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            grid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            grid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            grid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            grid.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            grid.Controls.Add(titleLbl, 0, 0);
            grid.SetColumnSpan(titleLbl, 2);

            grid.Controls.Add(taskLbl, 0, 1);
            grid.SetColumnSpan(taskLbl, 2);

            grid.Controls.Add(minutesLbl, 0, 2);
            grid.Controls.Add(minutesUpDown, 1, 2);

            var buttons = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Fill,
                AutoSize = true,
                WrapContents = false
            };
            buttons.Controls.Add(cancelBtn);
            buttons.Controls.Add(okBtn);

            grid.Controls.Add(buttons, 0, 3);
            grid.SetColumnSpan(buttons, 2);

            Controls.Clear();
            Controls.Add(grid);

            // Safe minimum size so nothing clips at DPI scaling
            ClientSize = new Size(720, 200);
            MinimumSize = new Size(720, 200);
        }
    }
}
