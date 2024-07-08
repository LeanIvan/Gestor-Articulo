using Controlador;
using Modelo;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vista
{
    public partial class EditForm : Form
    {
        ProductoController controller;


        public EditForm(Articulo art)
        {
            {
                InitializeComponent();

                controller = new ProductoController();


                btnAceptar.MouseEnter += new EventHandler(btn_MouseEnter);
                btnAceptar.MouseLeave += new EventHandler(btn_MouseLeave);
                btnCancelar.MouseEnter += new EventHandler(btn_MouseEnter);
                btnCancelar.MouseLeave += new EventHandler(btn_MouseLeave);
                btnAceptar.Click += new EventHandler(btnAceptar_Click);
                btnCancelar.Click += new EventHandler(btnCancelar_Click);

                /// txtBox

                this.txtCodigo.Text = art.Codigo;
                this.txtNombre.Text = art.Nombre;
                this.txtPrecio.Text = art.Precio.ToString();
                this.textDescripcion.Text = art.Descripcion;

                /// comboBoxs
                /// 


                comboBoxCategoria.DataSource = controller.ListarCategorias();
                comboBoxMarca.DataSource = controller.ListarMarcas();


            }

            void btnAceptar_Click(object sender, EventArgs e)
            {


                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            void btnCancelar_Click(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            void btn_MouseEnter(object sender, EventArgs e)
            {
                Button btn = sender as Button;
                if (btn != null)
                {
                    btn.BackColor = Color.Gray;
                }
            }

            void btn_MouseLeave(object sender, EventArgs e)
            {
                Button btn = sender as Button;
                if (btn != null)
                {
                    btn.BackColor = System.Drawing.Color.MediumSeaGreen;
                }
            }


        }
    }

}

