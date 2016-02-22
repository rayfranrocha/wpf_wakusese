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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_wakusese.src.main.viewControl.userControls
{
    /// <summary>
    /// Interaction logic for BotaoTelaPrincipal.xaml
    /// </summary>
    public partial class BotaoTelaPrincipal : UserControl
    {
        public string Titulo
        {
            get { return (string)GetValue(TituloProperty); }
            set { SetValue(TituloProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Titulo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TituloProperty =
            DependencyProperty.Register("Titulo", typeof(string), typeof(BotaoTelaPrincipal), new PropertyMetadata("No Title"));



        public ImageSource Imagem
        {
            get { return (ImageSource)GetValue(ImagemProperty); }
            set { SetValue(ImagemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Imagem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImagemProperty =
            DependencyProperty.Register("Imagem", typeof(ImageSource), typeof(BotaoTelaPrincipal), new PropertyMetadata(null));

        public event EventHandler Click;

        public BotaoTelaPrincipal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Click != null)
            {
                Click(sender, e);
            }

        }
    }
}
