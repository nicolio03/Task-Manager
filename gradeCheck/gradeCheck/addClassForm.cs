using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace gradeCheck
{
    public partial class addClassForm : Form
    {
        public addClassForm()
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

            //ongoingUpDown setup
            ongoingUpDown.Items.Clear();
            ongoingUpDown.Items.Add("Yes");
            ongoingUpDown.Items.Add("No");

            //creditUpDown setup
            creditUpDown.Minimum = 0;
            creditUpDown.Maximum = 10;
            creditUpDown.Increment = 1;
            creditUpDown.DecimalPlaces = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Are you sure you want to continue?",
            "Confirm Choice",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes) {
                string season = seasonUpDown.Text;
                int year = (int)yearUpDown.Value;

                string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Grades");
                string fileName = season + year;
                string folderPath = Path.Combine(folder, fileName);
                string ongoing = ongoingUpDown.Text;

                if (!Directory.Exists(folderPath))
                {
                    MessageBox.Show("Semester does not exist.");
                }
                else
                {
                    string name = textBox4.Text;
                    int credit = (int)creditUpDown.Value;
                    string filePath = Path.Combine(folderPath , name +"("+credit+")"+ ".csv");
                    if (!File.Exists(filePath))
                    {
                        if (ongoing == "Yes")
                        {
                            using (addCategoryForm addCategoryForm = new addCategoryForm())
                            {
                                var categoryDialog = addCategoryForm.ShowDialog();

                                if (categoryDialog == DialogResult.OK)
                                {
                                    List<string> categories = addCategoryForm.Categories;

                                    using (StreamWriter writer = new StreamWriter(filePath))
                                    {
                                        foreach (string category in categories)
                                        {
                                            writer.WriteLine(category);
                                        }
                                    }
                                    MessageBox.Show("Class created!");
                                }
                                else
                                {
                                    MessageBox.Show("Class creation canceled.");
                                }

                            }
                        }
                        else
                        {
                            addClassForm2 form2 = new addClassForm2(filePath);
                            form2.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Class already exists.");
                    }
                }
                this.Close();
            }
        }
    }
}
