using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;
using System.Data;
using System.Data.SqlClient;

namespace CONTROLADOR
{
   public class PacienteDAO
    {
        ClsDatos clsDatos = null;
        PacienteDTO pacienteDTO = null;
        DataTable listaDatos = null;

        public PacienteDAO(PacienteDTO pacienteDTO)
        {
            this.pacienteDTO = pacienteDTO;
        }


        public DataTable ListarPaciente()
        {
            listaDatos = new DataTable();

            try
            {
                clsDatos = new ClsDatos();
                SqlParameter[] parametros = null;

                if (this.pacienteDTO == null)
                {

                    parametros = new SqlParameter[5];

                    parametros[0] = new SqlParameter();
                    parametros[0].ParameterName = "@id";
                    parametros[0].SqlDbType = SqlDbType.Int;
                    parametros[0].SqlValue = pacienteDTO.getId();

                    parametros[1] = new SqlParameter();
                    parametros[1].ParameterName = "@Nombre";
                    parametros[1].SqlDbType = SqlDbType.VarChar;
                    parametros[1].Size = 50;
                    parametros[1].SqlValue = pacienteDTO.getNombre();

                    parametros[2] = new SqlParameter();
                    parametros[2].ParameterName = "@Apellido";
                    parametros[2].SqlDbType = SqlDbType.VarChar;
                    parametros[2].Size = 50;
                    parametros[2].SqlValue = pacienteDTO.getApellido();

                    parametros[3] = new SqlParameter();
                    parametros[3].ParameterName = "@FechaNacimiento";
                    parametros[3].SqlDbType = SqlDbType.DateTime;
                    parametros[3].SqlValue = pacienteDTO.getFechaNacimiento();

                    parametros[4] = new SqlParameter();
                    parametros[4].ParameterName = "@Sexo";
                    parametros[4].SqlDbType = SqlDbType.VarChar;
                    parametros[4].Size = 50;
                    parametros[1].SqlValue = pacienteDTO.getSexo();

                }
                else
                {

                    parametros = null;
                }

                listaDatos = clsDatos.RetornarTabla(parametros, "spConsultaPaises");
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return listaDatos;
        }

        public void GuardarPaciente()
        {

            try
            {
                clsDatos = new ClsDatos();
                SqlParameter[] parametro = new SqlParameter[4];

                parametro[0] = new SqlParameter();
                parametro[0].ParameterName = "@Nombre";
                parametro[0].SqlDbType = SqlDbType.VarChar;
                parametro[0].Size = 50;
                parametro[0].SqlValue = pacienteDTO.getNombre();

                parametro[1] = new SqlParameter();
                parametro[1].ParameterName = "@Apellido";
                parametro[1].SqlDbType = SqlDbType.VarChar;
                parametro[1].Size = 50;
                parametro[1].SqlValue = pacienteDTO.getApellido();

                parametro[2] = new SqlParameter();
                parametro[2].ParameterName = "@FechaNacimiento";
                parametro[2].SqlDbType = SqlDbType.DateTime;
                parametro[2].SqlValue = pacienteDTO.getFechaNacimiento();

                parametro[3] = new SqlParameter();
                parametro[3].ParameterName = "@Sexo";
                parametro[3].SqlDbType = SqlDbType.VarChar;
                parametro[3].Size = 50;
                parametro[3].SqlValue = pacienteDTO.getSexo();

                clsDatos.EjecutaSP(parametro, "spNuevoNombre");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

    }
}
