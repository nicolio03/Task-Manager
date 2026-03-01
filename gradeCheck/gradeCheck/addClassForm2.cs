using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradeCheck
{
    public partial class addClassForm2 : Form
    {
        private string filePath;
        public addClassForm2(string path)
        {
            InitializeComponent();

            filePath = path;

            gradeUpDown.Items.Clear();
            gradeUpDown.Items.Add("A");
            gradeUpDown.Items.Add("B");
            gradeUpDown.Items.Add("C");
            gradeUpDown.Items.Add("D");
            gradeUpDown.Items.Add("F");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string grade = gradeUpDown.Text;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(grade);

                }

            this.Close();
        }
    }
}
