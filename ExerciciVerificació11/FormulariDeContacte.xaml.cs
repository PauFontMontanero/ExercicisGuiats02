using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace ExerciciVerificació11
{
    public partial class FormulariDeContacte : UserControl
    {
        public FormulariDeContacte()
        {
            InitializeComponent();
        }

        private void NameValidation(object sender, TextChangedEventArgs e)
        {
            ValidateForm();
        }

        private void PhoneValidation(object sender, TextChangedEventArgs e)
        {
            ValidateForm();
        }

        private void EmailValidation(object sender, TextChangedEventArgs e)
        {
            ValidateForm();
        }

        private void ValidateForm()
        {
            bool isNameValid = !string.IsNullOrWhiteSpace(NameTextBox.Text) && NameTextBox.Text.Length >= 3;
            bool isPhoneValid = !string.IsNullOrWhiteSpace(PhoneTextBox.Text) && Regex.IsMatch(PhoneTextBox.Text, @"^\d{9}$");
            bool isEmailValid = !string.IsNullOrWhiteSpace(EmailTextBox.Text) && Regex.IsMatch(EmailTextBox.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            SendButton.IsEnabled = isNameValid && isPhoneValid && isEmailValid;
        }
    }
}
