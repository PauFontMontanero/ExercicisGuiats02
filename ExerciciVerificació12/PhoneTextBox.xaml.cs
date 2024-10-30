using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ExerciciVerificació12
{
    public partial class PhoneTextBox : UserControl
    {
        public PhoneTextBox()
        {
            InitializeComponent();
            PhoneTB.PreviewTextInput += PhoneTB_PreviewTextInput;
        }
        public string? FormatNumero
        {
            get => _formatNumero;
            set
            {
                _formatNumero = value;
            }
        }
        private string? _formatNumero;
        private void PhoneTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allow only digits and dashes, and control the position of the dashes
            var textBox = sender as TextBox;
            if (textBox == null) return;
            if (_formatNumero == "Internacional")
            {
                textBox.MaxLength = 15;
                if (Regex.IsMatch(e.Text, @"^\d$"))
                {
                    // Allow digit input only at the correct positions
                    int position = textBox.SelectionStart;
                    if (position == 7 || position == 11)
                    {
                        textBox.Text = textBox.Text.Insert(position, "-");
                        textBox.SelectionStart = position + 1;
                    }else if (position == 0)
                    {
                        textBox.Text = textBox.Text.Insert(position, "+");
                        textBox.SelectionStart = position + 1;
                    }
                    else if (position == 3)
                    {
                        textBox.Text = textBox.Text.Insert(position, " ");
                        textBox.SelectionStart = position + 1;
                    }
                    textBox.Background = Brushes.White;
                    e.Handled = false;
                }
                // Allow dashes only at positions 7 and 11
                else if (e.Text == "-" && (textBox.SelectionStart == 7 || textBox.SelectionStart == 11))
                {
                    e.Handled = false;
                }
                // Allow " " only at position 3
                else if (e.Text == " " && (textBox.SelectionStart == 3))
                {
                    e.Handled = false;
                }
                // Allow + only at position 0
                else if (e.Text == "+" && (textBox.SelectionStart == 0))
                {
                    e.Handled = false;
                }
                else
                {
                    textBox.Background = Brushes.Red;
                    e.Handled = true;
                }
            }
            else if (_formatNumero == "Nacional")
            {
                textBox.MaxLength = 11;
                if (Regex.IsMatch(e.Text, @"^\d$"))
                {
                    // Allow digit input only at the correct positions
                    int position = textBox.SelectionStart;
                    if (position == 3 || position == 7)
                    {
                        textBox.Text = textBox.Text.Insert(position, "-");
                        textBox.SelectionStart = position + 1;
                    }
                    textBox.Background = Brushes.White;
                    e.Handled = false;
                }
                // Allow dashes only at positions 3 and 7
                else if (e.Text == "-" && (textBox.SelectionStart == 3 || textBox.SelectionStart == 7))
                {
                    e.Handled = false;
                }
                else
                {
                    textBox.Background = Brushes.Red;
                    e.Handled = true;
                }
            }
            // Check if the input is a digit
            
        }
    }
}
