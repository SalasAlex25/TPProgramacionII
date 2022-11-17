namespace CineApp
{
    partial class Sorteo
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
            this.lblSorteo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblListado = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvSorteo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSorteo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSorteo
            // 
            this.lblSorteo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSorteo.AutoSize = true;
            this.lblSorteo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSorteo.Location = new System.Drawing.Point(25, 20);
            this.lblSorteo.Name = "lblSorteo";
            this.lblSorteo.Size = new System.Drawing.Size(125, 25);
            this.lblSorteo.TabIndex = 0;
            this.lblSorteo.Text = "Sorteo Año: ";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDescripcion.Location = new System.Drawing.Point(25, 59);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(541, 21);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "El sorteo se realiza entre las 5 personas que más compraron en el año actual ";
            // 
            // lblListado
            // 
            this.lblListado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblListado.AutoSize = true;
            this.lblListado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblListado.Location = new System.Drawing.Point(25, 98);
            this.lblListado.Name = "lblListado";
            this.lblListado.Size = new System.Drawing.Size(269, 21);
            this.lblListado.TabIndex = 2;
            this.lblListado.Text = "Listado de los que mas compraron al ";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(483, 307);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvSorteo
            // 
            this.dgvSorteo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSorteo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSorteo.Location = new System.Drawing.Point(25, 122);
            this.dgvSorteo.Name = "dgvSorteo";
            this.dgvSorteo.RowTemplate.Height = 25;
            this.dgvSorteo.Size = new System.Drawing.Size(533, 179);
            this.dgvSorteo.TabIndex = 4;
            // 
            // Sorteo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 342);
            this.Controls.Add(this.dgvSorteo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblListado);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblSorteo);
            this.Name = "Sorteo";
            this.Text = "Sorteo";
            this.Load += new System.EventHandler(this.Sorteo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSorteo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblSorteo;
        private Label lblDescripcion;
        private Label lblListado;
        private Button btnSalir;
        private DataGridView dgvSorteo;
    }
}