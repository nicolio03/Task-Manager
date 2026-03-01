using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradeCheck
{
    public partial class displayGradeForm : Form
    {
        public displayGradeForm()
        {
            InitializeComponent();

            //yearUpDown setup
            yearUpDown.Minimum = 0;
            yearUpDown.Maximum = 9999;
            yearUpDown.Value = 0000;
            yearUpDown.Increment = 1;
            yearUpDown.DecimalPlaces = 0;

            //seasonUpDown setup
            seasonUpDown.Items.Clear();
            seasonUpDown.Items.Add("Spring");
            seasonUpDown.Items.Add("Summer");
            seasonUpDown.Items.Add("Fall");

        }

        private void searchClassButton_Click(object sender, EventArgs e)
        {
            string season = seasonUpDown.Text;
            int year = (int)yearUpDown.Value;

            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Grades");
            string fileName = season + year;
            string folderPath = Path.Combine(folder, fileName);

            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("Semester does not exist.");
            }
            else
            {
                string name = textBox4.Text;
                string[] csvFiles = Directory.GetFiles(folderPath, "*.csv");

                string matchedFile = csvFiles.FirstOrDefault(file =>
                {
                    string fileNameOnly = Path.GetFileNameWithoutExtension(file);
                    return fileNameOnly.StartsWith(name, StringComparison.OrdinalIgnoreCase);
                });
                if (matchedFile == null)
                {
                    MessageBox.Show("Class does not exist.");
                }
                else
                {
                    this.Controls.Clear();

                    // Create or reference a DataGridView
                    DataGridView gradeGridView = new DataGridView
                    {
                        Location = new Point(5, 5),
                        Size = new Size(845, 579),
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                        ReadOnly = true
                    };
                    this.Controls.Add(gradeGridView);

                    // Load data from the CSV
                    DataTable table = new DataTable();
                    table.Columns.Add("Category");

                    List<string[]> rows = new List<string[]>();
                    int maxGrades = 0;

                    foreach (string line in File.ReadAllLines(matchedFile))
                    {
                        string[] parts = line.Split(',');
                        rows.Add(parts);
                        maxGrades = Math.Max(maxGrades, parts.Length - 1);
                    }

                    for (int i = 1; i <= maxGrades; i++)
                    {
                        table.Columns.Add($"Grade {i}");
                    }

                    foreach (var row in rows)
                    {
                        DataRow dr = table.NewRow();
                        for (int i = 0; i < row.Length; i++)
                        {
                            dr[i] = row[i];
                        }
                        table.Rows.Add(dr);
                    }

                    gradeGridView.DataSource = table;

                }
            }
        }
    }
}
