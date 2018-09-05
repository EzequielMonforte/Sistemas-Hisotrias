using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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


namespace Sistemas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        bool flagServerConection=false;
        string apellido;
        string matricula;
        
        string[] datosMedico = new string[7];
        Conexion servidor;
        ConsultasMedicos medico = new ConsultasMedicos();
        //MySqlCommand comando;

        public MainWindow()
        {
            InitializeComponent();
			ingNom.Focus();
			//testing
			ingNom.Text = "monforte";
			ingMat.Text = "1390";
			
			
        }
        private void Button_Click(object sender, RoutedEventArgs e){
			
			 servidor = new Conexion("Data Source=localhost;Initial Catalog=ecco;Integrated Security=True");
			 this.apellido = ingNom.Text;
			 this.matricula = ingMat.Text;
			 flagServerConection = servidor.logueado(servidor.getServidor(), this.apellido, this.matricula);

			 if (flagServerConection)
			 {
				
				Usuario_menu_principal a = new Usuario_menu_principal(medico.realizarConsulta(medico.QuerydatosMedico(this.apellido, this.matricula), servidor.getConexion()), servidor.getConexion());
				a.Show();
				this.Close();
			}else if (flagServerConection== false)
			 {
				 MessageBox.Show("No se pudo conectar");
				
			 }
			
		}

		private void botlog_MouseUp(object sender, MouseButtonEventArgs e)
		{
			this.Background = Brushes.Azure;
			
		}
	}
}
