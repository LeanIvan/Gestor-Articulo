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
                btnCheckImage.Click += new EventHandler(Click_VerImg);

                /// txtBox

                this.txtCodigo.Text = art.Codigo;
                this.txtNombre.Text = art.Nombre;
                this.txtPrecio.Text = art.Precio.ToString();
                this.textDescripcion.Text = art.Descripcion;
                this.textBoxUrl.Text = art.UrlImagen;
                
                /// comboBoxs
                /// 

                comboBoxCategoria.DataSource = controller.ListarCategorias();
                comboBoxCategoria.DisplayMember = "Descripcion"; /// La propiedad que va a mostrar
                comboBoxCategoria.ValueMember = "Id";   /// la propiedad que va a usar como valor

                comboBoxMarca.DataSource = controller.ListarMarcas();
                comboBoxMarca.DisplayMember = "Descripcion"; 
                comboBoxMarca.ValueMember = "Id";

                comboBoxCategoria.SelectedValue = art.IdCategoria;
                comboBoxMarca.SelectedValue = art.IdMarca;

            }

            void Click_VerImg(Object sender, EventArgs e)
            {
                CheckImgForm frm = new CheckImgForm(this.textBoxUrl.Text);
                frm.ShowDialog();
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



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un precio válido o mayor a 0.");
                    return;
                }

                Articulo art = new Articulo
                {
                    Codigo = this.txtCodigo.Text,
                    Nombre = this.txtNombre.Text,
                    Precio = precio,
                    Descripcion = this.textDescripcion.Text,
                    UrlImagen = this.textBoxUrl.Text,
                    IdCategoria = (int)this.comboBoxCategoria.SelectedValue,
                    IdMarca = (int)this.comboBoxMarca.SelectedValue,
                };

                  int filasAfectadas =  controller.ActualizarArticulo(art);

                
              
                if(filasAfectadas > 0)
                {
                    MessageBox.Show("Actualizado con Exito");
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                this.Close();
            }

        }

    }

}


