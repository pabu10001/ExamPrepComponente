using System;
using System.Collections.Generic;
using System.IO;
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

namespace ExamenPrepComponentes.ControlesUsuario
{
    /// <summary>
    /// Interaction logic for ControlUsuario.xaml
    /// </summary>
    /// 
   
    public partial class ControlUsuario : UserControl
    {
        public String ruta { get; set; }
        private String[] fileList;
        private int pos = 0;
        private BitmapImage bitmapImage;

        public ControlUsuario()
        {
            InitializeComponent();
        }
        
        private void onClickSiguiente(object sender, RoutedEventArgs e)
        {
            if (pos == fileList.Length - 1)
            {
                pos = 0;
            }
            else
            {
                pos++;
            }
            
            cargarImagen();
            cambioColor();
        }

        private void onClickAnterior(object sender, RoutedEventArgs e)
        {
            if (pos == 0)
            {
                pos = fileList.Length - 1;
            }
            else
            {
                pos--;
            }
            cargarImagen();
            cambioColor();

        }

        public void cargarImagen()
        {
            bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(@"" + fileList[pos]);
            bitmapImage.DecodePixelWidth = 280;
            bitmapImage.EndInit();
            image.Source = bitmapImage;

            label_nombre.Content = fileList[pos];

        }

        public void cambioColor()
        {
            for (int i = 0; i < fileList.Length; i++)
            {
                if (i == pos) {
                    ((Button)stackPanel.Children[i]).Background = Brushes.Blue;
                }
                else
                {
                    ((Button)stackPanel.Children[i]).Background = Brushes.Gray;
                }
                
            }
        }

        public void stackInit()
        {
            for(int i = 0; i < fileList.Length; i++)
            {
                Button button = new Button();
                button.Height = 50;
                button.Width = stackPanel.Width / (fileList.Length);
                stackPanel.Children.Add(button);
            }
        }

        public void init()
        {
            fileList = Directory.GetFiles(@"" + ruta);

            cargarImagen();
            stackInit();
            cambioColor();
        }
    }
}
