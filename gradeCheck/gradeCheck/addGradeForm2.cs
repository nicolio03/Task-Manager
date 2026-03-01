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
    public partial class addGradeForm2 : Form
    {
        private string filePath;
        public addGradeForm2(string path)
        {
            InitializeComponent();
            filePath = path;
            List<string> Categories = LoadFile();

            categoryUpDown.Items.Clear();
            foreach (string category in Categories)
            {
                categoryUpDown.Items.Add(category);
            }

            gradeUpDown.Minimum = 0;
            gradeUpDown.Maximum = 100;
            gradeUpDown.Value = 0;
            gradeUpDown.Increment = 1;
            gradeUpDown.DecimalPlaces = 2;
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
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Are you sure you want to continue?",
            "Confirm Choice",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                List<string> lines = File.ReadAllLines(filePath).ToList();

                for (int i = 0; i < lines.Count; i++)
                {
                    string[] parts = lines[i].Split('(');

                    if (parts[0] == categoryUpDown.Text)
                    {
                        lines[i] += "," + gradeUpDown.Value;
                        break;
                    }

                }

                File.WriteAllLines(filePath, lines);
                MessageBox.Show("Grade added successfully!");
            }
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
