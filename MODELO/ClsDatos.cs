using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace MODELO
{
     public class ClsDatos
    {
        #region Declaracion de variables

        SqlConnection cnnConexion = null;
        SqlCommand cmdComando = null;
        SqlDataAdapter daAdaptador = null;
        DataTable Dtt = null;
        string strCadenaConexion = string.Empty;
        #endregion


        #region Cadena de Conexion(Constructor)
        public ClsDatos()
        {

            this.strCadenaConexion = @"Data Source=SALA403-20\SQLEXPRESS;Initial Catalog=Tratamientos;Integrated Security=True";


        }

        #endregion


        public DataTable RetornarTabla(SqlParameter[] parParametros, string parTSQL)
        {

            Dtt = null;
            try
            {
                Dtt = new DataTable();
                cnnConexion = new SqlConnection(strCadenaConexion);
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.CommandText = parTSQL;


                if (parParametros != null)
                {

                    cmdComando.Parameters.AddRange(parParametros);
                }





                daAdaptador = new SqlDataAdapter(cmdComando);
                daAdaptador.Fill(Dtt);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
                daAdaptador.Dispose();
            }
            return Dtt;
        }


        public void EjecutaSP(SqlParameter[] parametros, string spNombre)
        {

            try
            {

                cnnConexion = new SqlConnection(strCadenaConexion);
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                cnnConexion.Open();
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.CommandText = spNombre;
                cmdComando.Parameters.AddRange(parametros);
                cmdComando.ExecuteNonQuery();

            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);

            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();

            }
        }
    }
}
