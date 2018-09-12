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
using System.Data.SqlClient;
using Sistemas.Paginas.MenuUsuario;

namespace Sistemas.Paginas
{
	/// <summary>
	/// Lógica de interacción para PagLlenarHisotria.xaml
	/// </summary>
	public partial class PagLlenarHisotria : Page
	{
		
		string[] datos;
		public PagLlenarHisotria(string[] datos)
		{
			InitializeComponent();
			

			this.datos = datos;
			
		}

		private void guardar_Click(object sender, RoutedEventArgs e)
		{
			
			string[] valores = { ingFecha.Text, this.datos[0], ingAf.Text };
			Conexion consultas = new Conexion("Data Source=localhost;Initial Catalog=ecco;Integrated Security=True");
			bool insertarListo=consultas.insertHistoriaCl(valores);
			if (insertarListo)
			{
				MessageBox.Show("insertado correctamente");
				NavigationService.Navigate(new MenuPrincipal(this.datos, consultas.getConexion()));
				NavigationService.RemoveBackEntry();
			}
			else MessageBox.Show("error");
			
		}
	}
}


			
