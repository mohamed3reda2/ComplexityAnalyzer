using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace ComplexityAnalyzer
{
    public partial class MainWindow : Window
    {
        public string Name, Email;
        DateTime logtime;
        ComplexityAnalyzerDBEntities ComplexityEntities = new ComplexityAnalyzerDBEntities();

        public MainWindow(string name, string email ,DateTime date)
        {
            InitializeComponent();
            Name = name;
            Email = email;
            logtime = date;
        }

        private void AnalyzeButton_Click(object sender, RoutedEventArgs e)
        {
            string code = CodeInput.Text;

            if (string.IsNullOrWhiteSpace(code))
            {
                OutputTextBlock.Text = "Please enter valid C++ code.";
                return;
            }

            string complexityAnalysis = AnalyzeComplexity(code);

            OutputTextBlock.Text = complexityAnalysis;
            MessageBox.Show("The Time Complexity analysis is done!", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string code = CodeInput.Text;

            if (string.IsNullOrWhiteSpace(code))
            {
                OutputTextBlock.Text = "Please enter valid C++ code.";
                return;
            }

   
            int questionNumber = int.Parse(((ComboBoxItem)QuestionComboBox.SelectedItem).Content.ToString());

    
            var userSubmission = ComplexityEntities.UserSubmissions.FirstOrDefault(u => u.Name == Name && u.Email == Email);

            if (userSubmission == null)
            {
       
                userSubmission = new UserSubmission
                {
                    Name = Name,
                    Email = Email,
                    starttime=logtime,
                };
                ComplexityEntities.UserSubmissions.Add(userSubmission);
                ComplexityEntities.SaveChanges();
            }

         
            switch (questionNumber)
            {
                case 1:
                    userSubmission.Code1 = code;
                    break;
                case 2:
                    userSubmission.Code2 = code;
                    break;
                case 3:
                    userSubmission.Code3 = code;
                    break;
                case 4:
                    userSubmission.Code4 = code;
                    break;
                case 5:
                    userSubmission.Code5 = code;
                    break;
            }
            userSubmission.SubmissionDate = DateTime.Now;
            userSubmission.totaltime = (DateTime.Now - logtime ).Minutes;
            ComplexityEntities.SaveChanges();
            OutputTextBlock.Text = $"Code for Question {questionNumber} has been submitted/updated successfully.";

            MessageBox.Show("The code has been submitted successfully!", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private string AnalyzeComplexity(string code)
        {
            int simpleLoops = Regex.Matches(code, @"\b(for|while)\b").Count;
            bool isLogarithmic = Regex.IsMatch(code, @"\b\w+\s*(/|>>)=\s*2");
            int nestedLoops = Regex.Matches(code, @"\b(for|while)\b[^{}]*\{[^{}]*(\b(for|while)\b)").Count;
            string timeComplexity = "O(1)";
            if (isLogarithmic)
            {
                timeComplexity = "O(log n)";
            }
            else if (nestedLoops > 0)
            {
                timeComplexity = "O(n^" + (nestedLoops + 1) + ")";
            }
            else if (simpleLoops > 0)
            {
                timeComplexity = "O(n)";
            }

            string spaceComplexity = "O(1)";
            return $"Final Time Complexity: {timeComplexity}\nFinal Space Complexity: {spaceComplexity}";
        }
    }
}
