namespace gradeCheck
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            calcGradeForm checkGradeForm = new calcGradeForm();
            checkGradeForm.Show();
        }

        private void addSemesterButton_Click(object sender, EventArgs e)
        {
            addSemester addSemesterForm = new addSemester(); // Create the form
            addSemesterForm.Show();
        }

        private void removeSemesterButton_Click(object sender, EventArgs e)
        {
            removeSemesterForm removeSemesterForm = new removeSemesterForm();
            removeSemesterForm.Show();
        }

        private void Start_Load(object sender, EventArgs e)
        {
        }

        private void addClassButton_Click(object sender, EventArgs e)
        {
            addClassForm addGrade = new addClassForm();
            addGrade.Show();
        }

        private void removeClassButton_Click(object sender, EventArgs e)
        {
            removeClassForm removeClassForm = new removeClassForm();
            removeClassForm.Show();
        }

        private void addGradeButtom_Click(object sender, EventArgs e)
        {
            addGradeForm addGradeForm = new addGradeForm();
            addGradeForm.Show();
        }

        private void removeGradeButton_Click(object sender, EventArgs e)
        {
            removeGradeForm removeGradeForm = new removeGradeForm();
            removeGradeForm.Show();
        }

        private void displayGradeButton_Click(object sender, EventArgs e)
        {
            displayGradeForm displayGradeForm = new displayGradeForm();
            displayGradeForm.Show();
        }

        private void calculateGPA_Click(object sender, EventArgs e)
        {
            string gradesFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Grades");

            if (!Directory.Exists(gradesFolder))
            {
                MessageBox.Show("Grades folder does not exist.");
                return;
            }

            string[] csvFiles = Directory.GetFiles(gradesFolder, "*.csv", SearchOption.AllDirectories);

            if (csvFiles.Length == 0)
            {
                MessageBox.Show("No class files found.");
                return;
            }

            // Group by base course name (to handle retakes)
            var latestCourses = csvFiles
                .Select(path => new
                {
                    Path = path,
                    BaseName = GetBaseCourseName(Path.GetFileNameWithoutExtension(path))
                })
                .GroupBy(x => x.BaseName)
                .Select(g => g.OrderBy(x => x.Path).Last()) // Most recent retake
                .ToList();

            double totalWeightedGPA = 0;
            double totalCredits = 0;

            foreach (var course in latestCourses)
            {
                string filePath = course.Path;
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                int credit = GetCreditFromFileName(fileName);
                if (credit <= 0) continue;

                double finalWeightedScore = 0;
                double finalWeight = 0;
                bool hasIncompleteCategory = false;

                var lines = File.ReadAllLines(filePath);

                if (lines.Length == 1 && lines[0].Trim().Length == 1) // Likely a letter grade
                {
                    string letter = lines[0].Trim().ToUpper();
                    double gpa = ConvertLetterToGPA(letter);
                    totalWeightedGPA += gpa * credit;
                    totalCredits += credit;
                    continue; // Skip the rest of the loop
                }

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length < 1) continue;

                    string category = parts[0];
                    int start = category.IndexOf('(');
                    int end = category.IndexOf(')');

                    if (start == -1 || end == -1) continue;

                    string weightStr = category.Substring(start + 1, end - start - 1).Replace("%", "");
                    if (!double.TryParse(weightStr, out double weight)) continue;

                    List<double> grades = new List<double>();
                    for (int i = 1; i < parts.Length; i++)
                    {
                        if (double.TryParse(parts[i], out double g))
                        {
                            grades.Add(g);
                        }
                    }

                    if (grades.Count == 0) { 
                        hasIncompleteCategory = true;
                        break;
                    }

                    double categoryAvg = grades.Count > 0 ? grades.Average() : 0;
                    finalWeightedScore += categoryAvg * (weight / 100);
                    finalWeight += weight;
                }
                if (hasIncompleteCategory)
                {
                    MessageBox.Show("Skipped course with incomplete category: " + Path.GetFileName(filePath));
                    continue;
                }

                if (finalWeight > 0)
                {
                    double finalGrade = finalWeightedScore / (finalWeight / 100);
                    double gpa = ConvertToGPA(finalGrade);
                    totalWeightedGPA += gpa * credit;
                    totalCredits += credit;
                }
            }

            if (totalCredits > 0)
            {
                double averageGPA = totalWeightedGPA / totalCredits;
                MessageBox.Show("Overall GPA: " + averageGPA.ToString("0.00"));
            }
            else
            {
                MessageBox.Show("No valid courses or credits to calculate GPA.");
            }
        }

        private string GetBaseCourseName(string fileName)
        {
            int index = fileName.IndexOf('(');
            return index > 0 ? fileName.Substring(0, index).Trim() : fileName.Trim();
        }

        private int GetCreditFromFileName(string fileName)
        {
            int start = fileName.IndexOf('(');
            int semi = fileName.IndexOf(';', start + 1);
            int end = fileName.IndexOf(')',start+1);

            if (start == -1 || end == -1);

            int weightEnd = (semi != -1 && semi < end) ? semi : end;

            string weightPart = fileName.Substring(start + 1, weightEnd - start - 1)
                                       .Replace("%", "")
                                       .Trim();

            if (!double.TryParse(weightPart, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out double weight));

            string creditStr = fileName.Substring(start + 1, end - start - 1).Trim();
            return int.TryParse(creditStr, out int credit) ? credit : 0;
        }

        private double ConvertToGPA(double grade)
        {
            if (grade >= 90) return 4.0;
            else if (grade >= 80) return 3.0;
            else if (grade >= 70) return 2.0;
            else if (grade >= 60) return 1.0;
            else return 0.0;
        }

        private double ConvertLetterToGPA(string letter)
        {
            return letter switch
            {
                "A" => 4.0,
                "B" => 3.0,
                "C" => 2.0,
                "D" => 1.0,
                "F" => 0.0,
                _ => 0.0 // fallback for unrecognized letter
            };
        }

    }
}
