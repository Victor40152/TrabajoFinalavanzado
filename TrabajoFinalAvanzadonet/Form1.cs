using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CONTROLADOR;
namespace TrabajoFinalAvanzadonet
{
    public partial class Form1 : Form
    {

        PacienteDAO pacienteDAO = null;
        PacienteDTO PacienteDTO = null;
        DataTable Dtt = null;

        public Form1()
        {
            InitializeComponent();
            ListarPaciente();
        }


        public void Guardar()
        {
            PacienteDTO = new PacienteDTO();
            PacienteDTO.setNombre(txtnombre.Text);
            pacienteDAO = new PacienteDAO(PacienteDTO);

            pacienteDAO.GuardarPaciente();
            MessageBox.Show("Registro Guardado");




        }
        public void ListarPaciente()
        {

            PacienteDTO = new PacienteDTO();
            pacienteDAO = new PacienteDAO(PacienteDTO);

            Dtt = new DataTable();
            Dtt = pacienteDAO.ListarPaciente();

            if (Dtt.Rows.Count > 0)
            {
                dtpacientes.DataSource = Dtt;
            }
            else
            {
                MessageBox.Show("No hay registros de Pacientes");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {


                if (txtnombre.Text.Trim() == "")
                {
                    MessageBox.Show("intenta un dato valido ");
                    txtnombre.Focus();

                }
                else
                {

                    Guardar();
                    ListarPaciente();
                    txtnombre.Clear();
                }


            }
        }
    }
}
