using Controlador;
using Modelo;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vista
{
    public partial class EditForm : Form
    {
       private ProductoController controller;
       private MarcaController marcaController;


        public EditForm(Articulo art)
        {
            {
                InitializeComponent();

                controller = new ProductoController();
                marcaController = new MarcaController();


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
                this.textBoxId.Text = art.Id.ToString();
                
                /// comboBoxs
                /// 

                comboBoxCategoria.DataSource = controller.ListarCategorias();
                comboBoxCategoria.DisplayMember = "Descripcion"; /// La propiedad que va a mostrar
                comboBoxCategoria.ValueMember = "Id";   /// la propiedad que va a usar como valor

                comboBoxMarca.DataSource = marcaController.ListarMarcas();
                comboBoxMarca.DisplayMember = "Descripcion"; 
                comboBoxMarca.ValueMember = "Id";

                comboBoxCategoria.SelectedValue = art.Categoria.Id;
                comboBoxMarca.SelectedValue = art.Marca.Id;

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
                    Id = int.Parse(this.textBoxId.Text),
                    Codigo = this.txtCodigo.Text,
                    Nombre = this.txtNombre.Text,
                    Precio = precio,
                    Descripcion = this.textDescripcion.Text,
                    UrlImagen = this.textBoxUrl.Text,
                    Categoria = (Categoria)this.comboBoxCategoria.SelectedItem,
                    Marca = (Marca)this.comboBoxMarca.SelectedItem,
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

    

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
             openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK) {

                textBoxUrl.Text = openFileDialog.FileName;
            }
                    
        }
    }

}


