namespace Presentacion
{
    partial class EQUIPOS_PA
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.B_BUSQUEDA = new System.Windows.Forms.TextBox();
            this.EQUIPOS_BUSCAR = new FontAwesome.Sharp.IconButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ORDEN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SOLICITANTE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MARCA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SERIE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.INGRESO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UBICACION = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ESTADO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VALOR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ABONO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // B_BUSQUEDA
            // 
            this.B_BUSQUEDA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(161)))), ((int)(((byte)(84)))));
            this.B_BUSQUEDA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.B_BUSQUEDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_BUSQUEDA.ForeColor = System.Drawing.Color.Black;
            this.B_BUSQUEDA.Location = new System.Drawing.Point(54, 52);
            this.B_BUSQUEDA.Name = "B_BUSQUEDA";
            this.B_BUSQUEDA.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.B_BUSQUEDA.Size = new System.Drawing.Size(350, 20);
            this.B_BUSQUEDA.TabIndex = 2;
            this.B_BUSQUEDA.TextChanged += new System.EventHandler(this.B_BUSQUEDA_TextChanged);
            // 
            // EQUIPOS_BUSCAR
            // 
            this.EQUIPOS_BUSCAR.FlatAppearance.BorderSize = 0;
            this.EQUIPOS_BUSCAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EQUIPOS_BUSCAR.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.EQUIPOS_BUSCAR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(130)))), ((int)(((byte)(184)))));
            this.EQUIPOS_BUSCAR.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.EQUIPOS_BUSCAR.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(161)))), ((int)(((byte)(84)))));
            this.EQUIPOS_BUSCAR.IconSize = 26;
            this.EQUIPOS_BUSCAR.Location = new System.Drawing.Point(410, 52);
            this.EQUIPOS_BUSCAR.Name = "EQUIPOS_BUSCAR";
            this.EQUIPOS_BUSCAR.Rotation = 0D;
            this.EQUIPOS_BUSCAR.Size = new System.Drawing.Size(30, 21);
            this.EQUIPOS_BUSCAR.TabIndex = 5;
            this.EQUIPOS_BUSCAR.UseVisualStyleBackColor = true;
            this.EQUIPOS_BUSCAR.Click += new System.EventHandler(this.EQUIPOS_BUSCAR_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ORDEN,
            this.SOLICITANTE,
            this.MARCA,
            this.SERIE,
            this.INGRESO,
            this.UBICACION,
            this.ESTADO,
            this.VALOR,
            this.ABONO});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(46, 101);
            this.listView1.Name = "listView1";
            this.listView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listView1.Size = new System.Drawing.Size(820, 432);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // ORDEN
            // 
            this.ORDEN.Text = "ORDEN";
            this.ORDEN.Width = 52;
            // 
            // SOLICITANTE
            // 
            this.SOLICITANTE.Text = "SOLICITANTE";
            this.SOLICITANTE.Width = 120;
            // 
            // MARCA
            // 
            this.MARCA.Text = "MARCA";
            this.MARCA.Width = 90;
            // 
            // SERIE
            // 
            this.SERIE.Text = "TAMAÑO";
            this.SERIE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SERIE.Width = 140;
            // 
            // INGRESO
            // 
            this.INGRESO.Text = "INGRESO";
            this.INGRESO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.INGRESO.Width = 80;
            // 
            // UBICACION
            // 
            this.UBICACION.Text = "UBICACION";
            this.UBICACION.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UBICACION.Width = 90;
            // 
            // ESTADO
            // 
            this.ESTADO.Text = "ESTADO";
            this.ESTADO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ESTADO.Width = 88;
            // 
            // VALOR
            // 
            this.VALOR.Text = "VALOR";
            this.VALOR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.VALOR.Width = 65;
            // 
            // ABONO
            // 
            this.ABONO.Text = "ABONO";
            this.ABONO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ABONO.Width = 65;
            // 
            // iconButton1
            // 
            this.iconButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(161)))), ((int)(((byte)(84)))));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.iconButton1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(161)))), ((int)(((byte)(84)))));
            this.iconButton1.IconSize = 26;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(710, 539);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.iconButton1.Rotation = 0D;
            this.iconButton1.Size = new System.Drawing.Size(149, 30);
            this.iconButton1.TabIndex = 8;
            this.iconButton1.Text = "VISUALIZAR DATOS";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // EQUIPOS_PA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.EQUIPOS_BUSCAR);
            this.Controls.Add(this.B_BUSQUEDA);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "EQUIPOS_PA";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(920, 590);
            this.Load += new System.EventHandler(this.EQUIPOS_PA_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox B_BUSQUEDA;
        private FontAwesome.Sharp.IconButton EQUIPOS_BUSCAR;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ORDEN;
        private System.Windows.Forms.ColumnHeader SOLICITANTE;
        private System.Windows.Forms.ColumnHeader SERIE;
        private System.Windows.Forms.ColumnHeader INGRESO;
        private System.Windows.Forms.ColumnHeader UBICACION;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.ColumnHeader ESTADO;
        private System.Windows.Forms.ColumnHeader MARCA;
        private System.Windows.Forms.ColumnHeader VALOR;
        private System.Windows.Forms.ColumnHeader ABONO;
    }
}
