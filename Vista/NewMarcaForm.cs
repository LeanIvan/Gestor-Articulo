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

                if (String.IsNullOrWhiteSpace(marca) || MarcaController.ExisteMarca(marca))
                {
                    MessageBox.Show("El campo de la marca no puede estar vacío o contener solo espacios en blanco.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("no existe la marca");

                //  MessageBox.Show("Marca agregada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la marca: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
