using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExerciciVerificació12
{
    public partial class PhoneTextBox : UserControl
    {
        public PhoneTextBox()
        {
            InitializeComponent();
            PhoneTB.PreviewTextInput += PhoneTB_PreviewTextInput;
        }

        private void PhoneTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allow only digits and dashes, and control the position of the dashes
            var textBox = sender as TextBox;
            if (textBox == null) return;

            // Check if the input is a digit
            if (Regex.IsMatch(e.Text, @"^\d$"))
            {
                // Allow digit input only at the correct positions
                int position = textBox.SelectionStart;
                if (position == 3 || position == 7)
                {
                    textBox.Text = textBox.Text.Insert(position, "-");
                    textBox.SelectionStart = position + 1;
                }
                e.Handled = false;
            }
            // Allow dashes only at positions 3 and 7
            else if (e.Text == "-" && (textBox.SelectionStart == 3 || textBox.SelectionStart == 7))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
