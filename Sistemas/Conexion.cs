using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Sistemas
{
	class Conexion
	{
		string servidor;
		bool conectado = false;
		SqlConnection conectarBd;
		ConsultasMedicos checkUser;


		public Conexion(string ruta)
		{
			this.servidor = ruta;
			this.conectarBd = new SqlConnection(ruta);
		}

		public SqlConnection getConexion()
		{
			return this.conectarBd;
		}

		public string getServidor()
		{
			return this.servidor;
		}

		public string Contar(string tabla, string medico)
		{
			string cantidad = "";
			conectarBd.Open();
			SqlCommand comando = new SqlCommand("select count(*) as 'cantidad' from "+ tabla+ " where medico= "+ medico, conectarBd);
			SqlDataReader reader;
			reader = comando.ExecuteReader();
			while (reader.Read())
			{
				cantidad = reader["cantidad"].ToString();
			}
			reader.Close();
			conectarBd.Close();

			return cantidad;
		} 

        

        public bool logueado(string servidor, string ape, string mat)
        {
			string idmed;
            
            conectarBd = new SqlConnection(servidor);
			checkUser = new ConsultasMedicos();
            conectarBd.Open();
			idmed = checkUser.realizarConsulta(checkUser.QuerydatosMedico(ape, mat), conectarBd)[0];

				if (idmed == null)
                    return conectado = false;
                else 
					return conectado =true;

        }

		public string VerTipoUsuario(string id)
		{
			string tipo="";
			conectarBd.Open();
			SqlCommand comando = new SqlCommand("select tipo from tipoUsuario where idTipo= " + int.Parse(id), conectarBd);
			SqlDataReader reader;
			reader = comando.ExecuteReader();
			while (reader.Read())
			{
				tipo = reader["tipo"].ToString();
			}
				reader.Close();
			conectarBd.Close();
			return tipo;

		}

		public bool insertHistoriaCl(string[] valores)
		{
			conectarBd.Open();
			SqlCommand comando = new SqlCommand("insert into historiaCl values((select SYSDATETIME()), " + valores[1] + ", '" + valores[2] + "')", this.conectarBd);
			int nroFilasDevueltas=comando.ExecuteNonQuery();
			conectarBd.Close();
			if (nroFilasDevueltas > 0)
				return true;
			else return false;

		}




            
            
            
                
            


    }
}
