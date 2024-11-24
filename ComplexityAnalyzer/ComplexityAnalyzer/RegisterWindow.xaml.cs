using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace ComplexityAnalyzer
{
    public partial class RegisterWindow : Window
    {
        ComplexityAnalyzerDBEntities ComplexityEntities = new ComplexityAnalyzerDBEntities();
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameInput.Text.ToLower();
            string email = EmailInput.Text.ToLower();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var userSubmission = ComplexityEntities.users.FirstOrDefault(u => u.Name == name && u.Email == email);

            if (userSubmission != null) {
                MessageBox.Show("لقد تم تسجيل دخولك من قبل ", "Error", MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                user user =new user() { 
                    Name = name,
                    Email = email,
                    datelog = DateTime.Now };
                ComplexityEntities.users.Add(user);
                ComplexityEntities.SaveChanges();
                MainWindow mainWindow = new MainWindow(name, email, System.DateTime.Now);
                mainWindow.Show();
                this.Close();
            }
        }
    }
}
