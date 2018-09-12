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
using System.Data.SqlClient;
using System.Data;
using Sistemas.Controles;
using Sistemas.Paginas.MenuUsuario;


namespace Sistemas
{
	/// <summary>
	/// Lógica de interacción para Usuario_menu_principal.xaml
	/// </summary>
	public partial class Usuario_menu_principal : Window
	{
		SqlConnection conexion;
		string[] datos;

		public Usuario_menu_principal(string[] datos, SqlConnection conexion)
		{

			InitializeComponent();
			this.datos = datos;
			this.conexion = conexion;
			this.Height = SystemParameters.PrimaryScreenHeight;
			this.Width = SystemParameters.PrimaryScreenWidth / 2;
			this.Left = SystemParameters.PrimaryScreenWidth / 2 - this.Width / 2;
			this.Top = 0;
			MenuPrincipal menu = new MenuPrincipal(datos, conexion);
			contendorPaginas.Navigate(menu);
			
		}

		
	}
}			
			

