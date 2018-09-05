using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace Sistemas
{
    class ConsultasMedicos
    {
        SqlCommand comando;
        public ConsultasMedicos()
        {
            
        }

        public string QuerydatosMedico(string apellido, string matricula)
        {
            string query;
            query = "select * from medico where apellido='" + apellido + "' and matricula='" + matricula + "';";
            return query;
        }
        public string[] realizarConsulta(string query, SqlConnection servidor)
        {
            string[] datos = new string[5];
            comando = new SqlCommand();
			comando.CommandText = query;
			comando.CommandType = CommandType.Text;
			comando.Connection = servidor;
			SqlDataReader reader;
            reader = comando.ExecuteReader();
				while (reader.Read())
				{
					datos[0] = reader["id"].ToString();
					datos[1] = reader["nombre"].ToString();
					datos[2] = reader["apellido"].ToString();
					datos[3] = reader["matricula"].ToString();
					datos[4] = reader["provincia_id"].ToString();
				}
				reader.Close();
			return datos;

        }
    }
}
			
			
			
