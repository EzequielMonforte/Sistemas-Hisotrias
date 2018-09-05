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

namespace Sistemas.Controles
{
	class TablaSql:DataGrid
	{
		
		public TablaSql(SqlConnection conexion, string consulta)
		{
			ConectarSql(conexion, consulta);
			

		}
			

		private void ConectarSql(SqlConnection conexion, string consulta)
		{
			
			SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta, conexion);
			DataSet ds = new DataSet();
			dataAdapter.Fill(ds);
			this.ItemsSource = ds.Tables[0].DefaultView;
			this.ColumnWidth = DataGridLength.SizeToCells;
			
			
		}
	}
}
