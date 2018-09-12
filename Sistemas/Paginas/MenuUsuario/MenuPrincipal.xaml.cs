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
using Sistemas.Controles;
using Sistemas.Properties;
using System.Data.SqlClient;
using Sistemas.Paginas.MenuUsuario;
using System.Globalization;

namespace Sistemas.Paginas.MenuUsuario
{
	/// <summary>
	/// Lógica de interacción para MenuPrincipal.xaml
	/// </summary>
	public partial class MenuPrincipal : Page
	{
		TablaSql a;
		SqlConnection conexion;
		Conexion consultas;
		TextInfo maysuculas = new CultureInfo("es-AR", false).TextInfo;
		string[] datos;
		
		public MenuPrincipal(string[] datos, SqlConnection conexion)
		{
			InitializeComponent();
			consultas = new Conexion(conexion.ConnectionString);
			this.datos = datos;
			this.conexion = conexion;
			//cargar tabla sql segun usuario
			GenerarTabla();
			MostrarDatosUsuario();
			





		}

		private void MostrarDatosUsuario()
		{
			string tipoUsuario = consultas.VerTipoUsuario(datos[5]);
			medicoNombre.Content = $"{maysuculas.ToTitleCase(datos[1])} {maysuculas.ToTitleCase(datos[2])} ({tipoUsuario})";
			contadorHistorias.Content = consultas.Contar("historiaCl", datos[0]);
		}

		private void GenerarTabla()
		{
			if (datos[5] == "1") //si usuario es medico
			{
				a = new TablaSql(conexion, "select id as ID, fecha as 'Fecha de registro', (select apellido from medico where id= historiaCl.medico)as Medico, " +
					"(select(nombre+space(1)+apellido) from paciente where nroAf=historiaCl.paciente)as Paciente, paciente as 'Nro afiliado' from historiaCl where medico= " + datos[0] + " order by fecha");
				a.Width = this.Width;
				Grid.SetColumn(a, 0);
				Grid.SetRow(a, 1);
				Grid.SetColumnSpan(a, 4);
				Grid.SetRowSpan(a, 2);
				grid.Children.Add(a);

			}
			else if (datos[5] == "2")
			{
				a = new TablaSql(conexion, "select id as ID, fecha as 'Fecha de registro', (select apellido from medico where id= historiaCl.medico)as Medico, " +
					"(select(nombre+space(1)+apellido) from paciente where nroAf=historiaCl.paciente)as Paciente, paciente as 'Nro afiliado' from historiaCl");
				Grid.SetColumn(a, 0);
				Grid.SetRow(a, 1);
				Grid.SetColumnSpan(a, 4);
				grid.Children.Add(a);

			}

		}

		private void nuevaHistoria_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new PagLlenarHisotria(this.datos));
			NavigationService.RemoveBackEntry();

		}
	}
}
