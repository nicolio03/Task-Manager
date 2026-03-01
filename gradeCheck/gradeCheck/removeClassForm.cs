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
    public partial class removeClassForm : Form
    {
        public removeClassForm()
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
                    string filePath = Path.Combine(folderPath, name + ".csv");
                    if (!File.Exists(filePath))
                    {
                        MessageBox.Show("Class does not exist.");
                    }
                    else
                    {
                        try
                        {
                            File.SetAttributes(filePath, FileAttributes.Normal);
                            File.Delete(filePath); 
                            MessageBox.Show("Class deleted successfully!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting folder: " + ex.Message);
                        }
                    }
                }
                this.Close();

            }
        }
    }
}
