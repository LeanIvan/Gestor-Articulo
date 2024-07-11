using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Vista
{
    public partial class HomeForm : Form
    {


        public ProductoController controller = new ProductoController();
        string ruta = AppDomain.CurrentDomain.BaseDirectory;



        public HomeForm()
        {
            InitializeComponent();


            /// home form
            /// 
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;


            /// dgvLists
            /// 
            dgvList.BackgroundColor = Color.FromArgb(26, 32, 40);
            dgvList.DefaultCellStyle.BackColor = Color.FromArgb(26, 32, 40);
            dgvList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 32, 40);
            dgvList.DefaultCellStyle.ForeColor = Color.White;
            dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            /// comboBoxes
            comboBoxBusqueda.Items.Clear();

            comboBoxBusqueda.Items.Add("Buscar por Código");
            comboBoxBusqueda.Items.Add("Buscar por Nombre");
            comboBoxBusqueda.Items.Add("Buscar por Marca");
            comboBoxBusqueda.Items.Add("Buscar por Categoría");
            comboBoxBusqueda.SelectedIndex = 0;

            ///
            PanelInfo.BackColor = Color.FromArgb(128, 26, 32, 40);
            /// btns
            /// 
            btnEditar.Click += new EventHandler(editar_Producto_btn);

            /// txtBox
            /// 


        }



        private void Homeform_Load(object sender, EventArgs e)
        {

            /// dgvList
            List<Articulo> listArticulos = controller.ListarArticulos();
            dgvList.DataSource = listArticulos;
            dgvList.ReadOnly = true;
            dgvList.Columns["IdMarca"].HeaderText = "ID Marca";
            //    dgvList.Columns["IdMarca"].Visible = false;
            //    dgvList.Columns["idCategoria"].Visible = false;
            dgvList.Columns["idCategoria"].HeaderText = "ID Categoria";
            dgvList.Columns["UrlImagen"].Visible = false;
            dgvList.Columns["Descripcion"].Visible = false;
        
        }



        // evento que cambia la img del articulo

        private void ActualizarSeccionProductos(object sender, EventArgs e)
        {

            try
            {

                DataGridViewRow fila = dgvList.CurrentRow;

                if (fila != null)
                {

                    /// la url está en el indice 6
                    ///      

                    try
                    {
                        PictureBoxArticulo.Load((string)fila.Cells[6].Value);

                    }
                    catch
                    {
                        PictureBoxArticulo.Image = PictureBoxArticulo.ErrorImage;
                    }

                    string PrecioArt = "$ " + fila.Cells[2].Value.ToString();
                    string DescripcionArt = fila.Cells[5].Value.ToString();

                    /// traer desde la db

                    string MarcaArt = controller.getMarcaById((int)fila.Cells[3].Value);
                    string CategoriaArt = controller.getCategoriaById((int)fila.Cells[4].Value);


                    /// update de labels en la seccion
                    /// 

                    lblMarca.Text = MarcaArt;
                    lblCategoria.Text = CategoriaArt;
                    lblPrecio.Text = PrecioArt;
                    lblDescripcion.Text = DescripcionArt;

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }

        }



        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            using (AddForm addfrm = new AddForm())
            {
                addfrm.ShowDialog();

               
            }
            this.ActualizarDatos();    
            this.btnNuevoProducto.Refresh();

        }



        private void EditarProducto(DataGridViewRow selectedRow)
        {

            Articulo selectedArticulo = new Articulo
            {
                Codigo = selectedRow.Cells["Codigo"].Value.ToString(),
                Nombre = selectedRow.Cells["Nombre"].Value.ToString(),
                Precio = Convert.ToDecimal(selectedRow.Cells["Precio"].Value),
                IdCategoria = Convert.ToInt32(selectedRow.Cells["IdCategoria"].Value),
                IdMarca = Convert.ToInt32(selectedRow.Cells["IdMarca"].Value),
                Descripcion = selectedRow.Cells["Descripcion"].Value.ToString(),
                UrlImagen = selectedRow.Cells["UrlImagen"].Value.ToString()
            };

            using (EditForm editForm = new EditForm(selectedArticulo))
            {
                editForm.ShowDialog();
            }

            this.ActualizarDatos();
            this.btnEditar.Refresh();         
        }

        private void editar_Producto_btn(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow != null)
            {
                EditarProducto(dgvList.CurrentRow);
            }
        }


        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvList.Rows[e.RowIndex];
                if (selectedRow != null)
                {
                    EditarProducto(selectedRow);
                }

            }
        }



        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {

                button.BackColor = Color.FromArgb(241, 90, 37);
                //  button.ForeColor = Color.White;   
            }
        }



        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {

                button.BackColor = Color.FromArgb(255, 163, 0);

            }
        }


        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {

            using (DeleteForm frm = new DeleteForm())
            {

                DialogResult result = frm.ShowDialog();

                if (result == DialogResult.OK)
                {

                    try
                    {
                        if (dgvList.CurrentRow != null)
                        {

                            string codigo = dgvList.CurrentRow.Cells["Codigo"].Value.ToString();
                            int filasAfectadas = controller.EliminarArticulo(codigo);

                            if (filasAfectadas > 0)
                            {
                                MessageBox.Show("Artículo eliminado con éxito.");

                                this.ActualizarDatos();
                                this.btnEliminarArticulo.Refresh();
                                return;

                            }
                            else
                            {
                                MessageBox.Show("No se pudo eliminar el artículo.");
                                this.btnEliminarArticulo.Refresh();

                                return;
                            }
                        }

                    }
                    catch
                    {
                        MessageBox.Show("No se pudo eliminar el artículo.");
                        this.btnEliminarArticulo.Refresh();
                        return;

                    }

                }

            }
           
        }


        public void ActualizarDatos()
        {       
            var listaArticulos = controller.ListarArticulos();
            dgvList.DataSource = listaArticulos;
            dgvList.Refresh();
        }



    }


}

