using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Data;
using System.Timers;

namespace Sistemas.Controles
{
	class TablaSql:DataGrid
	{
		SqlDataAdapter dataAdapter;
		SqlDataAdapter actualizador;
		DataSet ds;
		Timer contadorTiempo;
		SqlConnection conexion;
		string consulta;


		
	
		public TablaSql(SqlConnection conexion, string consulta)
		{
			dataAdapter = new SqlDataAdapter(consulta, conexion);
			ds = new DataSet();
			this.conexion = conexion;
			this.consulta = consulta;
			ConectarSql(conexion, consulta);
			DisenarTabla();
			contadorTiempo = new Timer(10000);
			contadorTiempo.Enabled = true;
			contadorTiempo.Elapsed += eventoIntervalo;
			this.IsReadOnly = true;
			this.CanUserResizeColumns = false;
			this.RowBackground = Brushes.LightSkyBlue;
			

			
		}	

		

		public void eventoIntervalo(object sender, ElapsedEventArgs e)
		{
		

		}

		private void DisenarTabla()
		{
			
		}

		private void ConectarSql(SqlConnection conexion, string consulta)
		{
						
			dataAdapter.Fill(ds);
			
			this.ItemsSource = ds.Tables[0].DefaultView;
			this.ColumnWidth = DataGridLength.Auto;
			
		}
	}
}






