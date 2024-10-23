using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace ExerciciVerificació10
{
    public partial class GaleriaImatges : UserControl
    {
        private int _index = 0;
        private List<string> _imatges = new List<string>();
        private DispatcherTimer _timer;
        private int _time;

        public GaleriaImatges()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Tick += Timer_Tick;
        }

        public string? DirectoriImatges
        {
            get => _directoriImatges;
            set
            {
                _directoriImatges = value;
                CarregarImatgesDelDirectori();
            }
        }
        private string? _directoriImatges;

        public string? PasDeImatges
        {
            get => _pasDeImatges;
            set
            {
                _pasDeImatges = value;
                if (_pasDeImatges == "Auto")
                {
                    _timer.Start();
                }
                else if (_pasDeImatges == "Manual")
                {
                    _timer.Stop();
                }
            }
        }
        private string? _pasDeImatges;

        public string? TempsDeTransició
        {
            get => _tempsDeTransició;
            set
            {
                _tempsDeTransició = value;
                if (int.TryParse(_tempsDeTransició, out _time))
                {
                    _timer.Interval = TimeSpan.FromSeconds(_time);
                }
                else
                {
                    MessageBox.Show("Invalid time format for TempsDeTransició.");
                }
            }
        }
        private string? _tempsDeTransició;

        private void CarregarImatgesDelDirectori()
        {
            if (string.IsNullOrEmpty(_directoriImatges)) return;
            var rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _directoriImatges);

            if (Directory.Exists(rutaCompleta))
            {
                _imatges = new List<string>(Directory.GetFiles(rutaCompleta, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                   file.EndsWith(".png", StringComparison.OrdinalIgnoreCase)));

                if (_imatges.Count > 0)
                {
                    _index = 0;
                    CarregarImatge();
                }
                else
                {
                    MessageBox.Show("No s'han trobat imatges a la carpeta especificada.");
                }
            }
            else
            {
                MessageBox.Show("El directori especificat no existeix.");
            }
        }

        private void CarregarImatge()
        {
            if (_imatges.Count == 0) return;

            Imatge.Source = new BitmapImage(new Uri(_imatges[_index], UriKind.Absolute));
            var anim = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5));
            Imatge.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void Anterior_Click(object sender, RoutedEventArgs e)
        {
            if (_imatges.Count == 0) return;
            _index = (_index - 1 + _imatges.Count) % _imatges.Count;
            CarregarImatge();
        }

        private void Següent_Click(object sender, RoutedEventArgs e)
        {
            if (_imatges.Count == 0) return;
            _index = (_index + 1) % _imatges.Count;
            CarregarImatge();
        }

        private void PasDeImatge()
        {
            if (_imatges.Count == 0) return;
            _index = (_index + 1) % _imatges.Count;
            CarregarImatge();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            PasDeImatge();
        }

        private void Imatge_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (PasDeImatges == "Manual")
            {
                PasDeImatges = "Auto";
            }
            else
            {
                PasDeImatges = "Manual";
            }
        }
    }
}
