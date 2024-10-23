using System.Windows;
using System.Windows.Controls;

namespace ExerciciVerificació09
{
    /// <summary>
    /// Lógica de interacción para Comptador.xaml
    /// </summary>
    public partial class Comptador : UserControl
    {

        public Comptador()
        {
            InitializeComponent();

        }

        public int? CounterValue
        {
            get => _counterValue;
            set
            {
                _counterValue = value;
                SetUpCounter();
            }
        }
        private int? _counterValue;

        private void BT_Comptador_Click(object sender, RoutedEventArgs e)
        {
            _counterValue++;
            value.Text = _counterValue.ToString();
        }
        private void SetUpCounter()
        {
            if (_counterValue.HasValue)
            {
                value.Text = _counterValue.Value.ToString();
            }
        }
    }
}
