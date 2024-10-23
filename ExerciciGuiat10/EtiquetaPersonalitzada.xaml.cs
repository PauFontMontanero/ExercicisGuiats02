using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExerciciGuiat10
{
    /// <summary>
    /// Lógica de interacción para EtiquetaPersonalitzada.xaml
    /// </summary>
    public partial class EtiquetaPersonalitzada : UserControl
    {
        public EtiquetaPersonalitzada()
        {
            InitializeComponent();
            this.MouseEnter += Contorn_MouseEnter;
            //this.MouseLeave += Contorn_MouseLeave;
        }
        public string Text
        {
            get => TextEtiqueta.Text;
            set => TextEtiqueta.Text = value;
        }

        public Brush TextColor
        {
            get => TextEtiqueta.Foreground;
            set => TextEtiqueta.Foreground = value;
        }

        public double BorderWidth
        {
            get => Contorn.BorderThickness.Left;
            set => Contorn.BorderThickness = new Thickness(value);
        }

        private void Contorn_MouseEnter(object sender, MouseEventArgs e)
        {
            // Animació per canviar el color del contorn a blau de forma suau
            var colorAnimEnter = new ColorAnimation
            {
                To = Colors.Red,
                Duration = TimeSpan.FromSeconds(1.0),
                AutoReverse = true //Amb aquesta linia és ineccesari fer el Contorn_MouseLeave, ja que aquest atribut permet desfer el que s'ha fet anteriorment.
            };
            (Contorn.BorderBrush as SolidColorBrush)?.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimEnter);
        }

        //private void Contorn_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    // Animació per tornar el color del contorn a gris de forma suau
        //    var colorAnimLeave = new ColorAnimation
        //    {
        //        To = Colors.Gray,
        //        Duration = TimeSpan.FromSeconds(1.0),
        //    };
        //    (Contorn.BorderBrush as SolidColorBrush)?.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimLeave);
        //}
    }
}
