using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Tasks;

namespace Tasks
{
    public partial class MainForm : Form
    {
        private string? _baseGradesDir;
        private string? _semesterDir;
        private string? _courseName;
        private string? _tasksCsvPath;

        public MainForm()
        {
            SetupUi();
            LoadSemesters();
        }

        private ComboBox semesterCombo = new ComboBox();
        private ComboBox courseCombo = new ComboBox();
        private Button addTaskBtn = new Button();
        private Button completeTaskBtn = new Button();
        private Button deleteTaskBtn = new Button();
        private ListBox tasksList = new ListBox();
        private Label infoLabel = new Label();
        private int _semesterYear;

        private void LoadSemesters()
        {
            _baseGradesDir = FindGradesBaseDir();
            if (_baseGradesDir == null)
            {
                MessageBox.Show("Could not find Grades folder in Documents or OneDrive\\Documents.", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var semesters = Directory.GetDirectories(_baseGradesDir)
                .Select(Path.GetFileName)
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .OrderBy(n => n)
                .ToList();

            semesterCombo.Items.Clear();
            foreach (var s in semesters) semesterCombo.Items.Add(s!);

            infoLabel.Text = $"Grades folder: {_baseGradesDir}";
        }

        private string? FindGradesBaseDir()
        {
            var user = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            var candidates = new List<string>
            {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Grades"),
                Path.Combine(user, "OneDrive", "Documents", "Grades")
            };

            return candidates.FirstOrDefault(Directory.Exists);
        }

        private void OnSemesterSelected()
        {
            if (semesterCombo.SelectedItem == null) return;

            var semester = semesterCombo.SelectedItem.ToString()!;
            _semesterDir = Path.Combine(_baseGradesDir!, semester);
            _semesterYear = ExtractYearFromSemester(semester);

            // Courses are CSV files in semester folder (GradeChecker output)
            var courses = Directory.GetFiles(_semesterDir, "*.csv")
                .Select(Path.GetFileName)
                .Where(fn => !string.IsNullOrWhiteSpace(fn))
                .Select(fn => NormalizeCourseName(fn!))
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            courseCombo.Items.Clear();
            foreach (var c in courses) courseCombo.Items.Add(c);

            _courseName = null;
            _tasksCsvPath = null;
            addTaskBtn.Enabled = false;
            deleteTaskBtn.Enabled = false;
            completeTaskBtn.Enabled = false;
            tasksList.Items.Clear();

            infoLabel.Text = $"Semester: {semester}  |  Courses found: {courses.Count}";
        }

        private void OnCourseSelected()
        {
            if (courseCombo.SelectedItem == null || _semesterDir == null) return;

            _courseName = courseCombo.SelectedItem.ToString()!;
            var tasksDir = Path.Combine(_semesterDir, "Tasks");
            _tasksCsvPath = Path.Combine(tasksDir, $"{_courseName}_tasks.csv");

            addTaskBtn.Enabled = true;
            completeTaskBtn.Enabled = true;
            deleteTaskBtn.Enabled = true;

            RefreshTasksList();
        }

        private void RefreshTasksList()
        {
            tasksList.Items.Clear();
            if (_tasksCsvPath == null) return;

            var tasks = CsvTasks.Load(_tasksCsvPath);
            foreach (var t in tasks.Where(x => x.Status == "Open").OrderBy(x => x.Due))
            {
                tasksList.Items.Add(new TaskListItem(t));
            }

            infoLabel.Text = $"Course: {_courseName}  |  Open tasks: {tasksList.Items.Count}";
        }

        private void AddTask()
        {
            if (_tasksCsvPath == null || _courseName == null) return;

            var types = GetAssignmentTypesForCourse(_courseName);
            using var dlg = new AddTaskForm(_courseName, _semesterYear, types);
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            var task = new TaskItem
            {
                Title = dlg.TaskTitle,
                AssignmentType = dlg.AssignmentType,
                Due = dlg.DueDateTime,
                Status = "Open",
                CreatedAt = DateTime.Now
            };


            CsvTasks.Add(_tasksCsvPath, task);
            RefreshTasksList();
        }

        private void CompleteTask()
        {
            if (_tasksCsvPath == null) return;
            if (tasksList.SelectedItem is not TaskListItem selected)
            {
                MessageBox.Show("Select a task first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dlg = new CompleteTaskForm(selected.Task.Title);
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            CsvTasks.Complete(_tasksCsvPath, selected.Task.Id, dlg.MinutesSpent);
            RefreshTasksList();
        }

        private static string NormalizeCourseName(string? filename)
        {
            if (string.IsNullOrWhiteSpace(filename)) return "";

            var stem = Path.GetFileNameWithoutExtension(filename); // "AI(3)"
            var idx = stem.IndexOf('(');
            if (idx >= 0) stem = stem.Substring(0, idx);
            return stem.Trim();
        }

        private class TaskListItem
        {
            public TaskItem Task { get; }
            public TaskListItem(TaskItem t) => Task = t;

            public override string ToString()
            {
                return $"{Task.Due:ddd MM/dd HH:mm}  |  {Task.Title}";
            }
        }

        private void SetupUi()
        {
            Text = "Tasks (Grades Folder)";
            MinimumSize = new Size(900, 600);
            StartPosition = FormStartPosition.CenterScreen;

            // Controls
            var step1Label = new Label
            {
                Text = "1) Pick Semester",
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                Font = new Font(Font.FontFamily, 10, FontStyle.Bold)
            };

            var step2Label = new Label
            {
                Text = "2) Pick Course",
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                Font = new Font(Font.FontFamily, 10, FontStyle.Bold)
            };

            semesterCombo = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Anchor = AnchorStyles.Left | AnchorStyles.Right
            };

            courseCombo = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Anchor = AnchorStyles.Left | AnchorStyles.Right
            };

            addTaskBtn = new Button
            {
                Text = "Add Task",
                AutoSize = true,
                Anchor = AnchorStyles.Right
            };

            completeTaskBtn = new Button
            {
                Text = "Complete Task",
                AutoSize = true,
                Anchor = AnchorStyles.Right
            };

            addTaskBtn.Enabled = false;
            completeTaskBtn.Enabled = false;


            deleteTaskBtn = new Button
            {
                Text = "Delete Task",
                AutoSize = true,
                Anchor = AnchorStyles.Right
            };
            deleteTaskBtn.Enabled = false;
            deleteTaskBtn.Click += (_, __) => DeleteTask();

            tasksList = new ListBox
            {
                Dock = DockStyle.Fill
            };

            infoLabel = new Label
            {
                Dock = DockStyle.Fill,
                AutoEllipsis = true
            };

            // Events
            semesterCombo.SelectedIndexChanged += (_, __) => OnSemesterSelected();
            courseCombo.SelectedIndexChanged += (_, __) => OnCourseSelected();
            addTaskBtn.Click += (_, __) => AddTask();
            completeTaskBtn.Click += (_, __) => CompleteTask();

            // Top layout: 2 rows, 4 columns
            // Col0: step labels, Col1: combo boxes (stretch), Col2: buttons
            var top = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Padding = new Padding(12),
                ColumnCount = 4,
                RowCount = 2
            };

            top.ColumnStyles.Clear();
            top.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));          // labels
            top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));      // combos expand
            top.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));          // button 1
            top.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));          // button 2
                                                                               // buttons auto-size

            top.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            top.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            top.Controls.Add(step1Label, 0, 0);
            top.Controls.Add(semesterCombo, 1, 0);
            top.Controls.Add(addTaskBtn, 2, 0);
            top.Controls.Add(deleteTaskBtn, 3, 0);

            top.Controls.Add(step2Label, 0, 1);
            top.Controls.Add(courseCombo, 1, 1);
            top.Controls.Add(completeTaskBtn, 2, 1);

            // Main layout: top + list + status
            var main = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(12),
                ColumnCount = 1,
                RowCount = 3
            };

            main.RowStyles.Add(new RowStyle(SizeType.AutoSize));        // top section
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 100));    // list grows
            main.RowStyles.Add(new RowStyle(SizeType.AutoSize));        // status line

            main.Controls.Add(top, 0, 0);
            main.Controls.Add(tasksList, 0, 1);
            main.Controls.Add(infoLabel, 0, 2);

            Controls.Clear();
            Controls.Add(main);
        }

        private void DeleteTask()
        {
            if (_tasksCsvPath == null) return;

            if (tasksList.SelectedItem is not TaskListItem selected)
            {
                MessageBox.Show("Select a task first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"Delete this task?\n\n{selected.Task.Title}\n\nThis cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes) return;

            CsvTasks.Delete(_tasksCsvPath, selected.Task.Id);
            RefreshTasksList();
        }


        private static int ExtractYearFromSemester(string semester)
        {
            // expects something like "Spring2026"
            var digits = new string(semester.Where(char.IsDigit).ToArray());
            if (digits.Length >= 4 && int.TryParse(digits.Substring(digits.Length - 4), out int year))
                return year;

            // fallback (if format ever changes)
            return DateTime.Now.Year;
        }

        private List<string> GetAssignmentTypesForCourse(string courseName)
        {
            // Find a course CSV that matches the normalized name, e.g. "AI" matches "AI(3).csv"
            if (_semesterDir == null) return new List<string>();

            var csvFiles = Directory.GetFiles(_semesterDir, "*.csv");

            string? match = csvFiles.FirstOrDefault(f =>
                NormalizeCourseName(Path.GetFileName(f)).Equals(courseName, StringComparison.OrdinalIgnoreCase));

            if (match == null || !File.Exists(match)) return new List<string>();

            var lines = File.ReadAllLines(match);
            var types = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(',');
                if (parts.Length < 1) continue;

                // First column is category string like "Homework(20%;Yes)" or "Quizzes(10%)"
                var raw = parts[0].Trim();
                if (string.IsNullOrWhiteSpace(raw)) continue;

                // Strip anything after '('
                int lp = raw.IndexOf('(');
                var clean = (lp >= 0 ? raw.Substring(0, lp) : raw).Trim();

                if (!string.IsNullOrWhiteSpace(clean))
                    types.Add(clean);
            }

            // return sorted list
            return types.OrderBy(x => x).ToList();
        }


    }

}