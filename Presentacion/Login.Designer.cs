namespace Presentacion
{
    partial class Login
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

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.inusuario = new System.Windows.Forms.TextBox();
            this.incontra = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.incerrar = new System.Windows.Forms.Button();
            this.inmini = new System.Windows.Forms.Button();
            this.mserror = new System.Windows.Forms.Label();
            this.MANT_CC = new FontAwesome.Sharp.IconButton();
            this.VER_CONTRA = new FontAwesome.Sharp.IconButton();
            this.bla = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(161)))), ((int)(((byte)(84)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 330);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(38, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 193);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(780, 330);
            this.shapeContainer1.TabIndex = 2;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 380;
            this.lineShape2.X2 = 680;
            this.lineShape2.Y1 = 191;
            this.lineShape2.Y2 = 191;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lineShape1.Enabled = false;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 380;
            this.lineShape1.X2 = 680;
            this.lineShape1.Y1 = 131;
            this.lineShape1.Y2 = 131;
            // 
            // inusuario
            // 
            this.inusuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.inusuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inusuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.inusuario.Location = new System.Drawing.Point(380, 106);
            this.inusuario.Name = "inusuario";
            this.inusuario.Size = new System.Drawing.Size(301, 24);
            this.inusuario.TabIndex = 1;
            this.inusuario.Text = "USUARIO";
            this.inusuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inusuario.TextChanged += new System.EventHandler(this.inusuario_TextChanged);
            this.inusuario.Enter += new System.EventHandler(this.inusuario_Enter);
            this.inusuario.Leave += new System.EventHandler(this.inusuario_Leave);
            // 
            // incontra
            // 
            this.incontra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.incontra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.incontra.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incontra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.incontra.Location = new System.Drawing.Point(380, 164);
            this.incontra.Name = "incontra";
            this.incontra.Size = new System.Drawing.Size(301, 24);
            this.incontra.TabIndex = 2;
            this.incontra.Text = "CONTRASEÑA";
            this.incontra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.incontra.Enter += new System.EventHandler(this.incontra_Enter);
            this.incontra.Leave += new System.EventHandler(this.incontra_Leave);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.linkLabel1.Location = new System.Drawing.Point(467, 282);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(148, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "¿Has olvidado la contraseña?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(380, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(301, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "ACCEDER";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(485, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 33);
            this.label1.TabIndex = 20;
            this.label1.Text = "LOGIN";
            // 
            // incerrar
            // 
            this.incerrar.FlatAppearance.BorderSize = 0;
            this.incerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.incerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.incerrar.Location = new System.Drawing.Point(743, 12);
            this.incerrar.Name = "incerrar";
            this.incerrar.Size = new System.Drawing.Size(25, 25);
            this.incerrar.TabIndex = 4;
            this.incerrar.Text = "X";
            this.incerrar.UseVisualStyleBackColor = true;
            this.incerrar.Click += new System.EventHandler(this.incerrar_Click);
            // 
            // inmini
            // 
            this.inmini.FlatAppearance.BorderSize = 0;
            this.inmini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inmini.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inmini.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.inmini.Location = new System.Drawing.Point(722, 9);
            this.inmini.Name = "inmini";
            this.inmini.Size = new System.Drawing.Size(25, 25);
            this.inmini.TabIndex = 4;
            this.inmini.Text = "_";
            this.inmini.UseVisualStyleBackColor = true;
            this.inmini.Click += new System.EventHandler(this.inmini_Click);
            // 
            // mserror
            // 
            this.mserror.AutoSize = true;
            this.mserror.ForeColor = System.Drawing.Color.DimGray;
            this.mserror.Location = new System.Drawing.Point(377, 206);
            this.mserror.Name = "mserror";
            this.mserror.Size = new System.Drawing.Size(29, 13);
            this.mserror.TabIndex = 8;
            this.mserror.Text = "Error";
            this.mserror.Visible = false;
            // 
            // MANT_CC
            // 
            this.MANT_CC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MANT_CC.FlatAppearance.BorderSize = 0;
            this.MANT_CC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MANT_CC.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.MANT_CC.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            this.MANT_CC.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(179)))), ((int)(((byte)(74)))));
            this.MANT_CC.IconSize = 28;
            this.MANT_CC.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MANT_CC.Location = new System.Drawing.Point(687, 239);
            this.MANT_CC.Name = "MANT_CC";
            this.MANT_CC.Rotation = 0D;
            this.MANT_CC.Size = new System.Drawing.Size(30, 23);
            this.MANT_CC.TabIndex = 83;
            this.MANT_CC.UseVisualStyleBackColor = true;
            // 
            // VER_CONTRA
            // 
            this.VER_CONTRA.FlatAppearance.BorderSize = 0;
            this.VER_CONTRA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VER_CONTRA.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.VER_CONTRA.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.VER_CONTRA.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.VER_CONTRA.IconSize = 25;
            this.VER_CONTRA.Location = new System.Drawing.Point(687, 169);
            this.VER_CONTRA.Name = "VER_CONTRA";
            this.VER_CONTRA.Rotation = 0D;
            this.VER_CONTRA.Size = new System.Drawing.Size(30, 23);
            this.VER_CONTRA.TabIndex = 84;
            this.VER_CONTRA.UseVisualStyleBackColor = true;
            this.VER_CONTRA.Click += new System.EventHandler(this.VER_CONTRA_Click);
            // 
            // bla
            // 
            this.bla.FlatAppearance.BorderSize = 0;
            this.bla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bla.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.bla.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.bla.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.bla.IconSize = 25;
            this.bla.Location = new System.Drawing.Point(687, 169);
            this.bla.Name = "bla";
            this.bla.Rotation = 0D;
            this.bla.Size = new System.Drawing.Size(30, 23);
            this.bla.TabIndex = 85;
            this.bla.UseVisualStyleBackColor = true;
            this.bla.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(780, 330);
            this.Controls.Add(this.bla);
            this.Controls.Add(this.VER_CONTRA);
            this.Controls.Add(this.MANT_CC);
            this.Controls.Add(this.mserror);
            this.Controls.Add(this.inmini);
            this.Controls.Add(this.incerrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.incontra);
            this.Controls.Add(this.inusuario);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " LOGIN";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.TextBox inusuario;
        private System.Windows.Forms.TextBox incontra;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button incerrar;
        private System.Windows.Forms.Button inmini;
        private System.Windows.Forms.Label mserror;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton MANT_CC;
        private FontAwesome.Sharp.IconButton VER_CONTRA;
        private FontAwesome.Sharp.IconButton bla;
    }
}

