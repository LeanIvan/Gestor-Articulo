using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Vista
{
    partial class HomeForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms



        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.PanelInfo = new System.Windows.Forms.Panel();
            this.panelLineMid = new System.Windows.Forms.Panel();
            this.panelLineLeft = new System.Windows.Forms.Panel();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.PictureBoxArticulo = new System.Windows.Forms.PictureBox();
            this.lblEstaticoDescripcion = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.lblEstaticoCategoria = new System.Windows.Forms.Label();
            this.btnEliminarArticulo = new System.Windows.Forms.Button();
            this.lblEstaticoMarca = new System.Windows.Forms.Label();
            this.lblEstaticoPrecio = new System.Windows.Forms.Label();
            this.comboBoxBusqueda = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnNuevoProducto = new System.Windows.Forms.Button();
            this.richTextBoxBuscar = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.PanelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.GridColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.dgvList.Location = new System.Drawing.Point(23, 77);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(665, 445);
            this.dgvList.TabIndex = 0;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ActualizarSeccionProductos);
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellDoubleClick);
            this.dgvList.SelectionChanged += new System.EventHandler(this.ActualizarSeccionProductos);
            // 
            // PanelInfo
            // 
            this.PanelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(34)))), ((int)(((byte)(43)))));
            this.PanelInfo.Controls.Add(this.panelLineMid);
            this.PanelInfo.Controls.Add(this.panelLineLeft);
            this.PanelInfo.Controls.Add(this.lblDescripcion);
            this.PanelInfo.Controls.Add(this.lblCategoria);
            this.PanelInfo.Controls.Add(this.lblMarca);
            this.PanelInfo.Controls.Add(this.lblPrecio);
            this.PanelInfo.Controls.Add(this.PictureBoxArticulo);
            this.PanelInfo.Controls.Add(this.lblEstaticoDescripcion);
            this.PanelInfo.Controls.Add(this.btnEditar);
            this.PanelInfo.Controls.Add(this.lblEstaticoCategoria);
            this.PanelInfo.Controls.Add(this.btnEliminarArticulo);
            this.PanelInfo.Controls.Add(this.lblEstaticoMarca);
            this.PanelInfo.Controls.Add(this.lblEstaticoPrecio);
            this.PanelInfo.Location = new System.Drawing.Point(707, 38);
            this.PanelInfo.Name = "PanelInfo";
            this.PanelInfo.Size = new System.Drawing.Size(325, 484);
            this.PanelInfo.TabIndex = 6;
            // 
            // panelLineMid
            // 
            this.panelLineMid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(0)))));
            this.panelLineMid.Enabled = false;
            this.panelLineMid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(0)))));
            this.panelLineMid.Location = new System.Drawing.Point(35, 276);
            this.panelLineMid.Name = "panelLineMid";
            this.panelLineMid.Size = new System.Drawing.Size(265, 1);
            this.panelLineMid.TabIndex = 28;
            // 
            // panelLineLeft
            // 
            this.panelLineLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(0)))));
            this.panelLineLeft.Enabled = false;
            this.panelLineLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(0)))));
            this.panelLineLeft.Location = new System.Drawing.Point(1, -8);
            this.panelLineLeft.Name = "panelLineLeft";
            this.panelLineLeft.Size = new System.Drawing.Size(1, 450);
            this.panelLineLeft.TabIndex = 27;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.ForeColor = System.Drawing.Color.White;
            this.lblDescripcion.Location = new System.Drawing.Point(132, 374);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(190, 62);
            this.lblDescripcion.TabIndex = 26;
            this.lblDescripcion.Text = "label1";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.ForeColor = System.Drawing.Color.White;
            this.lblCategoria.Location = new System.Drawing.Point(132, 345);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(35, 13);
            this.lblCategoria.TabIndex = 25;
            this.lblCategoria.Text = "label1";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.ForeColor = System.Drawing.Color.White;
            this.lblMarca.Location = new System.Drawing.Point(132, 317);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(35, 13);
            this.lblMarca.TabIndex = 24;
            this.lblMarca.Text = "label1";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.ForeColor = System.Drawing.Color.White;
            this.lblPrecio.Location = new System.Drawing.Point(132, 289);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(35, 13);
            this.lblPrecio.TabIndex = 23;
            this.lblPrecio.Text = "label1";
            // 
            // PictureBoxArticulo
            // 
            this.PictureBoxArticulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PictureBoxArticulo.BackColor = System.Drawing.Color.White;
            this.PictureBoxArticulo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("PictureBoxArticulo.ErrorImage")));
            this.PictureBoxArticulo.InitialImage = null;
            this.PictureBoxArticulo.Location = new System.Drawing.Point(35, 0);
            this.PictureBoxArticulo.Name = "PictureBoxArticulo";
            this.PictureBoxArticulo.Size = new System.Drawing.Size(265, 265);
            this.PictureBoxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxArticulo.TabIndex = 0;
            this.PictureBoxArticulo.TabStop = false;
            // 
            // lblEstaticoDescripcion
            // 
            this.lblEstaticoDescripcion.AutoSize = true;
            this.lblEstaticoDescripcion.ForeColor = System.Drawing.Color.White;
            this.lblEstaticoDescripcion.Location = new System.Drawing.Point(32, 373);
            this.lblEstaticoDescripcion.Name = "lblEstaticoDescripcion";
            this.lblEstaticoDescripcion.Size = new System.Drawing.Size(69, 13);
            this.lblEstaticoDescripcion.TabIndex = 20;
            this.lblEstaticoDescripcion.Text = "Descripción :";
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(0)))));
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.Black;
            this.btnEditar.Location = new System.Drawing.Point(0, 441);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(165, 43);
            this.btnEditar.TabIndex = 0;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnEditar.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // lblEstaticoCategoria
            // 
            this.lblEstaticoCategoria.AutoSize = true;
            this.lblEstaticoCategoria.ForeColor = System.Drawing.Color.White;
            this.lblEstaticoCategoria.Location = new System.Drawing.Point(32, 345);
            this.lblEstaticoCategoria.Name = "lblEstaticoCategoria";
            this.lblEstaticoCategoria.Size = new System.Drawing.Size(60, 13);
            this.lblEstaticoCategoria.TabIndex = 19;
            this.lblEstaticoCategoria.Text = "Categoría :";
            // 
            // btnEliminarArticulo
            // 
            this.btnEliminarArticulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEliminarArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(0)))));
            this.btnEliminarArticulo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEliminarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarArticulo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarArticulo.Location = new System.Drawing.Point(162, 441);
            this.btnEliminarArticulo.Name = "btnEliminarArticulo";
            this.btnEliminarArticulo.Size = new System.Drawing.Size(165, 43);
            this.btnEliminarArticulo.TabIndex = 1;
            this.btnEliminarArticulo.Text = "Eliminar";
            this.btnEliminarArticulo.UseVisualStyleBackColor = false;
            this.btnEliminarArticulo.Click += new System.EventHandler(this.btnEliminarArticulo_Click);
            this.btnEliminarArticulo.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnEliminarArticulo.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // lblEstaticoMarca
            // 
            this.lblEstaticoMarca.AutoSize = true;
            this.lblEstaticoMarca.ForeColor = System.Drawing.Color.White;
            this.lblEstaticoMarca.Location = new System.Drawing.Point(32, 317);
            this.lblEstaticoMarca.Name = "lblEstaticoMarca";
            this.lblEstaticoMarca.Size = new System.Drawing.Size(63, 13);
            this.lblEstaticoMarca.TabIndex = 18;
            this.lblEstaticoMarca.Text = "Fabricante :";
            // 
            // lblEstaticoPrecio
            // 
            this.lblEstaticoPrecio.AutoSize = true;
            this.lblEstaticoPrecio.ForeColor = System.Drawing.Color.White;
            this.lblEstaticoPrecio.Location = new System.Drawing.Point(32, 289);
            this.lblEstaticoPrecio.Name = "lblEstaticoPrecio";
            this.lblEstaticoPrecio.Size = new System.Drawing.Size(43, 13);
            this.lblEstaticoPrecio.TabIndex = 17;
            this.lblEstaticoPrecio.Text = "Precio :";
            // 
            // comboBoxBusqueda
            // 
            this.comboBoxBusqueda.BackColor = System.Drawing.Color.White;
            this.comboBoxBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxBusqueda.FormattingEnabled = true;
            this.comboBoxBusqueda.Location = new System.Drawing.Point(160, 39);
            this.comboBoxBusqueda.Name = "comboBoxBusqueda";
            this.comboBoxBusqueda.Size = new System.Drawing.Size(149, 21);
            this.comboBoxBusqueda.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(0)))));
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(550, 38);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(138, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.btnBuscar.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnBuscar.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // btnNuevoProducto
            // 
            this.btnNuevoProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(0)))));
            this.btnNuevoProducto.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNuevoProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnNuevoProducto.Location = new System.Drawing.Point(22, 38);
            this.btnNuevoProducto.Name = "btnNuevoProducto";
            this.btnNuevoProducto.Size = new System.Drawing.Size(138, 23);
            this.btnNuevoProducto.TabIndex = 0;
            this.btnNuevoProducto.Text = "Nuevo";
            this.btnNuevoProducto.UseVisualStyleBackColor = false;
            this.btnNuevoProducto.Click += new System.EventHandler(this.btnNuevoProducto_Click);
            this.btnNuevoProducto.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnNuevoProducto.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // richTextBoxBuscar
            // 
            this.richTextBoxBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxBuscar.Location = new System.Drawing.Point(310, 39);
            this.richTextBoxBuscar.MaxLength = 100;
            this.richTextBoxBuscar.Multiline = false;
            this.richTextBoxBuscar.Name = "richTextBoxBuscar";
            this.richTextBoxBuscar.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxBuscar.Size = new System.Drawing.Size(240, 21);
            this.richTextBoxBuscar.TabIndex = 2;
            this.richTextBoxBuscar.Text = "";
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(34)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(1044, 534);
            this.Controls.Add(this.richTextBoxBuscar);
            this.Controls.Add(this.btnNuevoProducto);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.PanelInfo);
            this.Controls.Add(this.comboBoxBusqueda);
            this.Controls.Add(this.dgvList);
            this.MaximizeBox = false;
            this.Name = "HomeForm";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Homeform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.PanelInfo.ResumeLayout(false);
            this.PanelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxArticulo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.DataGridView dgvList;     
        private Panel PanelInfo;
        private Button btnEliminarArticulo;
        private PictureBox PictureBoxArticulo;
        private Button btnEditar;
        private Label lblEstaticoDescripcion;
        private Label lblEstaticoCategoria;
        private Label lblEstaticoMarca;
        private Label lblEstaticoPrecio;
        private Label lblDescripcion;
        private Label lblCategoria;
        private Label lblMarca;
        private Label lblPrecio;
        private Panel panelLineLeft;
        private ComboBox comboBoxBusqueda;
        private Button btnBuscar;
        private Button btnNuevoProducto;
        private RichTextBox richTextBoxBuscar;
        private Panel panelLineMid;
    }
}

