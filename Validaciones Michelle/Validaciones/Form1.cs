using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Validaciones
{
    public partial class RegistroPS : Form
    {
        private int nDocumento;
        public RegistroPS()
        {
            InitializeComponent();
        }

        private void RegistroPS_Load(object sender, EventArgs e)
        {
            System.Collections.Generic.List<TipoDocumento>
                tiposDocumentos = new List<TipoDocumento>();

            tiposDocumentos.Add(new TipoDocumento() { idpaciente = 1, Nombre = "Cedula de ciudadania" });
            tiposDocumentos.Add(new TipoDocumento() { idpaciente = 2, Nombre = "NUIP" });
            tiposDocumentos.Add(new TipoDocumento() { idpaciente = 3, Nombre = "Tarjeta de identidad" });
            tiposDocumentos.Add(new TipoDocumento() { idpaciente = 4, Nombre = "Tarjeta de extranjeria" });

            cbxTipoDocumento.DataSource = tiposDocumentos;
            cbxTipoDocumento.DisplayMember = "Nombre";


            System.Collections.Generic.List<Rango>
                Rango = new List<Rango>();

            Rango.Add(new Rango() { idpaciente = 1, nombre = "A" });
            Rango.Add(new Rango() { idpaciente = 2, nombre = "B" });
            Rango.Add(new Rango() { idpaciente = 3, nombre = "C" });

            cbxRango.DataSource = Rango;
            cbxRango.DisplayMember = "Nombre";



        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //El nombre no debe ser vacio
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                erpMensaje.SetError(txtNombre, " El nombre no debe ser vacio");
            }

            //El tipo de documento no puede ser vacio
            if (string.IsNullOrEmpty(cbxTipoDocumento.Text))
            {
                erpMensaje.SetError(cbxTipoDocumento, "Seleccione un tipo de documento");
            }

            //El sexo debe ser vacío

            if (string.IsNullOrEmpty(rbtnFemenino.Text))
            {
                erpMensaje.SetError(rbtnFemenino, "Seleccione algun sexo");
            }

            else
            {
                erpMensaje.SetError(rbtnFemenino, "");

            }

            if (string.IsNullOrEmpty(rbtnMasculino.Text))
            {
                erpMensaje.SetError(rbtnMasculino, "Seleccione algun sexo");
            }

            else
            {
                erpMensaje.SetError(rbtnMasculino, "");
            }

            //El  numero de documento no debe ser vacio

            if (string.IsNullOrEmpty(txtDocumento.Text))
            {
                erpMensaje.SetError(txtDocumento, "Ingrese su numero de documento");

            }
            else
            {
                erpMensaje.SetError(txtDocumento, "");

            }

            //El rango no debe ser vacio
            if (string.IsNullOrEmpty(cbxRango.Text))
            {
                erpMensaje.SetError(cbxRango, "Ingrese el rango");

            }
            else
            {
                erpMensaje.SetError(cbxRango, "");
            }

            //El numero de documento debe ser mayor a 0
            if (nDocumento <= 0)
            {
                erpMensaje.SetError(txtDocumento, "Ingrese un documento valido");
            }

            else
            {
                erpMensaje.SetError(txtDocumento, "");
            }

            //Documento NUIP debe estar entre 1000000000 y 9999999999

            if (((TipoDocumento)cbxTipoDocumento.SelectedItem).idpaciente == 2)
            {
                if (Convert.ToInt64(txtDocumento.Text) > 1000000000)
                {
                    MessageBox.Show("Ingrese un documento valido");

                }

                if (Convert.ToInt64(txtDocumento.Text) < 9999999999)
                {
                    MessageBox.Show("Ingrese un documento valido");
                }

                return;

            }



            //El costo del servicio no debe ser vacio
            if (string.IsNullOrEmpty(txtCosto.Text))
            {
                erpMensaje.SetError(txtCosto, "Ingrese el costo del servicio");

            }
            else
            {
                erpMensaje.SetError(txtCosto, "");
            }

            //Costo de servicio mayor a 0
            if ((Convert.ToInt64(txtCosto.Text) <= 0))
            {
                erpMensaje.SetError(txtCosto, "Ingrese un costo de servicio valido");
            }

            else
            {
                erpMensaje.SetError(txtCosto, "");
            }


        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double Valorpagar = 0;

            //Calcular pago para el rango A
            if (((Rango)cbxRango.SelectedItem).idpaciente == 1)
            {
                Valorpagar = (Convert.ToInt64(txtCosto.Text) - ((Convert.ToInt64(txtCosto.Text) * 0.30)));
            }

            //Calcular el pago para el rango B
            if (((Rango)cbxRango.SelectedItem).idpaciente == 2)
            {

                Valorpagar = (Convert.ToInt64(txtCosto.Text) - ((Convert.ToInt64(txtCosto.Text) * 0.20)));
            }

            //Calcular el pago para el rango C

            if (((Rango)cbxRango.SelectedItem).idpaciente == 3)
            {
                Valorpagar = (Convert.ToInt64(txtCosto.Text) - ((Convert.ToInt64(txtCosto.Text) * 0.10)));

            }

            MessageBox.Show("Debe cancelar: " + Valorpagar);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }






























        
    }

