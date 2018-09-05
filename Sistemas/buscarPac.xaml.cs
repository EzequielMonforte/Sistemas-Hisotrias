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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Sistemas
{
    /// <summary>
    /// Lógica de interacción para buscarPac.xaml
    /// </summary>
    public partial class buscarPac: Window
    {
        
        public buscarPac(string a, string b, string c, string d, string e, string f, string g, Window padre)
        {
            InitializeComponent();
            this.Owner = padre;
            nom.Content = a;
            ape.Content = b;
            prov.Content = c;
            mat.Content = d;
            nromo.Content = e;
            pagopa.Content = f;
            pagoto.Content = g;
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Show();
            
        }

        
    }
}
