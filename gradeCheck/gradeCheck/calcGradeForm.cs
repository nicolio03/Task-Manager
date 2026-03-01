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
    public partial class calcGradeForm : Form
    {
        public calcGradeForm()
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
                else //everything contained in else statement utilized ChatGPT
                { 
                    double currentWeightedScore = 0;
                    double currentWeight = 0;

                    double finalWeightedScore = 0;
                    double finalWeight = 0;

                    var lines = File.ReadAllLines(matchedFile);


                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length < 1) {
                            continue; }

                        string category = parts[0];

                        int lp = category.IndexOf('(');
                        int semi = category.IndexOf(';', lp + 1);
                        int rp = category.IndexOf(')', lp + 1);

                        if (lp == -1 || rp == -1) continue;

                        // weight is between '(' and ';' (or ')' if no ';')
                        int weightEnd = (semi != -1 && semi < rp) ? semi : rp;
                        string weightPart = category.Substring(lp + 1, weightEnd - lp - 1)
                                                   .Replace("%", "")
                                                   .Trim();

                        if (!double.TryParse(weightPart, System.Globalization.NumberStyles.Any,
                            System.Globalization.CultureInfo.InvariantCulture, out double weight))
                        {
                            continue;
                        }

                        // drop flag is between ';' and ')'
                        bool drop = false;
                        string dropStr;
                        if (semi != -1 && semi < rp)
                        {
                            dropStr = category.Substring(semi + 1, rp - semi - 1).Trim();
                            drop = dropStr.Equals("Yes", StringComparison.OrdinalIgnoreCase);
                        }

                        List<double> grades = new List<double>();
                        for (int i = 1; i < parts.Length; i++)
                        {
                            if (double.TryParse(parts[i], out double g))
                            {
                                grades.Add(g);
                            }
                        }

                        if (drop && grades.Count > 0)
                        {
                            double min = grades.Min();
                            grades.Remove(min);
                        }

                        double categoryAvg = grades.Count > 0 ? grades.Average() : 0;
                        finalWeightedScore += categoryAvg * (weight/100);
                        finalWeight += weight;

                        if (grades.Count > 0)
                        {
                            currentWeightedScore += categoryAvg * (weight / 100);
                            currentWeight += weight;
                        }

                    }

                    double currentGrade = currentWeight>0 ? currentWeightedScore/(currentWeight/100):0;
                    double finalGrade = finalWeight > 0 ? finalWeightedScore / (finalWeight / 100) : 0;


                    MessageBox.Show("Final weight = " + finalWeight);

                    MessageBox.Show("Final Grade: " + finalGrade + "\nCurrent Grade: "+ currentGrade);
                }
            }
            this.Close();
        }
    }
}
