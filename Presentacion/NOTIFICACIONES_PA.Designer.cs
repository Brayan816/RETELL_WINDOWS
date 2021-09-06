namespace Presentacion
{
    partial class NOTIFICACIONES_PA
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.FECHA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NOMBRE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MARCA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SERIE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MODELO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UBICACION = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.INSCRITO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FECHA,
            this.NOMBRE,
            this.MARCA,
            this.SERIE,
            this.MODELO,
            this.UBICACION,
            this.INSCRITO,
            this.ID});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(50, 75);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(820, 440);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // FECHA
            // 
            this.FECHA.Tag = "FECHA";
            this.FECHA.Text = "FECHA";
            this.FECHA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FECHA.Width = 70;
            // 
            // NOMBRE
            // 
            this.NOMBRE.Text = "NOMBRE";
            this.NOMBRE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NOMBRE.Width = 170;
            // 
            // MARCA
            // 
            this.MARCA.Text = "MARCA";
            this.MARCA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MARCA.Width = 110;
            // 
            // SERIE
            // 
            this.SERIE.Text = "SERIE";
            this.SERIE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SERIE.Width = 100;
            // 
            // MODELO
            // 
            this.MODELO.Text = "MODELO";
            this.MODELO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MODELO.Width = 90;
            // 
            // UBICACION
            // 
            this.UBICACION.Text = "UBICACION";
            this.UBICACION.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UBICACION.Width = 130;
            // 
            // INSCRITO
            // 
            this.INSCRITO.Text = "INSCRITO";
            this.INSCRITO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.INSCRITO.Width = 105;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ID.Width = 28;
            // 
            // iconButton1
            // 
            this.iconButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(130)))), ((int)(((byte)(184)))));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.iconButton1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(130)))), ((int)(((byte)(184)))));
            this.iconButton1.IconSize = 26;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(721, 521);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.iconButton1.Rotation = 0D;
            this.iconButton1.Size = new System.Drawing.Size(149, 30);
            this.iconButton1.TabIndex = 10;
            this.iconButton1.Text = "VISUALIZAR DATOS";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // NOTIFICACIONES_PA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.listView1);
            this.Name = "NOTIFICACIONES_PA";
            this.Size = new System.Drawing.Size(920, 590);
            this.Load += new System.EventHandler(this.NOTIFICACIONES_PA_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader FECHA;
        private System.Windows.Forms.ColumnHeader NOMBRE;
        private System.Windows.Forms.ColumnHeader MARCA;
        private System.Windows.Forms.ColumnHeader SERIE;
        private System.Windows.Forms.ColumnHeader MODELO;
        private System.Windows.Forms.ColumnHeader UBICACION;
        private System.Windows.Forms.ColumnHeader INSCRITO;
        private System.Windows.Forms.ColumnHeader ID;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}
