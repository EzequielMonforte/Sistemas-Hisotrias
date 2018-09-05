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

namespace Sistemas
{
	/// <summary>
	/// Lógica de interacción para Usuario_menu_principal.xaml
	/// </summary>
	public partial class Usuario_menu_principal : Window
	{
		
		public Usuario_menu_principal(string[] datos,SqlConnection conexion)
		{
			
			
			InitializeComponent();
			//configurar tamnos
			this.Height = SystemParameters.PrimaryScreenHeight;
			this.Width = SystemParameters.PrimaryScreenWidth / 2;
			this.Left = SystemParameters.PrimaryScreenWidth / 2 - this.Width / 2;
			this.Top = 0;
			//cargar tabla sql
			TablaSql a = new TablaSql(conexion, "select * from historiaCl");
			grid.Children.Add(a);
			
			//sett datos en controles
			this.nombre.Content = datos[1]+" "+ datos[2];
			
			
			
			
		}

	

		}
}			
			

