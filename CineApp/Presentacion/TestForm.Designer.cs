namespace WinFormsTPPrueba
{
    partial class TestForm
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
            this.btnVerificar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblAlturaCalle = new System.Windows.Forms.Label();
            this.lblCalles = new System.Windows.Forms.Label();
            this.lblTiposDocumento = new System.Windows.Forms.Label();
            this.cboTiposDocumento = new System.Windows.Forms.ComboBox();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.menuApartados = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAdquirirEntradas = new System.Windows.Forms.ToolStripMenuItem();
            this.itemComprar = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMisEntradas = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboCalles = new System.Windows.Forms.ComboBox();
            this.nudAltura = new System.Windows.Forms.NumericUpDown();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.cboCategorias = new System.Windows.Forms.ComboBox();
            this.lblCategorias = new System.Windows.Forms.Label();
            this.cboGeneros = new System.Windows.Forms.ComboBox();
            this.lblGeneros = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpIniciarSesion = new System.Windows.Forms.GroupBox();
            this.grpRegistrarse = new System.Windows.Forms.GroupBox();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnRegistrarse = new System.Windows.Forms.Button();
            this.btnEmpleado = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.menuApartados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAltura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpIniciarSesion.SuspendLayout();
            this.grpRegistrarse.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVerificar
            // 
            this.btnVerificar.Location = new System.Drawing.Point(538, 119);
            this.btnVerificar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(86, 31);
            this.btnVerificar.TabIndex = 2;
            this.btnVerificar.Text = "Verificar";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(94, 65);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(71, 20);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre: ";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(200, 60);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(244, 27);
            this.txtNombre.TabIndex = 3;
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(72, 25);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(94, 20);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "Documento: ";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(200, 20);
            this.txtDocumento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(244, 27);
            this.txtDocumento.TabIndex = 1;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(19, 180);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(152, 20);
            this.lblFechaNacimiento.TabIndex = 8;
            this.lblFechaNacimiento.Text = "Fecha de Nacimiento:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(94, 104);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(73, 20);
            this.lblApellido.TabIndex = 4;
            this.lblApellido.Text = "Apellido: ";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(200, 99);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(244, 27);
            this.txtApellido.TabIndex = 5;
            // 
            // lblAlturaCalle
            // 
            this.lblAlturaCalle.AutoSize = true;
            this.lblAlturaCalle.Location = new System.Drawing.Point(74, 256);
            this.lblAlturaCalle.Name = "lblAlturaCalle";
            this.lblAlturaCalle.Size = new System.Drawing.Size(93, 20);
            this.lblAlturaCalle.TabIndex = 12;
            this.lblAlturaCalle.Text = "Altura Calle: ";
            // 
            // lblCalles
            // 
            this.lblCalles.AutoSize = true;
            this.lblCalles.Location = new System.Drawing.Point(114, 219);
            this.lblCalles.Name = "lblCalles";
            this.lblCalles.Size = new System.Drawing.Size(49, 20);
            this.lblCalles.TabIndex = 10;
            this.lblCalles.Text = "Calle: ";
            // 
            // lblTiposDocumento
            // 
            this.lblTiposDocumento.AutoSize = true;
            this.lblTiposDocumento.Location = new System.Drawing.Point(42, 63);
            this.lblTiposDocumento.Name = "lblTiposDocumento";
            this.lblTiposDocumento.Size = new System.Drawing.Size(128, 20);
            this.lblTiposDocumento.TabIndex = 2;
            this.lblTiposDocumento.Text = "Tipo Documento: ";
            // 
            // cboTiposDocumento
            // 
            this.cboTiposDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTiposDocumento.FormattingEnabled = true;
            this.cboTiposDocumento.Location = new System.Drawing.Point(200, 59);
            this.cboTiposDocumento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTiposDocumento.Name = "cboTiposDocumento";
            this.cboTiposDocumento.Size = new System.Drawing.Size(244, 28);
            this.cboTiposDocumento.TabIndex = 3;
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(200, 176);
            this.dtpFechaNacimiento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(244, 27);
            this.dtpFechaNacimiento.TabIndex = 9;
            // 
            // menuApartados
            // 
            this.menuApartados.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuApartados.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.itemAdquirirEntradas,
            this.itemMisEntradas,
            this.itemAcercaDe,
            this.reportesToolStripMenuItem});
            this.menuApartados.Location = new System.Drawing.Point(0, 0);
            this.menuApartados.Name = "menuApartados";
            this.menuApartados.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuApartados.Size = new System.Drawing.Size(642, 30);
            this.menuApartados.TabIndex = 5;
            this.menuApartados.Text = "Apartados";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // itemAdquirirEntradas
            // 
            this.itemAdquirirEntradas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemComprar});
            this.itemAdquirirEntradas.Name = "itemAdquirirEntradas";
            this.itemAdquirirEntradas.Size = new System.Drawing.Size(138, 24);
            this.itemAdquirirEntradas.Text = "Adquirir entradas";
            // 
            // itemComprar
            // 
            this.itemComprar.Name = "itemComprar";
            this.itemComprar.Size = new System.Drawing.Size(150, 26);
            this.itemComprar.Text = "Comprar";
            this.itemComprar.Click += new System.EventHandler(this.comprarToolStripMenuItem_Click);
            // 
            // itemMisEntradas
            // 
            this.itemMisEntradas.Name = "itemMisEntradas";
            this.itemMisEntradas.Size = new System.Drawing.Size(109, 24);
            this.itemMisEntradas.Text = "Mis Compras";
            this.itemMisEntradas.Click += new System.EventHandler(this.itemMisEntradas_Click);
            // 
            // itemAcercaDe
            // 
            this.itemAcercaDe.Name = "itemAcercaDe";
            this.itemAcercaDe.Size = new System.Drawing.Size(91, 24);
            this.itemAcercaDe.Text = "Acerca De";
            this.itemAcercaDe.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.reportesToolStripMenuItem.Text = "Reportes";
            this.reportesToolStripMenuItem.Click += new System.EventHandler(this.reportesToolStripMenuItem_Click);
            // 
            // cboCalles
            // 
            this.cboCalles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCalles.FormattingEnabled = true;
            this.cboCalles.Location = new System.Drawing.Point(200, 215);
            this.cboCalles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboCalles.Name = "cboCalles";
            this.cboCalles.Size = new System.Drawing.Size(244, 28);
            this.cboCalles.TabIndex = 11;
            // 
            // nudAltura
            // 
            this.nudAltura.Location = new System.Drawing.Point(200, 253);
            this.nudAltura.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudAltura.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudAltura.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAltura.Name = "nudAltura";
            this.nudAltura.Size = new System.Drawing.Size(245, 27);
            this.nudAltura.TabIndex = 13;
            this.nudAltura.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblInstruccion.Location = new System.Drawing.Point(24, 69);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(142, 28);
            this.lblInstruccion.TabIndex = 0;
            this.lblInstruccion.Text = "Ingrese Datos";
            // 
            // cboCategorias
            // 
            this.cboCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategorias.FormattingEnabled = true;
            this.cboCategorias.Location = new System.Drawing.Point(200, 21);
            this.cboCategorias.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboCategorias.Name = "cboCategorias";
            this.cboCategorias.Size = new System.Drawing.Size(244, 28);
            this.cboCategorias.TabIndex = 1;
            // 
            // lblCategorias
            // 
            this.lblCategorias.AutoSize = true;
            this.lblCategorias.Location = new System.Drawing.Point(86, 25);
            this.lblCategorias.Name = "lblCategorias";
            this.lblCategorias.Size = new System.Drawing.Size(81, 20);
            this.lblCategorias.TabIndex = 0;
            this.lblCategorias.Text = "Categoria: ";
            // 
            // cboGeneros
            // 
            this.cboGeneros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGeneros.FormattingEnabled = true;
            this.cboGeneros.Location = new System.Drawing.Point(200, 137);
            this.cboGeneros.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboGeneros.Name = "cboGeneros";
            this.cboGeneros.Size = new System.Drawing.Size(244, 28);
            this.cboGeneros.TabIndex = 7;
            // 
            // lblGeneros
            // 
            this.lblGeneros.AutoSize = true;
            this.lblGeneros.Location = new System.Drawing.Point(101, 141);
            this.lblGeneros.Name = "lblGeneros";
            this.lblGeneros.Size = new System.Drawing.Size(64, 20);
            this.lblGeneros.TabIndex = 6;
            this.lblGeneros.Text = "Genero: ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(49, 101);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpIniciarSesion);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpRegistrarse);
            this.splitContainer1.Size = new System.Drawing.Size(482, 441);
            this.splitContainer1.SplitterDistance = 117;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // grpIniciarSesion
            // 
            this.grpIniciarSesion.Controls.Add(this.txtDocumento);
            this.grpIniciarSesion.Controls.Add(this.lblDni);
            this.grpIniciarSesion.Controls.Add(this.cboTiposDocumento);
            this.grpIniciarSesion.Controls.Add(this.lblTiposDocumento);
            this.grpIniciarSesion.Location = new System.Drawing.Point(6, 4);
            this.grpIniciarSesion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpIniciarSesion.Name = "grpIniciarSesion";
            this.grpIniciarSesion.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpIniciarSesion.Size = new System.Drawing.Size(458, 101);
            this.grpIniciarSesion.TabIndex = 0;
            this.grpIniciarSesion.TabStop = false;
            this.grpIniciarSesion.Text = "Documento";
            // 
            // grpRegistrarse
            // 
            this.grpRegistrarse.Controls.Add(this.lblCategorias);
            this.grpRegistrarse.Controls.Add(this.txtNombre);
            this.grpRegistrarse.Controls.Add(this.lblNombre);
            this.grpRegistrarse.Controls.Add(this.cboGeneros);
            this.grpRegistrarse.Controls.Add(this.txtApellido);
            this.grpRegistrarse.Controls.Add(this.lblGeneros);
            this.grpRegistrarse.Controls.Add(this.lblApellido);
            this.grpRegistrarse.Controls.Add(this.cboCategorias);
            this.grpRegistrarse.Controls.Add(this.lblFechaNacimiento);
            this.grpRegistrarse.Controls.Add(this.lblCalles);
            this.grpRegistrarse.Controls.Add(this.lblAlturaCalle);
            this.grpRegistrarse.Controls.Add(this.nudAltura);
            this.grpRegistrarse.Controls.Add(this.dtpFechaNacimiento);
            this.grpRegistrarse.Controls.Add(this.cboCalles);
            this.grpRegistrarse.Location = new System.Drawing.Point(6, 4);
            this.grpRegistrarse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpRegistrarse.Name = "grpRegistrarse";
            this.grpRegistrarse.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpRegistrarse.Size = new System.Drawing.Size(458, 297);
            this.grpRegistrarse.TabIndex = 0;
            this.grpRegistrarse.TabStop = false;
            this.grpRegistrarse.Text = "Registrar Datos";
            // 
            // btnCliente
            // 
            this.btnCliente.Location = new System.Drawing.Point(538, 51);
            this.btnCliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(46, 31);
            this.btnCliente.TabIndex = 3;
            this.btnCliente.Text = "Cliente";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Visible = false;
            this.btnCliente.Click += new System.EventHandler(this.btnRellenar_Click);
            // 
            // btnRegistrarse
            // 
            this.btnRegistrarse.Location = new System.Drawing.Point(538, 248);
            this.btnRegistrarse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRegistrarse.Name = "btnRegistrarse";
            this.btnRegistrarse.Size = new System.Drawing.Size(86, 31);
            this.btnRegistrarse.TabIndex = 4;
            this.btnRegistrarse.Text = "Registrar";
            this.btnRegistrarse.UseVisualStyleBackColor = true;
            this.btnRegistrarse.Click += new System.EventHandler(this.btnRegistrarse_Click);
            // 
            // btnEmpleado
            // 
            this.btnEmpleado.Location = new System.Drawing.Point(581, 51);
            this.btnEmpleado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEmpleado.Name = "btnEmpleado";
            this.btnEmpleado.Size = new System.Drawing.Size(43, 31);
            this.btnEmpleado.TabIndex = 3;
            this.btnEmpleado.Text = "Empleado";
            this.btnEmpleado.UseVisualStyleBackColor = true;
            this.btnEmpleado.Visible = false;
            this.btnEmpleado.Click += new System.EventHandler(this.btnEmpleado_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(538, 157);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(86, 31);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(446, 556);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(86, 31);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(538, 189);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(86, 31);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_ClickAsync);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 592);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnRegistrarse);
            this.Controls.Add(this.btnEmpleado);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnVerificar);
            this.Controls.Add(this.lblInstruccion);
            this.Controls.Add(this.menuApartados);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(660, 639);
            this.MinimumSize = new System.Drawing.Size(660, 639);
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.menuApartados.ResumeLayout(false);
            this.menuApartados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAltura)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpIniciarSesion.ResumeLayout(false);
            this.grpIniciarSesion.PerformLayout();
            this.grpRegistrarse.ResumeLayout(false);
            this.grpRegistrarse.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnVerificar;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblDni;
        private Label lblFechaNacimiento;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblAlturaCalle;
        private Label lblCalles;
        private TextBox txtDocumento;
        private Label lblTiposDocumento;
        private ComboBox cboTiposDocumento;
        private DateTimePicker dtpFechaNacimiento;
        private MenuStrip menuApartados;
        private ToolStripMenuItem itemAdquirirEntradas;
        private ToolStripMenuItem itemComprar;
        private ToolStripMenuItem itemMisEntradas;
        private ComboBox cboCalles;
        private NumericUpDown nudAltura;
        private Label lblInstruccion;
        private ComboBox cboCategorias;
        private Label lblCategorias;
        private ComboBox cboGeneros;
        private Label lblGeneros;
        private SplitContainer splitContainer1;
        private GroupBox grpIniciarSesion;
        private GroupBox grpRegistrarse;
        private Button btnCliente;
        private Button btnRegistrarse;
        private Button btnEmpleado;
        private ToolStripMenuItem itemAcercaDe;
        private Button btnModificar;
        private Button btnAceptar;
        private Button btnEliminar;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
    }
}