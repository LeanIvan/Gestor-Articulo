using Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class NewCategoryForm : Form
    {

        private CategoriaController controller;

        public NewCategoryForm()
        {
            InitializeComponent();
            
            controller = new CategoriaController();

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

                string categoria = (string)textBoxCategoria.Text;

                if (String.IsNullOrWhiteSpace(categoria) || controller.ExisteCategoria(categoria) || ContieneNumeros(categoria))
                {
                    MessageBox.Show("El campo de la categoria no puede estar vacío o contener solo espacios en blanco.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);             
                    return;
                }
             
                controller.InsertarCategoria(categoria);
                this.DialogResult= DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la categoria: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }





        private bool ContieneNumeros(string cad)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(cad, @"\d");
        }



    }
}
