using Controlador;
using Modelo;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class NewMarcaForm : Form
    {

        MarcaController MarcaController;

        public NewMarcaForm()
        {
            MarcaController = new MarcaController();
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {
           
            try
            {
                string marca = (string)txtBoxMarca.Text;

                if (String.IsNullOrWhiteSpace(marca) || MarcaController.ExisteMarca(marca) || ContieneNumeros(marca))
                {
                    MessageBox.Show("El campo de la marca no puede estar vacío o contener solo espacios en blanco o numeros.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

              MarcaController.InsertarMarca(marca);
                DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la marca: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private bool ContieneNumeros(string cad)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(cad, @"\d");
        }





    }
}
