using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Tasks
{
    public class AddTaskForm : Form
    {
        private TextBox titleBox = new TextBox();
        private ComboBox typeCombo = new ComboBox();
        private DateTimePicker duePicker = new DateTimePicker();
        private Button okBtn = new Button();
        private Button cancelBtn = new Button();

        private readonly int _semesterYear;

        public string TaskTitle => titleBox.Text.Trim();
        public string AssignmentType => typeCombo.SelectedItem?.ToString()?.Trim() ?? "";
        public DateTime DueDateTime { get; private set; }

        public AddTaskForm(string courseName, int semesterYear, List<string> assignmentTypes)
        {
            _semesterYear = semesterYear;

            Text = $"Add Task ({courseName})";
            AutoScaleMode = AutoScaleMode.Font;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;

            // Labels
            var titleLbl = new Label { Text = "Task Title:", AutoSize = true, Anchor = AnchorStyles.Left };
            var typeLbl = new Label { Text = "Assignment Type:", AutoSize = true, Anchor = AnchorStyles.Left };
            var dueLbl = new Label { Text = "Due (month/day + time):", AutoSize = true, Anchor = AnchorStyles.Left };

            // Title
            titleBox.Dock = DockStyle.Fill;

            // Type dropdown
            typeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            typeCombo.Dock = DockStyle.Fill;

            var cleanTypes = (assignmentTypes ?? new List<string>())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(x => x)
                .ToList();

            if (cleanTypes.Count == 0)
            {
                // Still show something so it's obvious the control exists
                cleanTypes.Add("(No categories found in course CSV)");
                typeCombo.Enabled = false;
            }

            foreach (var t in cleanTypes)
                typeCombo.Items.Add(t);

            typeCombo.SelectedIndex = 0;

            // Due picker (no year in UI; year inferred from semester)
            duePicker.Dock = DockStyle.Fill;
            duePicker.Format = DateTimePickerFormat.Custom;
            duePicker.CustomFormat = "MMM dd  hh:mm tt";  // keeps it narrow
            duePicker.ShowUpDown = true;

            // Buttons
            okBtn.Text = "OK";
            okBtn.AutoSize = true;
            okBtn.DialogResult = DialogResult.OK;

            cancelBtn.Text = "Cancel";
            cancelBtn.AutoSize = true;
            cancelBtn.DialogResult = DialogResult.Cancel;

            AcceptButton = okBtn;
            CancelButton = cancelBtn;

            okBtn.Click += (_, __) =>
            {
                if (string.IsNullOrWhiteSpace(TaskTitle))
                {
                    MessageBox.Show("Enter a task title.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                    return;
                }

                if (typeCombo.Enabled && string.IsNullOrWhiteSpace(AssignmentType))
                {
                    MessageBox.Show("Pick an assignment type.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                    return;
                }

                try
                {
                    var v = duePicker.Value;
                    DueDateTime = new DateTime(_semesterYear, v.Month, v.Day, v.Hour, v.Minute, 0);
                }
                catch
                {
                    MessageBox.Show("That month/day isn't valid for the semester year.", "Invalid Date",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                }
            };

            // Layout (4 rows now!)
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

            grid.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // title
            grid.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // type
            grid.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // due
            grid.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // buttons

            grid.Controls.Add(titleLbl, 0, 0);
            grid.Controls.Add(titleBox, 1, 0);

            grid.Controls.Add(typeLbl, 0, 1);
            grid.Controls.Add(typeCombo, 1, 1);

            grid.Controls.Add(dueLbl, 0, 2);
            grid.Controls.Add(duePicker, 1, 2);

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

            ClientSize = new Size(720, 220);
            MinimumSize = new Size(720, 220);
        }
    }
}
