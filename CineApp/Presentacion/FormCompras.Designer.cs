namespace WinFormsTPPrueba.Presentacion
{
    partial class FormCompras
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvButacasFunciones = new System.Windows.Forms.DataGridView();
            this.grpButacas = new System.Windows.Forms.GroupBox();
            this.btnPantalla = new System.Windows.Forms.Button();
            this.tabsFiltrosPeliculas = new System.Windows.Forms.TabControl();
            this.tabBusqueda = new System.Windows.Forms.TabPage();
            this.lblIdioma = new System.Windows.Forms.Label();
            this.cboIdioma = new System.Windows.Forms.ComboBox();
            this.lblGenero = new System.Windows.Forms.Label();
            this.cboGeneroPelicula = new System.Windows.Forms.ComboBox();
            this.cboCalificacionEtaria = new System.Windows.Forms.ComboBox();
            this.lblCalificacionEtaria = new System.Windows.Forms.Label();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.grpPeliculasDisponibles = new System.Windows.Forms.GroupBox();
            this.dgvCartelera = new System.Windows.Forms.DataGridView();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.grpFunciones = new System.Windows.Forms.GroupBox();
            this.dgvFunciones = new System.Windows.Forms.DataGridView();
            this.picImagenPelicula = new System.Windows.Forms.PictureBox();
            this.btnComprar = new System.Windows.Forms.Button();
            this.btnReservar = new System.Windows.Forms.Button();
            this.btnElegirAsiento = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvButacasFunciones)).BeginInit();
            this.grpButacas.SuspendLayout();
            this.tabsFiltrosPeliculas.SuspendLayout();
            this.tabBusqueda.SuspendLayout();
            this.grpPeliculasDisponibles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartelera)).BeginInit();
            this.grpFunciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImagenPelicula)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvButacasFunciones
            // 
            this.dgvButacasFunciones.AllowUserToAddRows = false;
            this.dgvButacasFunciones.AllowUserToDeleteRows = false;
            this.dgvButacasFunciones.AllowUserToResizeColumns = false;
            this.dgvButacasFunciones.AllowUserToResizeRows = false;
            this.dgvButacasFunciones.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvButacasFunciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvButacasFunciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvButacasFunciones.ColumnHeadersVisible = false;
            this.dgvButacasFunciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvButacasFunciones.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvButacasFunciones.Location = new System.Drawing.Point(6, 39);
            this.dgvButacasFunciones.MultiSelect = false;
            this.dgvButacasFunciones.Name = "dgvButacasFunciones";
            this.dgvButacasFunciones.RowHeadersVisible = false;
            this.dgvButacasFunciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvButacasFunciones.RowTemplate.Height = 25;
            this.dgvButacasFunciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvButacasFunciones.ShowCellToolTips = false;
            this.dgvButacasFunciones.ShowEditingIcon = false;
            this.dgvButacasFunciones.Size = new System.Drawing.Size(553, 131);
            this.dgvButacasFunciones.TabIndex = 0;
            this.dgvButacasFunciones.TabStop = false;
            this.dgvButacasFunciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvButacasFunciones_CellClick);
            this.dgvButacasFunciones.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvButacasFunciones_DataBindingComplete);
            // 
            // grpButacas
            // 
            this.grpButacas.Controls.Add(this.btnPantalla);
            this.grpButacas.Controls.Add(this.dgvButacasFunciones);
            this.grpButacas.Location = new System.Drawing.Point(250, 51);
            this.grpButacas.Name = "grpButacas";
            this.grpButacas.Size = new System.Drawing.Size(565, 176);
            this.grpButacas.TabIndex = 1;
            this.grpButacas.TabStop = false;
            this.grpButacas.Text = "Butacas - Uncharted: Fuera del Mapa - 10:30am";
            // 
            // btnPantalla
            // 
            this.btnPantalla.Enabled = false;
            this.btnPantalla.Location = new System.Drawing.Point(6, 16);
            this.btnPantalla.Name = "btnPantalla";
            this.btnPantalla.Size = new System.Drawing.Size(553, 23);
            this.btnPantalla.TabIndex = 1;
            this.btnPantalla.Text = "Pantalla";
            this.btnPantalla.UseVisualStyleBackColor = true;
            // 
            // tabsFiltrosPeliculas
            // 
            this.tabsFiltrosPeliculas.Controls.Add(this.tabBusqueda);
            this.tabsFiltrosPeliculas.Location = new System.Drawing.Point(18, 51);
            this.tabsFiltrosPeliculas.Name = "tabsFiltrosPeliculas";
            this.tabsFiltrosPeliculas.SelectedIndex = 0;
            this.tabsFiltrosPeliculas.Size = new System.Drawing.Size(226, 176);
            this.tabsFiltrosPeliculas.TabIndex = 2;
            // 
            // tabBusqueda
            // 
            this.tabBusqueda.AutoScroll = true;
            this.tabBusqueda.Controls.Add(this.lblIdioma);
            this.tabBusqueda.Controls.Add(this.cboIdioma);
            this.tabBusqueda.Controls.Add(this.lblGenero);
            this.tabBusqueda.Controls.Add(this.cboGeneroPelicula);
            this.tabBusqueda.Controls.Add(this.cboCalificacionEtaria);
            this.tabBusqueda.Controls.Add(this.lblCalificacionEtaria);
            this.tabBusqueda.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tabBusqueda.Location = new System.Drawing.Point(4, 24);
            this.tabBusqueda.Name = "tabBusqueda";
            this.tabBusqueda.Padding = new System.Windows.Forms.Padding(3);
            this.tabBusqueda.Size = new System.Drawing.Size(218, 148);
            this.tabBusqueda.TabIndex = 0;
            this.tabBusqueda.Text = "Busqueda";
            this.tabBusqueda.UseVisualStyleBackColor = true;
            // 
            // lblIdioma
            // 
            this.lblIdioma.AutoSize = true;
            this.lblIdioma.Location = new System.Drawing.Point(35, 88);
            this.lblIdioma.Name = "lblIdioma";
            this.lblIdioma.Size = new System.Drawing.Size(51, 15);
            this.lblIdioma.TabIndex = 4;
            this.lblIdioma.Text = "Idioma: ";
            // 
            // cboIdioma
            // 
            this.cboIdioma.FormattingEnabled = true;
            this.cboIdioma.Location = new System.Drawing.Point(100, 85);
            this.cboIdioma.Name = "cboIdioma";
            this.cboIdioma.Size = new System.Drawing.Size(98, 23);
            this.cboIdioma.TabIndex = 4;
            this.cboIdioma.SelectedIndexChanged += new System.EventHandler(this.SearchTabComboBoxChange);
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(31, 16);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(55, 15);
            this.lblGenero.TabIndex = 4;
            this.lblGenero.Text = "Genero: ";
            // 
            // cboGeneroPelicula
            // 
            this.cboGeneroPelicula.FormattingEnabled = true;
            this.cboGeneroPelicula.Location = new System.Drawing.Point(100, 15);
            this.cboGeneroPelicula.Name = "cboGeneroPelicula";
            this.cboGeneroPelicula.Size = new System.Drawing.Size(98, 23);
            this.cboGeneroPelicula.TabIndex = 4;
            this.cboGeneroPelicula.SelectedIndexChanged += new System.EventHandler(this.SearchTabComboBoxChange);
            // 
            // cboCalificacionEtaria
            // 
            this.cboCalificacionEtaria.FormattingEnabled = true;
            this.cboCalificacionEtaria.Location = new System.Drawing.Point(100, 50);
            this.cboCalificacionEtaria.Name = "cboCalificacionEtaria";
            this.cboCalificacionEtaria.Size = new System.Drawing.Size(98, 23);
            this.cboCalificacionEtaria.TabIndex = 4;
            this.cboCalificacionEtaria.SelectedIndexChanged += new System.EventHandler(this.SearchTabComboBoxChange);
            // 
            // lblCalificacionEtaria
            // 
            this.lblCalificacionEtaria.AutoSize = true;
            this.lblCalificacionEtaria.Location = new System.Drawing.Point(17, 43);
            this.lblCalificacionEtaria.Name = "lblCalificacionEtaria";
            this.lblCalificacionEtaria.Size = new System.Drawing.Size(69, 30);
            this.lblCalificacionEtaria.TabIndex = 4;
            this.lblCalificacionEtaria.Text = "Calificacion\r\npor Edad: ";
            this.lblCalificacionEtaria.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblInstruccion.Location = new System.Drawing.Point(12, 9);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(163, 21);
            this.lblInstruccion.TabIndex = 3;
            this.lblInstruccion.Text = "Compra de Entradas";
            // 
            // grpPeliculasDisponibles
            // 
            this.grpPeliculasDisponibles.Controls.Add(this.dgvCartelera);
            this.grpPeliculasDisponibles.Location = new System.Drawing.Point(12, 233);
            this.grpPeliculasDisponibles.Name = "grpPeliculasDisponibles";
            this.grpPeliculasDisponibles.Size = new System.Drawing.Size(623, 208);
            this.grpPeliculasDisponibles.TabIndex = 1;
            this.grpPeliculasDisponibles.TabStop = false;
            this.grpPeliculasDisponibles.Text = "Peliculas Disponibles - Todas";
            // 
            // dgvCartelera
            // 
            this.dgvCartelera.AllowUserToAddRows = false;
            this.dgvCartelera.AllowUserToDeleteRows = false;
            this.dgvCartelera.AllowUserToResizeRows = false;
            this.dgvCartelera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartelera.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCartelera.Location = new System.Drawing.Point(6, 22);
            this.dgvCartelera.MultiSelect = false;
            this.dgvCartelera.Name = "dgvCartelera";
            this.dgvCartelera.RowTemplate.Height = 25;
            this.dgvCartelera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCartelera.Size = new System.Drawing.Size(611, 180);
            this.dgvCartelera.TabIndex = 0;
            this.dgvCartelera.TabStop = false;
            this.dgvCartelera.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCartelera_CellEnter);
            this.dgvCartelera.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCartelera_DataBindingComplete);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Location = new System.Drawing.Point(93, 193);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(75, 23);
            this.btnReiniciar.TabIndex = 4;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = true;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // grpFunciones
            // 
            this.grpFunciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFunciones.Controls.Add(this.dgvFunciones);
            this.grpFunciones.Location = new System.Drawing.Point(641, 233);
            this.grpFunciones.Name = "grpFunciones";
            this.grpFunciones.Size = new System.Drawing.Size(325, 208);
            this.grpFunciones.TabIndex = 1;
            this.grpFunciones.TabStop = false;
            this.grpFunciones.Text = "Funciones - Uncharted: Fuera del Mapa";
            // 
            // dgvFunciones
            // 
            this.dgvFunciones.AllowUserToAddRows = false;
            this.dgvFunciones.AllowUserToDeleteRows = false;
            this.dgvFunciones.AllowUserToResizeRows = false;
            this.dgvFunciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFunciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFunciones.Location = new System.Drawing.Point(6, 22);
            this.dgvFunciones.MultiSelect = false;
            this.dgvFunciones.Name = "dgvFunciones";
            this.dgvFunciones.ReadOnly = true;
            this.dgvFunciones.RowTemplate.Height = 25;
            this.dgvFunciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFunciones.Size = new System.Drawing.Size(313, 180);
            this.dgvFunciones.TabIndex = 0;
            this.dgvFunciones.TabStop = false;
            this.dgvFunciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFunciones_CellClick);
            this.dgvFunciones.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvFunciones_DataBindingComplete);
            // 
            // picImagenPelicula
            // 
            this.picImagenPelicula.Location = new System.Drawing.Point(821, 9);
            this.picImagenPelicula.Name = "picImagenPelicula";
            this.picImagenPelicula.Size = new System.Drawing.Size(145, 218);
            this.picImagenPelicula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImagenPelicula.TabIndex = 5;
            this.picImagenPelicula.TabStop = false;
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(740, 9);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(75, 40);
            this.btnComprar.TabIndex = 6;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // btnReservar
            // 
            this.btnReservar.Location = new System.Drawing.Point(659, 9);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Size = new System.Drawing.Size(75, 40);
            this.btnReservar.TabIndex = 6;
            this.btnReservar.Text = "Reservar";
            this.btnReservar.UseVisualStyleBackColor = true;
            this.btnReservar.Click += new System.EventHandler(this.btnReservar_Click);
            // 
            // btnElegirAsiento
            // 
            this.btnElegirAsiento.Location = new System.Drawing.Point(578, 9);
            this.btnElegirAsiento.Name = "btnElegirAsiento";
            this.btnElegirAsiento.Size = new System.Drawing.Size(75, 40);
            this.btnElegirAsiento.TabIndex = 6;
            this.btnElegirAsiento.Text = "Elegir Asiento";
            this.btnElegirAsiento.UseVisualStyleBackColor = true;
            this.btnElegirAsiento.Visible = false;
            this.btnElegirAsiento.Click += new System.EventHandler(this.btnElegirAsiento_Click);
            // 
            // FormCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 453);
            this.Controls.Add(this.btnElegirAsiento);
            this.Controls.Add(this.btnReservar);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.picImagenPelicula);
            this.Controls.Add(this.grpFunciones);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.grpButacas);
            this.Controls.Add(this.lblInstruccion);
            this.Controls.Add(this.tabsFiltrosPeliculas);
            this.Controls.Add(this.grpPeliculasDisponibles);
            this.Name = "FormCompras";
            this.Text = "FormCompras";
            this.Load += new System.EventHandler(this.FormCompras_Load);
            this.MouseEnter += new System.EventHandler(this.FormCompras_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dgvButacasFunciones)).EndInit();
            this.grpButacas.ResumeLayout(false);
            this.tabsFiltrosPeliculas.ResumeLayout(false);
            this.tabBusqueda.ResumeLayout(false);
            this.tabBusqueda.PerformLayout();
            this.grpPeliculasDisponibles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartelera)).EndInit();
            this.grpFunciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImagenPelicula)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvButacasFunciones;
        private GroupBox grpButacas;
        private TabControl tabsFiltrosPeliculas;
        private TabPage tabBusqueda;
        private Label lblInstruccion;
        private GroupBox grpPeliculasDisponibles;
        private DataGridView dgvCartelera;
        private ComboBox cboCalificacionEtaria;
        private ComboBox cboGeneroPelicula;
        private Label lblCalificacionEtaria;
        private Label lblGenero;
        private Label lblIdioma;
        private ComboBox cboIdioma;
        private Button btnReiniciar;
        private GroupBox grpFunciones;
        private DataGridView dgvFunciones;
        private PictureBox picImagenPelicula;
        private Button btnComprar;
        private Button btnReservar;
        private Button btnPantalla;
        private Button btnElegirAsiento;
    }
}