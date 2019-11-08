using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;

namespace CONTROLADOR
{
    public class PacienteDTO
    {
        private int Id;
        private string Nombre;
        private string Apellido;
        private DateTime FechaNacimiento;
        private string Sexo;

        #region Set - Get Id

        public void setId(int valor)
        {
            this.Id = valor;
        }

        public int getId()
        {
            return this.Id;
        }

        #endregion

        #region Set - Get Nombre
        public void setNombre(string valor)
        {
            this.Nombre = valor;
        }

        public string getNombre()
        {
            return this.Nombre;
        }
        #endregion

        #region Set - Get Apellido
        public void setApellido(string valor)
        {
            this.Apellido = valor;
        }

        public string getApellido()
        {
            return this.Apellido;
        }
        #endregion

        #region Set - Get FechaNacimiento
        public void setFechaNacimiento(DateTime valor)
        {
            this.FechaNacimiento = valor;
        }

        public DateTime getFechaNacimiento()
        {
            return this.FechaNacimiento;
        }
        #endregion

        #region Set - Get Sexo
        public void setSexo(string valor)
        {
            this.Sexo = valor;
        }

        public string getSexo()
        {
            return this.Sexo;
        }
        #endregion
    }
}
