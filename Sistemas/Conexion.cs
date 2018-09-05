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
        bool conectado=false;
        SqlConnection conectarBd;
        ConsultasMedicos checkUser;
        

        public Conexion(string ruta)
        {
            this.servidor = ruta;
        }

        public SqlConnection getConexion()
        {
            return this.conectarBd;
        }

        public string getServidor()
        {
            return this.servidor;
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
            
            
            
                
            


    }
}
