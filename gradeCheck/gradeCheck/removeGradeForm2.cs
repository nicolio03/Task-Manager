using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace gradeCheck
{
    public partial class removeGradeForm2 : Form
    {
        private string filePath;
        public removeGradeForm2(string path)
        {
            InitializeComponent();
            filePath = path;

            List<string> Categories = LoadFile();

            categoryUpDown.Items.Clear();
            foreach (string category in Categories)
            {
                categoryUpDown.Items.Add(category);
            }

            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 100;
            numericUpDown1.Value = 0;
            numericUpDown1.Increment = 1;
            numericUpDown1.DecimalPlaces = 2;
        }

        private List<string> LoadFile()
        {
            List<string> firstEntries = new List<string>();
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('(');
                        if (parts.Length > 0)
                        {
                            firstEntries.Add(parts[0]);
                        }
                    }
                }
                return firstEntries;
            }
            return null;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Are you sure you want to continue?",
            "Confirm Choice",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                string category = categoryUpDown.Text;
                float gradeToRemove = (float)numericUpDown1.Value;

                List<string> lines = File.ReadAllLines(filePath).ToList();
                bool gradeRemoved = false;

                for (int i = 0; i < lines.Count; i++)
                {
                    string[]parts = lines[i].Split(",");
                    if (parts.Length > 1 && parts[0].StartsWith(category))
                    {
                        List<string> updatedParts = new List<string>();

                        updatedParts.Add(parts[0]);

                        for (int j = 1; j < parts.Length; j++)
                        {
                            if (float.TryParse(parts[j], out float grade))
                            {
                                if (Math.Abs(grade -  gradeToRemove) > 001f)
                                {
                                    updatedParts.Add(parts[j]);
                                }
                                else
                                {
                                    gradeRemoved = true;
                                }
                            }
                            else
                            {
                                updatedParts.Add(parts[j]);
                            }
                        }

                        lines[i] = string.Join(",", updatedParts);
                        break;
                    }
                }

                File.WriteAllLines(filePath, lines);

                if (gradeRemoved)
                {
                    MessageBox.Show("Grade removed successfully!");
                }
                else
                {
                    MessageBox.Show("Grade not found.");
                }

                this.Close();

            }
        }
    }
}
