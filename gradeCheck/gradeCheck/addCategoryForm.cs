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
    public partial class addCategoryForm : Form
    {
        public List <string> Categories { get; private set; } = new List <string> ();
        public addCategoryForm()
        {
            InitializeComponent();

            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 100;
            numericUpDown1.Value = 0;
            numericUpDown1.Increment = 1;
            numericUpDown1.DecimalPlaces = 1;

            domainUpDown1.Items.Clear ();
            domainUpDown1.Items.Add("Yes");
            domainUpDown1.Items.Add("No");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cat = textBox3.Text;
            float precent = (float)numericUpDown1.Value;
            string drop= domainUpDown1.Text;
            if (drop == "")
            {
                drop = "No";
            }
            string category = cat + "(" + precent + ";"+drop+")";
            Categories.Add(category);

                DialogResult result = MessageBox.Show(
                "Would you like to add another category?",
                "Confirm Choice",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                textBox3.Clear();
                numericUpDown1.Value = 0;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
