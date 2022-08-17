using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Renci.SshNet;
using Renci.SshNet.Common;
using System.Net;
using Aspose.Words.Fields;
using System.Drawing.Printing;
using Renci.SshNet.Sftp;
using System.IO.Ports;
using System.Threading;
//using Word = Microsoft.Office.Interop.Word;
using System.Collections;
using Rectangle = iTextSharp.text.Rectangle;
using System.Drawing.Drawing2D;

namespace Presentacion
{
    public partial class DATOS_2 : Form
    {
        CONEXION con = new CONEXION();
        LLANTA llanta = new LLANTA();
        public int PRV = 0;
        private bool draggin = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public string M1;
        public string Pe = AppDomain.CurrentDomain.BaseDirectory + @"\MF.pdf";
        public string PR = AppDomain.CurrentDomain.BaseDirectory + @"\MX.pdf";
        public int FDS = 0;
        private int borderRadius = 15;
        private int borderSize = 3;
        private Color borderColor = Color.FromArgb(242, 161, 84);
        public string FM3 = "";
        
        public DATOS_2()
        {
           
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
        }

        private void DATOS_2_Load(object sender, EventArgs e)
        {

            llanta.ORDEN_S = M1;
            llanta.B_Datos();
            T_Ciudad.Text = llanta.Comentario_consulta;
            axAcroPDF1.Visible = false;
            CrearPDF();
            CrearFACTURA();
            CrearInforme();
            label1.Font = new System.Drawing.Font(label1.Font,FontStyle.Bold);
            label10.Font = new System.Drawing.Font(label1.Font, FontStyle.Bold);
            label15.Font = new System.Drawing.Font(label1.Font, FontStyle.Bold);
           
            List<int> F1 = Extractor_Fechas(llanta.FECHA);

            dateTimePicker1.Value =new DateTime(F1[2]+2000, F1[1], F1[0]);
            dateTimePicker1.Enabled = false;
            List<int> F2 = Extractor_Fechas(llanta.FECHAS);
            dateTimePicker2.Value = new DateTime(F2[2]+2000, F2[1], F2[0]);
            dateTimePicker2.Enabled = false;
           
            CargarData();
        }
        public List<int> Extractor_Fechas(string FECHA)
        {
            string[] Valores = new string[3];
            List<int> F2 = new List<int>();
            try
            {
                Valores = FECHA.Split('/');
                F2.Add(Int16.Parse(Valores[0]));
                F2.Add(Int16.Parse(Valores[1]));
                F2.Add(Int16.Parse(Valores[2]));
                return F2;
            }
            catch(Exception E)
            {
                string N1 = DateTime.Now.ToString("MM/dd/yyyy");
                Valores = N1.Split('/');
                F2.Add(Int16.Parse(Valores[0]));
                F2.Add(Int16.Parse(Valores[1]));
                F2.Add(Int16.Parse(Valores[2]));
                MessageBox.Show(E.Message.ToString());
                return F2;
            }
        }

        public void CargarData()
        {
            string[] ESTADOS_LLANTA = { "INGRESO", "ESCARIADO", "PRESENTACION DE MATERIALES", "TESTURIZADO", "CEMENTADO", "INSTALACION DE MATERIALES", "RELLENO CON CAUCHO", "VULCANIZACION", "TERMINACION", "LISTO PARA ENTREGA", "ENTREGADO" };
            string[] LOTE_LLANTA={ "LOTE 1", "LOTE 2","LOTE 3","LOTE 4","LOTE 5","LOTE 6","LOTE 7","LOTE 8","LOTE 9","LOTE 10","LOTE 11","LOTE 12","LOTE 13","LOTE 14","LOTE 15","LOTE 16","LOTE 17","LOTE 18","LOTE 19","LOTE 20","LOTE 21","LOTE 22","LOTE 23","LOTE 24","LOTE 25"};
            string[] POSICION_LLANTA ={ "P1", "P2","P3","P4","P5","P6","P7","P8","P9","P10","P11","P12","P13","P14","P15","P16"};
             
            C_Estado.Items.AddRange(ESTADOS_LLANTA);
            C_Estado.SelectedIndex = C_Estado.FindString(llanta.E_A);
            C_Lote.Items.AddRange(LOTE_LLANTA);
            foreach (string COMP1 in LOTE_LLANTA)
            {
                if (COMP1.Equals(llanta.UBICACION))
                {
                    C_Lote.SelectedIndex = C_Lote.FindString(llanta.UBICACION);
                }
            }
            T_Tamaño.Text = llanta.Comentario_consulta;
            C_Posicion.Items.AddRange(POSICION_LLANTA);
            foreach (string COMP1 in POSICION_LLANTA)
            {
                if (COMP1.Equals(llanta.POSICION))
                {
                    C_Posicion.SelectedIndex = C_Posicion.FindString(llanta.POSICION);
                }
            }
            C_Estado.Enabled = false;
            C_Lote.Enabled = false;
            C_Posicion.Enabled = false;
            T_Marca.Text = llanta.MARCA;
            T_Tamaño.Text = llanta.TAMAÑO;
            T_Serie.Text = llanta.SERIE;
            T_Valor.Text = llanta.VALOR;
            T_Abono.Text = llanta.ABONO;
            T_Nombre.Text = llanta.SOLICITANTE;
            T_Orden.Text = llanta.ORDEN_S;
            T_Direccion.Text = llanta.DIRECCION;
            T_Barrio.Text = llanta.BARRIO;
            T_Ciudad.Text = llanta.CIUDAD;
            T_Telefono.Text = llanta.TELEFONO;
            T_Marca.Enabled = false;
            T_Tamaño.Enabled = false;
            T_Serie.Enabled = false;
            T_Nombre.Enabled = false;
            T_Valor.Enabled = false;
            T_Abono.Enabled = false;
            T_Orden.Enabled = false;
            T_Direccion.Enabled = false;
            T_Barrio.Enabled = false;
            T_Ciudad.Enabled = false;
            T_Telefono.Enabled = false;
        }
        public void ver()
        {
            if (Login.ALFA == "A")
            {
                G_QR.Visible = false;

            }
        }

        private void DATOS_2_MouseDown(object sender, MouseEventArgs e)
        {
            draggin = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void DATOS_2_MouseMove(object sender, MouseEventArgs e)
        {
            if(draggin)
            {
                Point dif = Point.Subtract(Cursor.Position,new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void DATOS_2_MouseUp(object sender, MouseEventArgs e)
        {
            draggin = false;
        }

        private void PRICERRAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PRIMINI_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void IMPRIMIR_Click(object sender, EventArgs e)
        {
            String PA = AppDomain.CurrentDomain.BaseDirectory;
            String AA = @PA + @"\MF.pdf";
            String AC = @PA + @"\ML.pdf";
            String AB = @PA + @"\MK"+FM3;
            if (PRV==1)
            {
                SaveFileDialog SD = new SaveFileDialog();
                SD.Filter = "PDF File (*" + FM3 + ")|" + FM3;
                SD.DefaultExt = FM3;
                if (SD.ShowDialog() == DialogResult.OK)
                {
                    
                    string ND = SD.FileName;
                    System.IO.File.Copy(AA, ND);
                }
            }
            else if(PRV==3)
            {
                SaveFileDialog SD = new SaveFileDialog();
                SD.Filter = "Image File (*" + FM3 + ")|"+FM3;
                SD.DefaultExt = FM3;
                if (SD.ShowDialog() == DialogResult.OK)
                {
                    string ND = SD.FileName;
                    System.IO.File.Copy(AB, ND);
                }
            }
            else if(PRV==2)
            { 
                SaveFileDialog SD = new SaveFileDialog();
                SD.Filter = "PDF File (*" + FM3 + ")|" + FM3;
                SD.DefaultExt = FM3;
                if (SD.ShowDialog() == DialogResult.OK)
                {
                    string ND = SD.FileName;
                    System.IO.File.Copy(AC, ND);
                }
            }
            ContadorDescargas();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void iconButton1_Click(object sender, EventArgs e)
        {
            axAcroPDF1.Visible = true;
            String PA = AppDomain.CurrentDomain.BaseDirectory;
            String AA = @PA + @"\MF.pdf";
            axAcroPDF1.LoadFile(AA);
        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {

        }
        
        
        
        private void CrearPDF()
        {
            
            //GENERAR PDF
            try
            {
                String PA = AppDomain.CurrentDomain.BaseDirectory;
                String AA = @PA + @"\MF.pdf";
                String AB = @PA + @"\IMG1.png";
                String AC = @PA + @"\IMG2.png";
                String AD = @PA + @"\IMGE.png";
                String AE = @PA + @"\IMGD.png";
                QRCoder.QRCodeGenerator QR = new QRCoder.QRCodeGenerator();
                QRCoder.QRCodeData NA= QR.CreateQrCode(M1, QRCoder.QRCodeGenerator.ECCLevel.H);
                QRCoder.QRCode QRCODE= new QRCoder.QRCode(NA);
                Bitmap qrImage = QRCODE.GetGraphic(20);
                qrImage.Save(AC);
                using (System.Drawing.Image im = System.Drawing.Image.FromFile(AC))
                {
                    new Bitmap(im, 250, 250).Save(AD);
                    new Bitmap(im, 250, 250).Save(AE);
                }
                Document pdoc = new Document(iTextSharp.text.PageSize.A5.Rotate(),10,10,10,10);
                PdfWriter pWriter = PdfWriter.GetInstance(pdoc, new FileStream(AA, FileMode.Create));
                pdoc.Open();
                // CREAR MEMBRETE
                PdfPTable TABLA1 = new PdfPTable(new float[] { 38f, 31f, 31f });
                TABLA1.HorizontalAlignment = 1;
                //CARGAR IMAGEN DE LA IPS
                iTextSharp.text.Image myImage = iTextSharp.text.Image.GetInstance(AC);
                PdfPCell celda = new PdfPCell(myImage);
                celda.FixedHeight = 190;
                celda.PaddingBottom = 2;
                celda.PaddingTop = 2;
                celda.PaddingLeft = 2;  
                //FUENTE PARA EL TITULO
                var FC = new BaseColor(136, 136, 136);
                BaseFont Titulo = BaseFont.CreateFont("c:\\windows\\fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                var fuente2 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, iTextSharp.text.Font.BOLD, 12);
                iTextSharp.text.Font fuente = new iTextSharp.text.Font(Titulo, 22);
                //FUENTE PARA EL COSTADO DERECHO
                iTextSharp.text.Font der = new iTextSharp.text.Font(Titulo, 10);
                iTextSharp.text.Font der2 = new iTextSharp.text.Font(Titulo, 12);
                celda.Rowspan = 8;
                TABLA1.AddCell(celda);
                //CELDA DOS_1
                PdfPCell C2_1 = new PdfPCell();
                C2_1 = new PdfPCell(new Phrase("DATOS DE LA LLANTA", der2));
                //C2_1.Border = PdfPCell.NO_BORDER;
                C2_1.HorizontalAlignment = Element.ALIGN_CENTER;
                C2_1.VerticalAlignment = Element.ALIGN_MIDDLE;
                C2_1.FixedHeight = 28;
                TABLA1.AddCell(C2_1);
                //CELDA TRES_1
                PdfPCell C2_2 = new PdfPCell();
                C2_2 = new PdfPCell(new Phrase("DATOS DEL CLIENTE", der2));
                C2_2.VerticalAlignment = Element.ALIGN_MIDDLE;
                C2_2.HorizontalAlignment = Element.ALIGN_CENTER;
                TABLA1.AddCell(C2_2);
                //CELDA DOS_2
                PdfPCell C2_3 = new PdfPCell();
                C2_3 = new PdfPCell(new Phrase("MARCA:  "+llanta.MARCA, der));
                C2_3.Border = PdfPCell.NO_BORDER;
                C2_3.HorizontalAlignment = Element.ALIGN_LEFT;
                C2_3.VerticalAlignment = Element.ALIGN_MIDDLE;
                C2_3.FixedHeight = 18;
                C2_3.PaddingLeft = 7;
                TABLA1.AddCell(C2_3);
                //CELDA TRES_2
                PdfPCell C2_4 = new PdfPCell();
                C2_4 = new PdfPCell(new Phrase("NOMBRE:  "+llanta.SOLICITANTE, der));
                C2_4.HorizontalAlignment = Element.ALIGN_LEFT;
                C2_4.VerticalAlignment = Element.ALIGN_MIDDLE;
                C2_4.PaddingLeft = 7;
                TABLA1.AddCell(C2_4);
                //CELDA DOS_3
                PdfPCell C2_5 = new PdfPCell();
                C2_5 = new PdfPCell(new Phrase("TAMAÑO:  "+llanta.TAMAÑO, der));
                C2_5.HorizontalAlignment = Element.ALIGN_LEFT;
                C2_5.VerticalAlignment = Element.ALIGN_MIDDLE;
                C2_5.PaddingLeft = 7;
                C2_5.FixedHeight = 18;
                TABLA1.AddCell(C2_5);
                //CELDA TRES_3
                PdfPCell C2_6 = new PdfPCell();
                C2_6 = new PdfPCell(new Phrase("DIRECCION:  "+llanta.DIRECCION, der));
                C2_6.HorizontalAlignment = Element.ALIGN_LEFT;
                C2_6.VerticalAlignment = Element.ALIGN_MIDDLE;
                C2_6.PaddingLeft = 7;
                TABLA1.AddCell(C2_6);
                PdfPCell C2_7 = new PdfPCell();
                C2_7 = new PdfPCell(new Phrase("SERIE:  "+llanta.SERIE, der));
                C2_7.HorizontalAlignment = Element.ALIGN_LEFT;
                C2_7.VerticalAlignment = Element.ALIGN_MIDDLE;
                C2_7.PaddingLeft = 7;
                C2_7.FixedHeight = 18;
                TABLA1.AddCell(C2_7);

                //CELDA 3

                PdfPCell C3_1 = new PdfPCell();
                C3_1 = new PdfPCell(new Phrase("BARRIO:  "+llanta.BARRIO, der));
                C3_1.HorizontalAlignment = Element.ALIGN_LEFT;
                C3_1.VerticalAlignment = Element.ALIGN_MIDDLE;
                C3_1.PaddingLeft = 7;
                C3_1.FixedHeight = 18;
                TABLA1.AddCell(C3_1);

                PdfPCell C3_2 = new PdfPCell();
                C3_2 = new PdfPCell(new Phrase("INGRESO:  "+llanta.FECHA, der));
                C3_2.HorizontalAlignment = Element.ALIGN_LEFT;
                C3_2.VerticalAlignment = Element.ALIGN_MIDDLE;
                C3_2.PaddingLeft = 7;
                C3_2.FixedHeight = 18;
                TABLA1.AddCell(C3_2);

                PdfPCell C3_3 = new PdfPCell();
                C3_3 = new PdfPCell(new Phrase("CIUDAD:  "+llanta.CIUDAD, der));
                C3_3.HorizontalAlignment = Element.ALIGN_LEFT;
                C3_3.VerticalAlignment = Element.ALIGN_MIDDLE;
                C3_3.PaddingLeft = 7;
                C3_3.FixedHeight = 18;
                TABLA1.AddCell(C3_3);

                PdfPCell C3_4 = new PdfPCell();
                C3_4 = new PdfPCell(new Phrase("SALIDA:  "+llanta.FECHAS, der));
                C3_4.HorizontalAlignment = Element.ALIGN_LEFT;
                C3_4.VerticalAlignment = Element.ALIGN_MIDDLE;
                C3_4.PaddingLeft = 7;
                C3_4.FixedHeight = 18;
                TABLA1.AddCell(C3_4);

                PdfPCell C3_5 = new PdfPCell();
                C3_5 = new PdfPCell(new Phrase("TELEFONO:  "+llanta.TELEFONO, der));
                C3_5.HorizontalAlignment = Element.ALIGN_LEFT;
                C3_5.VerticalAlignment = Element.ALIGN_MIDDLE;
                C3_5.PaddingLeft = 7;
                C3_5.FixedHeight = 18;
                TABLA1.AddCell(C3_5);

                PdfPCell C3_6 = new PdfPCell();
                C3_6 = new PdfPCell(new Phrase("ORDEN DE SERVICIO: "+llanta.ORDEN_S, der));
                C3_6.HorizontalAlignment = Element.ALIGN_LEFT;
                C3_6.VerticalAlignment = Element.ALIGN_MIDDLE;
                C3_6.PaddingLeft = 7;
                C3_6.FixedHeight = 18;
                TABLA1.AddCell(C3_6);

                PdfPCell C3_7 = new PdfPCell();
                C3_7 = new PdfPCell(new Phrase("", der));
                C3_7.Border = PdfPCell.NO_BORDER;
                C3_7.BorderWidthRight = 0.1f;
                C3_7.HorizontalAlignment = Element.ALIGN_LEFT;
                C3_7.VerticalAlignment = Element.ALIGN_MIDDLE;
                C3_7.PaddingLeft = 7;
                C3_7.FixedHeight = 18;
                TABLA1.AddCell(C3_7);

                PdfPCell C3_8 = new PdfPCell();
                C3_8 = new PdfPCell(new Phrase("", der));
                C3_8.HorizontalAlignment = Element.ALIGN_LEFT;
                C3_8.VerticalAlignment = Element.ALIGN_MIDDLE;
                C3_8.PaddingLeft = 7;
                C3_8.FixedHeight = 18;
                TABLA1.AddCell(C3_8);

                PdfPCell C3_9 = new PdfPCell();
                C3_9 = new PdfPCell(new Phrase("", der));
                C3_9.HorizontalAlignment = Element.ALIGN_LEFT;
                C3_9.VerticalAlignment = Element.ALIGN_MIDDLE;
                C3_9.PaddingLeft = 7;
                C3_9.Border = PdfPCell.NO_BORDER;
                C3_9.BorderWidthRight = 0.1f;
                C3_9.BorderWidthBottom = 0.1f;
                C3_9.FixedHeight = 18;
                TABLA1.AddCell(C3_9);

                TABLA1.WidthPercentage = 90f;
                pdoc.Add(TABLA1);
                Paragraph pp4 = new Paragraph("     ");
                pp4.Leading = 15;
                pdoc.Add(pp4);

                PdfPTable TABLA2 = new PdfPTable(new float[] { 38f, 31f, 31f });
                TABLA2.HorizontalAlignment = 1;
                //CARGAR IMAGEN DE LA IPS
                iTextSharp.text.Image myImage2 = iTextSharp.text.Image.GetInstance(AC);
                PdfPCell celda2 = new PdfPCell(myImage2);
                celda2.FixedHeight = 190;
                celda2.PaddingBottom = 2;
                celda2.PaddingTop = 2;
                celda2.PaddingLeft = 2;
                celda2.Rowspan = 8;
                TABLA2.AddCell(celda2);
                TABLA2.AddCell(C2_1);
                TABLA2.AddCell(C2_2);
                TABLA2.AddCell(C2_3);
                TABLA2.AddCell(C2_4);
                TABLA2.AddCell(C2_5);
                TABLA2.AddCell(C2_6);
                TABLA2.AddCell(C2_7);
                TABLA2.AddCell(C3_1);
                TABLA2.AddCell(C3_2);
                TABLA2.AddCell(C3_3);
                TABLA2.AddCell(C3_4);
                TABLA2.AddCell(C3_5);
                TABLA2.AddCell(C3_6);
                TABLA2.AddCell(C3_7);
                TABLA2.AddCell(C3_8);
                TABLA2.AddCell(C3_9);
                TABLA2.WidthPercentage = 90f;
                pdoc.Add(TABLA2);

                pdoc.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CrearFACTURA()
        {

            //GENERAR PDF
            try
            {
                //FUENTE PARA EL TITULO
                var FC = new BaseColor(136, 136, 136);
                BaseFont Titulo = BaseFont.CreateFont("c:\\windows\\fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font myFont = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 0));
                iTextSharp.text.Font SERIE = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(255, 51, 51));
                iTextSharp.text.Font SERIE2 = FontFactory.GetFont("c:\\windows\\fonts\\arial.ttf", 10, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 0));
                iTextSharp.text.Font SERIE8 = FontFactory.GetFont("c:\\windows\\fonts\\arial.ttf", 8, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 0));
                iTextSharp.text.Font SERIE9 = FontFactory.GetFont("c:\\windows\\fonts\\arial.ttf", 9, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 0));

                iTextSharp.text.Font fuente = new iTextSharp.text.Font(Titulo, 22);
                //FUENTE PARA EL COSTADO DERECHO
                iTextSharp.text.Font der14 = new iTextSharp.text.Font(Titulo, 14);
                iTextSharp.text.Font der10 = new iTextSharp.text.Font(Titulo, 10);
                iTextSharp.text.Font der6 = new iTextSharp.text.Font(Titulo, 6);
                iTextSharp.text.Font der9 = new iTextSharp.text.Font(Titulo, 9);
                iTextSharp.text.Font der8 = new iTextSharp.text.Font(Titulo, 8);
                iTextSharp.text.Font der5 = new iTextSharp.text.Font(Titulo, 10);
                //ESPACIO
                Paragraph pp4 = new Paragraph("     ");
                pp4.Leading = 7;
                String PA = AppDomain.CurrentDomain.BaseDirectory;
                String AA = @PA + @"\MS.pdf";
                String AD = @PA + @"\IMGE.png";
                String AE = @PA + @"\P2S.png";
                String AF = @PA + @"\AN1.jpg";
                String AC = @PA + @"\IMG2.png";
                Document pdoc = new Document(iTextSharp.text.PageSize.A5, 10, 10, 10, 10);
                PdfWriter pWriter = PdfWriter.GetInstance(pdoc, new FileStream(AA, FileMode.Create));
                pdoc.Open();
                
                QRCoder.QRCodeGenerator QR = new QRCoder.QRCodeGenerator();
                QRCoder.QRCodeData NA = QR.CreateQrCode(M1, QRCoder.QRCodeGenerator.ECCLevel.H);
                QRCoder.QRCode QRCODE = new QRCoder.QRCode(NA);
                Bitmap qrImage = QRCODE.GetGraphic(20);
                qrImage.Save(AC);
                using (System.Drawing.Image im = System.Drawing.Image.FromFile(AC))
                {
                    new Bitmap(im, 250, 250).Save(AD);
                    //new Bitmap(im, 250, 250).Save(AE);
                }
                
                // CREAR MEMBRETE
                PdfPTable TABLA1 = new PdfPTable(new float[] {22f, 50f,25f });
                TABLA1.HorizontalAlignment = 1;

                //CARGAR IMAGEN DE RETELL
                iTextSharp.text.Image myImage = iTextSharp.text.Image.GetInstance(AE);
                PdfPCell celda = new PdfPCell(myImage);
                iTextSharp.text.Image myImage2 = iTextSharp.text.Image.GetInstance(AD);
                PdfPCell celda2 = new PdfPCell(myImage2);
                PdfPCell celda3 = new PdfPCell();
                celda3 = new PdfPCell(new Phrase(""));
                //
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                celda.FixedHeight = 80;
                celda.PaddingBottom = 2;
                celda.PaddingTop = 2;
                celda.PaddingLeft = 2;
                celda.Border = PdfPCell.NO_BORDER;
                celda.Border = PdfPCell.TOP_BORDER | PdfPCell.BOTTOM_BORDER;
                //
                celda2.HorizontalAlignment = Element.ALIGN_CENTER;
                celda2.FixedHeight = 80;
                celda2.PaddingBottom = 2;
                celda2.PaddingTop = 2;
                celda2.PaddingLeft = 2;
                celda2.Border = PdfPCell.NO_BORDER;
                celda2.Border = PdfPCell.TOP_BORDER | PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER;
                //
                celda3.HorizontalAlignment = Element.ALIGN_CENTER;
                celda3.FixedHeight = 80;
                celda3.PaddingBottom = 2;
                celda3.PaddingTop = 2;
                celda3.PaddingLeft = 2;
                celda3.Border = PdfPCell.NO_BORDER;
                celda3.Border = PdfPCell.TOP_BORDER | PdfPCell.BOTTOM_BORDER | PdfPCell.RIGHT_BORDER;
                //celda.Rowspan = 8;
                TABLA1.AddCell(celda2);
                TABLA1.AddCell(celda);
                TABLA1.AddCell(celda3);
                //CELDA DOS_1
                TABLA1.WidthPercentage = 100f;
                pdoc.Add(TABLA1);
                PdfPTable TABLA2 = new PdfPTable(new float[] { 15f, 70f, 15f });
                TABLA2.HorizontalAlignment = 1;
                TABLA2.WidthPercentage = 100f;
                //TAPRAP IMAGEN
                iTextSharp.text.Image MT = iTextSharp.text.Image.GetInstance(AF);
                PdfPCell TAPRAP = new PdfPCell(MT);
                TAPRAP.Border = PdfPCell.NO_BORDER;
                TAPRAP.BorderWidthLeft = 0.1f;
                TAPRAP.HorizontalAlignment = Element.ALIGN_CENTER;
                TAPRAP.FixedHeight = 37;
                TAPRAP.PaddingBottom = 2;
                TAPRAP.PaddingTop = 2;
                TAPRAP.PaddingLeft = 2;
                TAPRAP.Rowspan = 2;
                //TAPRAP R
                iTextSharp.text.Image MT2 = iTextSharp.text.Image.GetInstance(AF);
                PdfPCell TAPRAPR = new PdfPCell(MT2);
                TAPRAPR.Border = PdfPCell.NO_BORDER;
                TAPRAPR.BorderWidthRight = 0.1f;
                TAPRAPR.HorizontalAlignment = Element.ALIGN_CENTER;
                TAPRAPR.FixedHeight = 37;
                TAPRAPR.PaddingBottom = 2;
                TAPRAPR.PaddingTop = 2;
                TAPRAPR.PaddingLeft = 2;
                TAPRAPR.Rowspan = 2;

                PdfPCell C3_1 = new PdfPCell();
                C3_1 = new PdfPCell(new Phrase("REPARACION TECNICA DE LLANTAS", myFont));
                C3_1.HorizontalAlignment = Element.ALIGN_CENTER;
                C3_1.VerticalAlignment = Element.ALIGN_MIDDLE;
                C3_1.Border = PdfPCell.NO_BORDER;
                C3_1.PaddingLeft = 7;

                //
                PdfPCell C3_2 = new PdfPCell();
                C3_2 = new PdfPCell(new Phrase("AV. 7   No.  0B -  84    TELF.  5873383 Cucuta", SERIE2));
                C3_2.HorizontalAlignment = Element.ALIGN_CENTER;
                C3_2.VerticalAlignment = Element.ALIGN_MIDDLE;
                C3_2.Border = PdfPCell.NO_BORDER;
                C3_2.PaddingLeft = 7;
                //
                PdfPCell C3_3 = new PdfPCell();
                C3_3 = new PdfPCell(new Phrase("CERTIFICACION\r\nTECNOLOGIA\r\nEUROPEA\r\nTAP RAP", der6));
                C3_3.HorizontalAlignment = Element.ALIGN_CENTER;
                C3_3.VerticalAlignment = Element.ALIGN_MIDDLE;
                C3_3.Border = PdfPCell.NO_BORDER;
                C3_3.BorderWidthLeft = 0.1f;
                C3_3.PaddingLeft = 7;

                PdfPCell C3_3R = new PdfPCell();
                C3_3R = new PdfPCell(new Phrase("CERTIFICACION\r\nTECNOLOGIA\r\nEUROPEA\r\nTAP RAP", der6));
                C3_3R.HorizontalAlignment = Element.ALIGN_CENTER;
                C3_3R.VerticalAlignment = Element.ALIGN_MIDDLE;
                C3_3R.Border = PdfPCell.NO_BORDER;
                C3_3R.BorderWidthRight = 0.1f;
                C3_3R.PaddingLeft = 7;
                //
                PdfPCell C3_4 = new PdfPCell();
                C3_4 = new PdfPCell(new Phrase("JACKELINE HERNANDEZ CARDENAS", SERIE2));
                C3_4.HorizontalAlignment = Element.ALIGN_CENTER;
                C3_4.VerticalAlignment = Element.ALIGN_MIDDLE;
                C3_4.Border = PdfPCell.NO_BORDER;
                C3_4.PaddingLeft = 7;

                PdfPCell C3_5 = new PdfPCell();
                C3_5 = new PdfPCell(new Phrase("", der6));
                C3_5.Border = PdfPCell.NO_BORDER;
                C3_5.BorderWidthLeft = 0.1f;

                PdfPCell C3_5R = new PdfPCell();
                C3_5R = new PdfPCell(new Phrase("", der6));
                C3_5R.Border = PdfPCell.NO_BORDER;
                C3_5R.BorderWidthRight = 0.1f;

                PdfPCell C3_6 = new PdfPCell();
                C3_6 = new PdfPCell(new Phrase("Nit. No. 60.365.524 - 2            Regimen Simplificado", SERIE8));
                C3_6.HorizontalAlignment = Element.ALIGN_CENTER;
                C3_6.VerticalAlignment = Element.ALIGN_MIDDLE;
                C3_6.Border = PdfPCell.NO_BORDER;
                C3_6.PaddingLeft = 7;
                //
                PdfPCell C3_7 = new PdfPCell();
                C3_7 = new PdfPCell(new Phrase("", der6));
                C3_7.Border = PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER; 

                PdfPCell C3_7R = new PdfPCell();
                C3_7R = new PdfPCell(new Phrase("FACTURA No°", myFont));
                C3_7R.HorizontalAlignment = Element.ALIGN_CENTER;
                C3_7R.Border = PdfPCell.NO_BORDER;
                C3_7R.Border = PdfPCell.TOP_BORDER;
                
                PdfPCell C3_8R = new PdfPCell();
                C3_8R = new PdfPCell(new Phrase(llanta.ORDEN_S, SERIE));
                C3_8R.HorizontalAlignment = Element.ALIGN_CENTER;
                TABLA2.AddCell(TAPRAP);
                TABLA2.AddCell(C3_1);
                TABLA2.AddCell(TAPRAPR);
                TABLA2.AddCell(C3_2);
                TABLA2.AddCell(C3_3);
                TABLA2.AddCell(C3_4);
                TABLA2.AddCell(C3_3R);
                TABLA2.AddCell(C3_5);
                TABLA2.AddCell(C3_6);
                TABLA2.AddCell(C3_5R);
                pdoc.Add(TABLA2);

                PdfPTable TABLA3 = new PdfPTable(new float[] { 30f, 45f, 25f });
                TABLA3.HorizontalAlignment = 1;
                TABLA3.WidthPercentage = 100f;
                TABLA3.AddCell(C3_7);
                TABLA3.AddCell(C3_7R);
                TABLA3.AddCell(C3_8R);
                pdoc.Add(TABLA3);

                PdfPTable TABLA4 = new PdfPTable(new float[] {100f });
                TABLA4.HorizontalAlignment = 1;
                TABLA4.WidthPercentage = 100f;
                PdfPCell C5_1 = new PdfPCell();
                C5_1 = new PdfPCell(new Phrase("NOMBRE:   "+llanta.SOLICITANTE, SERIE8));
                TABLA4.AddCell(C5_1);
                pdoc.Add(TABLA4);

                PdfPTable TABLA5 = new PdfPTable(new float[] { 25f, 25f, 34f, 16f });
                TABLA5.HorizontalAlignment = 1;
                TABLA5.WidthPercentage = 100f;
                PdfPCell C6_1 = new PdfPCell();
                C6_1 = new PdfPCell(new Phrase("DIRECCION: " + llanta.DIRECCION, SERIE9));
                C6_1.VerticalAlignment = Element.ALIGN_MIDDLE;
                PdfPCell C6_2 = new PdfPCell();
                C6_2 = new PdfPCell(new Phrase("TEL: " + llanta.TELEFONO, SERIE9));
                C6_2.VerticalAlignment = Element.ALIGN_MIDDLE;
                PdfPCell C6_3 = new PdfPCell();
                C6_3 = new PdfPCell(new Phrase("NIT: "+ llanta.N_IDE, SERIE9));
                C6_3.VerticalAlignment = Element.ALIGN_MIDDLE;
                PdfPCell C6_4 = new PdfPCell();
                C6_4 = new PdfPCell(new Phrase("PLACA:", SERIE9));
                C6_4.VerticalAlignment = Element.ALIGN_MIDDLE;
                C6_1.FixedHeight = 30;

                TABLA5.AddCell(C6_1);
                TABLA5.AddCell(C6_2);
                TABLA5.AddCell(C6_3);
                TABLA5.AddCell(C6_4);
                pdoc.Add(TABLA5);

                PdfPTable TABLA7 = new PdfPTable(new float[] { 16f, 9f, 25f, 17f, 17f, 16f });
                TABLA7.HorizontalAlignment = 1;
                TABLA7.WidthPercentage = 100f;
                PdfPCell C7_1 = new PdfPCell();
                C7_1 = new PdfPCell(new Phrase("SERVICIO:", SERIE9));
                C7_1.VerticalAlignment = Element.ALIGN_LEFT;
                PdfPCell C7_2 = new PdfPCell();
                C7_2 = new PdfPCell(new Phrase("SI", SERIE9));
                C7_2.VerticalAlignment = Element.ALIGN_LEFT;
                PdfPCell C7_3 = new PdfPCell();
                C7_3 = new PdfPCell(new Phrase("MERCANCIA:", SERIE9));
                C7_3.VerticalAlignment = Element.ALIGN_LEFT;
                PdfPCell C7_4 = new PdfPCell();
                C7_4 = new PdfPCell(new Phrase("VENTA:", SERIE9));
                C7_4.VerticalAlignment = Element.ALIGN_LEFT;
                PdfPCell C7_5 = new PdfPCell();
                C7_5 = new PdfPCell(new Phrase("FECHA: "+ llanta.FECHAE, SERIE9));
                C7_5.VerticalAlignment = Element.ALIGN_LEFT;
                PdfPCell C7_6 = new PdfPCell();
                C7_6 = new PdfPCell(new Phrase("", der8));
                C7_6.VerticalAlignment = Element.ALIGN_LEFT;
                TABLA7.AddCell(C7_1);
                TABLA7.AddCell(C7_2);
                TABLA7.AddCell(C7_3);
                TABLA7.AddCell(C7_4);
                TABLA7.AddCell(C7_5);
                TABLA7.AddCell(C7_6);
                pdoc.Add(TABLA7);

                PdfPTable TABLA8 = new PdfPTable(new float[] { 67f, 17f, 16f });
                TABLA8.HorizontalAlignment = 1;
                TABLA8.WidthPercentage = 100f;
                PdfPCell C8_1 = new PdfPCell();
                C8_1 = new PdfPCell(new Phrase("D E S C R I P C I O N", SERIE9));
                C8_1.HorizontalAlignment = Element.ALIGN_CENTER;
                C8_1.VerticalAlignment = Element.ALIGN_CENTER;
                PdfPCell C8_2 = new PdfPCell();
                C8_2 = new PdfPCell(new Phrase("VR UNITARIO", SERIE9));
                C8_2.VerticalAlignment = Element.ALIGN_CENTER;
                PdfPCell C8_3 = new PdfPCell();
                C8_3 = new PdfPCell(new Phrase("VR TOTAL", SERIE9));
                C8_3.VerticalAlignment = Element.ALIGN_CENTER;
                PdfPCell C8_4 = new PdfPCell();
                C8_4 = new PdfPCell(new Phrase("SOLICITUD DE SERVICIO:  " + llanta.ORDEN_S, SERIE9));
                C8_4.VerticalAlignment = Element.ALIGN_CENTER;
                PdfPCell C8_5 = new PdfPCell();
                C8_5 = new PdfPCell(new Phrase("$ " + llanta.VALOR, SERIE9));
                C8_5.VerticalAlignment = Element.ALIGN_CENTER;
                PdfPCell C8_6 = new PdfPCell();
                C8_6 = new PdfPCell(new Phrase("$ " + llanta.VALOR, SERIE9));
                C8_6.VerticalAlignment = Element.ALIGN_CENTER;
                TABLA8.AddCell(C8_1);
                TABLA8.AddCell(C8_2);
                TABLA8.AddCell(C8_3);
                TABLA8.AddCell(C8_4);
                TABLA8.AddCell(C8_5);
                TABLA8.AddCell(C8_6);
                pdoc.Add(TABLA8);

                PdfPTable TABLA9 = new PdfPTable(new float[] { 22f, 30f, 15f, 17f, 16f });
                TABLA9.HorizontalAlignment = 1;
                TABLA9.WidthPercentage = 100f;
                PdfPCell C9_1 = new PdfPCell();
                C9_1 = new PdfPCell(new Phrase("MARCA: " + llanta.MARCA, SERIE9));
                C9_1.VerticalAlignment = Element.ALIGN_CENTER;
                C9_1.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell C9_2 = new PdfPCell();
                C9_2 = new PdfPCell(new Phrase("DIMENSION: " + llanta.TAMAÑO, SERIE9));
                C9_2.VerticalAlignment = Element.ALIGN_CENTER;
                PdfPCell C9_3 = new PdfPCell();
                C9_3 = new PdfPCell(new Phrase("SERIE: " + llanta.SERIE, SERIE9));
                C9_3.VerticalAlignment = Element.ALIGN_CENTER;
                PdfPCell C9_4 = new PdfPCell();
                C9_4 = new PdfPCell(new Phrase("", SERIE9));
                C9_4.VerticalAlignment = Element.ALIGN_CENTER;
                PdfPCell C9_5 = new PdfPCell();
                C9_5 = new PdfPCell(new Phrase("$ " + llanta.VALOR, SERIE9));
                C9_5.VerticalAlignment = Element.ALIGN_CENTER;

                TABLA9.AddCell(C9_1);
                TABLA9.AddCell(C9_2);
                TABLA9.AddCell(C9_3);
                TABLA9.AddCell(C9_4);
                TABLA9.AddCell(C9_5);
                pdoc.Add(TABLA9);

                PdfPTable TABLA10 = new PdfPTable(new float[] { 67f, 17f, 16f });
                TABLA10.HorizontalAlignment = 1;
                TABLA10.WidthPercentage = 100f;
                PdfPCell C10_1 = new PdfPCell();
                C10_1 = new PdfPCell(new Phrase("GARANTIA HASTA:  "+ llanta.FECHAG, SERIE9));
                C10_1.VerticalAlignment = Element.ALIGN_CENTER;
                PdfPCell C10_2 = new PdfPCell();
                C10_2 = new PdfPCell(new Phrase("LA LLANTA DE 2A. NO TIENE GARANTIA .", SERIE9));
                C10_2.VerticalAlignment = Element.ALIGN_CENTER;
                C10_2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                C10_2.Border = PdfPCell.RIGHT_BORDER;
                C10_2.Border = PdfPCell.LEFT_BORDER;
                PdfPCell C10_3 = new PdfPCell();
                C10_3 = new PdfPCell(new Phrase("1.-SOLO SE DA SOBRE LA REPARACION HECHA POR RETELL .", SERIE9));
                C10_3.VerticalAlignment = Element.ALIGN_CENTER;
                C10_3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                C10_3.Border = PdfPCell.RIGHT_BORDER;
                C10_3.Border = PdfPCell.LEFT_BORDER;
                PdfPCell C10_4 = new PdfPCell();
                C10_4 = new PdfPCell(new Phrase("2.-LA PRESION DE AIRE ES LA RECOMENDADA POR EL FABRICANTE.", SERIE9));
                C10_4.VerticalAlignment = Element.ALIGN_CENTER;
                C10_4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                C10_4.Border = PdfPCell.RIGHT_BORDER;
                C10_4.Border = PdfPCell.LEFT_BORDER;
                PdfPCell C10_5 = new PdfPCell();
                C10_5 = new PdfPCell(new Phrase("3.-LA LLANTA NO DEBE RODARSE SOBRE CARGADA,NI A BAJA PRESION CON RESPECTO AL PESO QUE ES SOMETIDA. ", SERIE9));
                C10_5.VerticalAlignment = Element.ALIGN_CENTER;
                C10_5.Border = iTextSharp.text.Rectangle.NO_BORDER;
                C10_5.Border = PdfPCell.RIGHT_BORDER;
                C10_5.Border = PdfPCell.LEFT_BORDER;
                PdfPCell C10_6 = new PdfPCell();
                C10_6 = new PdfPCell(new Phrase("4.- LA DURACION DE LA GARANTIA ES DE 90 DIAS. (A PARTIR DE LA FECHA DE RETIRO) Ó TERCERA PARTE DE LA PROFUNDIAD DE DISEÑO LO QUE SE CUMPLA PRIMERO." + llanta.VALOR, SERIE9));
                C10_6.VerticalAlignment = Element.ALIGN_CENTER;
                C10_6.Border = iTextSharp.text.Rectangle.NO_BORDER;
                C10_6.Border = PdfPCell.RIGHT_BORDER;
                C10_6.Border = PdfPCell.LEFT_BORDER;
                PdfPCell C10_7 = new PdfPCell();
                C10_7 = new PdfPCell(new Phrase("5.- NO DEBE TRATARSE DE MODIFICAR NUESTRA REPARACION.", SERIE9));
                C10_7.VerticalAlignment = Element.ALIGN_CENTER;
                C10_7.Border = iTextSharp.text.Rectangle.NO_BORDER;
                C10_7.Border = PdfPCell.RIGHT_BORDER;
                C10_7.Border = PdfPCell.LEFT_BORDER;
                PdfPCell C10_8 = new PdfPCell();
                C10_8 = new PdfPCell(new Phrase("6.-PRESENTAR EL ORIGINAL DE LA SOLICITUD DE SERVICIO.", SERIE9));
                C10_8.Border = iTextSharp.text.Rectangle.NO_BORDER;
                C10_8.Border = PdfPCell.RIGHT_BORDER;
                C10_8.Border = PdfPCell.LEFT_BORDER;
                C10_8.VerticalAlignment = Element.ALIGN_CENTER;
                PdfPCell C10_9 = new PdfPCell();
                C10_9 = new PdfPCell(new Phrase("7. POR NORMAS DE SEGURIDAD SE RECOMIENDA QUE LAS LLANTAS REPARADAS SE INSTALEN EN LOS EJES TRACEROS.", SERIE9));
                C10_9.VerticalAlignment = Element.ALIGN_CENTER;
                C10_9.Border = iTextSharp.text.Rectangle.NO_BORDER;
                C10_9.Border = PdfPCell.RIGHT_BORDER;
                C10_9.Border = PdfPCell.LEFT_BORDER;
                PdfPCell C10_10 = new PdfPCell();
                C10_10 = new PdfPCell(new Phrase("T    O    T    A    L", SERIE9));
                C10_10.HorizontalAlignment = Element.ALIGN_CENTER;
                C10_10.VerticalAlignment = Element.ALIGN_CENTER;
                PdfPCell C10_11 = new PdfPCell();
                C10_11 = new PdfPCell(new Phrase("", SERIE9));
                C10_11.Rowspan = 9;
                PdfPCell C10_12 = new PdfPCell();
                C10_12 = new PdfPCell(new Phrase("$ "+llanta.VALOR, SERIE9));
                TABLA10.AddCell(C10_1);
                TABLA10.AddCell(C10_11);
                TABLA10.AddCell(C10_11);
                TABLA10.AddCell(C10_2);
                TABLA10.AddCell(C10_3);
                TABLA10.AddCell(C10_4);
                TABLA10.AddCell(C10_5);
                TABLA10.AddCell(C10_6);
                TABLA10.AddCell(C10_7);
                TABLA10.AddCell(C10_8);
                TABLA10.AddCell(C10_9);
                TABLA10.AddCell(C10_10);
                TABLA10.AddCell(C10_12);
                TABLA10.AddCell(C10_12);
                pdoc.Add(TABLA10);

                PdfPTable TABLA11 = new PdfPTable(new float[] { 11f, 22f, 11f, 22f, 11f, 22f, 12f });
                TABLA11.HorizontalAlignment = 1;
                TABLA11.WidthPercentage = 100f;
                PdfPCell C11_1 = new PdfPCell();
                C11_1 = new PdfPCell(new Phrase("", SERIE9));
                C11_1.FixedHeight = 25;
                C11_1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                C11_1.VerticalAlignment = Element.ALIGN_CENTER;
                PdfPCell C11_2 = new PdfPCell();
                C11_2 = new PdfPCell(new Phrase("", SERIE9));
                C11_2.VerticalAlignment = Element.ALIGN_CENTER;
                C11_2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                PdfPCell C11_3 = new PdfPCell();
                C11_3 = new PdfPCell(new Phrase("", SERIE9));
                C11_3.VerticalAlignment = Element.ALIGN_CENTER;
                C11_3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                PdfPCell C11_4 = new PdfPCell();
                C11_4 = new PdfPCell(new Phrase("", SERIE9));
                C11_4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                C11_4.VerticalAlignment = Element.ALIGN_CENTER;

                PdfPCell C11_5 = new PdfPCell();
                C11_5 = new PdfPCell(new Phrase("", SERIE9));
                C11_5.Border = iTextSharp.text.Rectangle.NO_BORDER;
                C11_5.VerticalAlignment = Element.ALIGN_CENTER;
                C11_5.Border = PdfPCell.LEFT_BORDER;
                PdfPCell C11_6 = new PdfPCell();
                C11_6 = new PdfPCell(new Phrase("", SERIE9));
                C11_6.Border = iTextSharp.text.Rectangle.NO_BORDER;
                C11_6.Border = PdfPCell.RIGHT_BORDER;
                C11_6.VerticalAlignment = Element.ALIGN_CENTER;

                TABLA11.AddCell(C11_5);
                TABLA11.AddCell(C11_1);
                TABLA11.AddCell(C11_4);
                TABLA11.AddCell(C11_2);
                TABLA11.AddCell(C11_4);
                TABLA11.AddCell(C11_3);
                TABLA11.AddCell(C11_6);
                pdoc.Add(TABLA11);


                PdfPTable TABLA12 = new PdfPTable(new float[] { 5f, 26f, 5f, 27f, 5f, 26f, 5f });
                TABLA12.HorizontalAlignment = 1;
                TABLA12.WidthPercentage = 100f;
                PdfPCell C12_1 = new PdfPCell();
                C12_1 = new PdfPCell(new Phrase("FIRMA RECIBO", SERIE9));
                C12_1.FixedHeight = 10;
                C12_1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                C12_1.Border = PdfPCell.TOP_BORDER;
                C12_1.VerticalAlignment = Element.ALIGN_CENTER;
                PdfPCell C12_2 = new PdfPCell();
                C12_2 = new PdfPCell(new Phrase("FIRMA VENDEDOR", SERIE9));
                C12_2.VerticalAlignment = Element.ALIGN_CENTER;
                C12_2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                C12_2.Border = PdfPCell.TOP_BORDER;
                PdfPCell C12_3 = new PdfPCell();
                C12_3 = new PdfPCell(new Phrase("FIRMA CLIENTE", SERIE9));
                C12_3.VerticalAlignment = Element.ALIGN_CENTER;
                C12_3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                C12_3.Border = PdfPCell.TOP_BORDER;
                PdfPCell C12_4 = new PdfPCell();
                C12_4 = new PdfPCell(new Phrase("", SERIE9));
                C12_4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                C12_4.VerticalAlignment = Element.ALIGN_CENTER;
                TABLA12.AddCell(C11_5);
                TABLA12.AddCell(C12_1);
                TABLA12.AddCell(C12_4);
                TABLA12.AddCell(C12_2);
                TABLA12.AddCell(C12_4);
                TABLA12.AddCell(C12_3);
                TABLA12.AddCell(C11_6);
                pdoc.Add(TABLA12);

                PdfPTable TABLA13 = new PdfPTable(new float[] { 100f });
                TABLA13.HorizontalAlignment = 1;
                TABLA13.WidthPercentage = 100f;
                PdfPCell C13_1 = new PdfPCell();
                C13_1 = new PdfPCell(new Phrase("       Esta factura se asimila para todos sus efectos a una letra de Cambio conforme\r\n       a los articulos 621 y 774 del Código de Comercio.", der6));
                //C13_1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                //C13_1.Border = PdfPCell.RIGHT_BORDER;
                //C13_1.Border = PdfPCell.LEFT_BORDER;

                PdfPCell C13_2 = new PdfPCell();
                C13_2 = new PdfPCell(new Phrase("       a los articulos 621 y 774 del Código de Comercio.",der6));
                //C13_2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                //C13_2.Border = PdfPCell.RIGHT_BORDER;
                //C13_2.Border = PdfPCell.LEFT_BORDER;
                //C13_2.Border = PdfPCell.BOTTOM_BORDER;
                C13_2.VerticalAlignment = Element.ALIGN_CENTER;

                TABLA13.AddCell(C13_1);
                //TABLA13.AddCell(C13_2);
                pdoc.Add(TABLA13);
                pdoc.Add(pp4);
                pdoc.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void ResizeImage(string fileName, int width, int height,string NM)
        {
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(fileName))
            {
                new Bitmap(image, width, height).Save(NM);
            }
        }

        private void G_QR_Click(object sender, EventArgs e)
        {
            axAcroPDF1.Visible = true;
            String PA = AppDomain.CurrentDomain.BaseDirectory;
            String AA = @PA + @"\MS.pdf";
            axAcroPDF1.LoadFile(AA);
        }
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fad = new OpenFileDialog();
                fad.Filter = "All files (*.*)|*.*";
                fad.FilterIndex = 1;
                string ND = "", PATHFILE = "";
                if (fad.ShowDialog() == DialogResult.OK)
                {
                    PATHFILE = System.IO.Path.GetFullPath(fad.FileName);
                    ND = fad.SafeFileName;
                }
                string host = "jfingfgar.duckdns.org";
                string username = "pi";
                string password = "JFing";
                //string remoteDirectory = @"/media/pi/RS1/DataBase/EQUIPOS/" + TAGR + "/HistorialMantenimientos/" + "Historico_" + cuenta + ".pdf";
                string remoteDirectory2 = "/home/pi/DataBase/EQUIPOS/" + M1+ "/Anexos/" + ND;
                string pathLocalFile = @PATHFILE;
                label3.Text = remoteDirectory2+"-"+PATHFILE;
                //COMENTARIOS_MAN.Text = remoteDirectory;
                using (SftpClient sftp = new SftpClient(host, username, password))
                {
                   sftp.Connect();
                    using (Stream fileStream = File.OpenRead(pathLocalFile))
                    {
                        sftp.UploadFile(fileStream, remoteDirectory2);
                    }
                    sftp.Disconnect();
                }
                //CREAR BASE DE DATOS
                ForwardedPortLocal port = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                SshClient client = new SshClient("jfingfgar.duckdns.org", "pi", "JFing");
                client.Connect();
                client.AddForwardedPort(port);
                port.Start();
                string connectionString = "SERVER=127.0.0.1;port=3306;username=root2;password=JFing;database=ANEXOS";
                string query = "INSERT INTO " + M1 + "(`PATH`) VALUES ('" + ND + "')";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand ard = new MySqlCommand(query, databaseConnection);
                ard.CommandTimeout = 60;
                databaseConnection.Open();
                MySqlDataReader myReader = ard.ExecuteReader();
                databaseConnection.Close();
                client.Disconnect();
                MessageBox.Show("Archivo Cargado Exitosamente");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }



        public void ContadorDescargas()
        {
            try
            {
                string AñoE = DateTime.Now.Year.ToString();
                string MesE = DateTime.Now.Month.ToString();
                string DiaE = DateTime.Now.Day.ToString();
                string M = DiaE + "/" + MesE + "/" + AñoE;
                //CREAR BASE DE DATOS
                ForwardedPortLocal port = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                SshClient client = new SshClient("jfingfgar.duckdns.org", "pi", "JFing");
                client.Connect();
                client.AddForwardedPort(port);
                port.Start();
                string connectionString = "SERVER=127.0.0.1;port=3306;username=root2;password=JFing;database=DESCARGAS";
                string query = "INSERT INTO DATA(`FECHA`) VALUES ('"+M+"')";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand ard = new MySqlCommand(query, databaseConnection);
                ard.CommandTimeout = 60;
                databaseConnection.Open();
                MySqlDataReader myReader = ard.ExecuteReader();
                databaseConnection.Close();
                client.Disconnect();
            }
            catch(Exception E)
            {
                MessageBox.Show(E.Message);
            }
            
        }
        public void VISTAS()
        {
            try
            {
                string AñoE = DateTime.Now.Year.ToString();
                string MesE = DateTime.Now.Month.ToString();
                string DiaE = DateTime.Now.Day.ToString();
                string M = DiaE + "/" + MesE + "/" + AñoE;
                //CREAR BASE DE DATOS
                ForwardedPortLocal port = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                SshClient client = new SshClient("jfingfgar.duckdns.org", "pi", "JFing");
                client.Connect();
                client.AddForwardedPort(port);
                port.Start();
                string connectionString = "SERVER=127.0.0.1;port=3306;username=root2;password=JFing;database=VIEW";
                string query = "INSERT INTO DATA(`FECHA`) VALUES ('" + M + "')";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand ard = new MySqlCommand(query, databaseConnection);
                ard.CommandTimeout = 60;
                databaseConnection.Open();
                MySqlDataReader myReader = ard.ExecuteReader();
                databaseConnection.Close();
                client.Disconnect();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            axAcroPDF1.Visible = true;
            String PA = AppDomain.CurrentDomain.BaseDirectory;
            String AA = @PA + @"\INFORME_REPARACION.pdf";
            axAcroPDF1.LoadFile(AA);
        }
        private void CrearInforme()
        {
            //GENERAR PDF
            try
            {
                String PA = AppDomain.CurrentDomain.BaseDirectory;
                String AA = @PA + @"\INFORME_REPARACION.pdf";
                String AB = @PA + @"\IMG1.png";
                String AC = @PA + @"\IMG2.png";
                String AD = @PA + @"\IMGE.png";
                String AE = @PA + @"\IMGD.png";
                String P1S = @PA + @"\P1S.png";
                String AN1 = @PA + @"\AN1.jpg";
                //CARGAR FUENTE
                BaseFont Titulo = BaseFont.CreateFont("c:\\windows\\fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font der2 = new iTextSharp.text.Font(Titulo, 22);
                iTextSharp.text.Font der3 = new iTextSharp.text.Font(Titulo, 12);
                iTextSharp.text.Font der1 = new iTextSharp.text.Font(Titulo, 4);
                //CREAR QR
                QRCoder.QRCodeGenerator QR = new QRCoder.QRCodeGenerator();
                QRCoder.QRCodeData NA = QR.CreateQrCode(M1, QRCoder.QRCodeGenerator.ECCLevel.H);
                QRCoder.QRCode QRCODE = new QRCoder.QRCode(NA);
                Bitmap qrImage = QRCODE.GetGraphic(20);
                qrImage.Save(AC);
                using (System.Drawing.Image im = System.Drawing.Image.FromFile(AC))
                {
                    new Bitmap(im, 250, 250).Save(AD);
                    new Bitmap(im, 250, 250).Save(AE);
                }
                Document pdoc = new Document(iTextSharp.text.PageSize.A4.Rotate(), 0f, 0f, 35f, 0f);
                PdfWriter pWriter = PdfWriter.GetInstance(pdoc, new FileStream(AA, FileMode.Create));
                pdoc.Open();
                // CREAR MEMBRETE
                PdfPTable TABLA1 = new PdfPTable(new float[] { 35f, 30f, 24f, 11f });
                TABLA1.HorizontalAlignment = 1;
                //CARGAR QR
                iTextSharp.text.Image myImage = iTextSharp.text.Image.GetInstance(AC);
                PdfPCell celda = new PdfPCell(myImage);
                celda.Border = PdfPCell.NO_BORDER;
                celda.Border = PdfPCell.TOP_BORDER | PdfPCell.BOTTOM_BORDER | PdfPCell.RIGHT_BORDER;
                celda.BorderWidthRight = 2f;
                celda.BorderWidthTop = 2f;
                celda.BorderWidthBottom = 0.5f;
                celda.BorderWidth = 2f;
                celda.FixedHeight = 70;
                celda.Padding = 3f;
                //CARGAR LOGO RETELL
                iTextSharp.text.Image RETELL = iTextSharp.text.Image.GetInstance(P1S);
                PdfPCell Cretell = new PdfPCell(RETELL);
                Cretell.HorizontalAlignment = Element.ALIGN_RIGHT;
                Cretell.FixedHeight = 70;
                Cretell.Padding = 3;
                Cretell.Border = PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.BOTTOM_BORDER;
                Cretell.BorderWidthLeft = 0.5f;
                Cretell.BorderWidthTop = 2f;
                Cretell.BorderWidthBottom = 0.5f;
                //TEXTO DE INFORME 
                der2.SetColor(0, 0, 0);
                PdfPCell C1 = new PdfPCell(new Phrase("INFORME DE REPARACION", der2));
                C1.HorizontalAlignment = Element.ALIGN_CENTER;
                C1.BackgroundColor = new iTextSharp.text.BaseColor(240, 233, 210);
                C1.VerticalAlignment = Element.ALIGN_MIDDLE;
                C1.BorderWidthLeft = 2f;
                C1.BorderWidthTop = 2f;
                C1.BorderWidthRight = 0.5f;
                C1.BorderWidthBottom = 0.5F;
                //CARGAR LOGO TAPRAP
                iTextSharp.text.Image TAPRAP = iTextSharp.text.Image.GetInstance(AN1);
                PdfPCell CTAPRAP = new PdfPCell(TAPRAP);
                CTAPRAP.HorizontalAlignment = 1;
                CTAPRAP.VerticalAlignment = Element.ALIGN_MIDDLE;
                CTAPRAP.FixedHeight = 70;
                CTAPRAP.Padding = 3;
                CTAPRAP.BorderWidthLeft = 0.5f;
                CTAPRAP.BorderWidthTop = 2f;
                CTAPRAP.BorderWidthRight = 0.5f;
                CTAPRAP.BorderWidthBottom = 0.5F;
                TABLA1.AddCell(C1);
                TABLA1.AddCell(CTAPRAP);
                TABLA1.AddCell(Cretell);
                TABLA1.AddCell(celda);
                PdfPCell CF1 = new PdfPCell(new Phrase());
                CF1.BackgroundColor = new iTextSharp.text.BaseColor(9, 0, 0);
                CF1.FixedHeight = 4f;
                CF1.Colspan = 4;
                TABLA1.AddCell(CF1);
                pdoc.Add(TABLA1);
                int R1 = 21;

                //TABLA 2
                PdfPTable TABLA2 = new PdfPTable(new float[] { 35f, 14f, 14f, 2f, 35f });
                TABLA2.HorizontalAlignment = 1;
                //TRAER IMAGENES
                String X1 = @PA + @"\X1.jpeg";
                iTextSharp.text.Image IX1 = iTextSharp.text.Image.GetInstance(X1);
                PdfPCell F2_1 = new PdfPCell(IX1);
                F2_1.FixedHeight = 150f;
                F2_1.HorizontalAlignment = 1;
                F2_1.Padding = 2;
                F2_1.BorderWidthRight = 0.5f;
                F2_1.BorderWidthLeft = 2f;
                F2_1.BorderWidthTop = 0.5f;
                F2_1.BorderWidthBottom = 0.5f;
                F2_1.Rowspan = R1;
                //IMAGEN 2
                String X2 = @PA + @"\X2.jpeg";
                iTextSharp.text.Image IX2 = iTextSharp.text.Image.GetInstance(X2);
                PdfPCell F2_2 = new PdfPCell(IX2);
                F2_2.FixedHeight = 150f;
                F2_2.HorizontalAlignment = 1;
                F2_2.Padding = 2;
                F2_2.BorderWidthRight = 2;
                F2_2.BorderWidthLeft = 0.5f;
                F2_2.BorderWidthTop = 0.5f;
                F2_2.BorderWidthBottom = 0.5f;
                F2_2.Rowspan = R1;
                //INFORMACION DE REPARACION 
                PdfPCell C1_2 = new PdfPCell(new Phrase("INFORMACION LLANTA", der3));
                C1_2.HorizontalAlignment = Element.ALIGN_CENTER;
                C1_2.VerticalAlignment = Element.ALIGN_MIDDLE;
                C1_2.BorderWidth = 1f;
                C1_2.Colspan = 3;
                C1_2.FixedHeight = 19f;
                C1_2.Border = PdfPCell.NO_BORDER;
                //ESPACIO EN BLANCO  1
                PdfPCell B2_1 = new PdfPCell(new Phrase(""));
                B2_1.Border = PdfPCell.NO_BORDER;
                B2_1.Colspan = 3;
                B2_1.FixedHeight = 3f;
                //LINEA-1
                TABLA2.AddCell(F2_1);
                TABLA2.AddCell(C1_2);
                TABLA2.AddCell(F2_2);
                //BLANCO
                TABLA2.AddCell(B2_1);
                //SERIE-TEX
                PdfPCell M1_1 = CrearCELDAS("SERIE:", 7, 1, 1, 2, 6);
                M1_1.Border = PdfPCell.NO_BORDER;
                PdfPCell M1_2 = CrearCELDAS(llanta.SERIE, 7, 1, 1, 1, 1);
                //ESPACIO EN BLACO 2
                PdfPCell B2_2 = new PdfPCell(new Phrase(""));
                B2_2.Border = PdfPCell.NO_BORDER;
                //LINEA-2
                TABLA2.AddCell(M1_1);
                TABLA2.AddCell(M1_2);
                TABLA2.AddCell(B2_2);
                //BLANCO
                TABLA2.AddCell(B2_1);
                //MARCA
                PdfPCell M2_1 = CrearCELDAS("MARCA:", 7, 1, 1, 2, 6);
                M2_1.Border = PdfPCell.NO_BORDER;
                PdfPCell M2_2 = CrearCELDAS(llanta.MARCA, 7, 1, 1, 1, 1);
                //LINEA-3
                TABLA2.AddCell(M2_1);
                TABLA2.AddCell(M2_2);
                TABLA2.AddCell(B2_2);
                TABLA2.AddCell(B2_1);
                //LINEA 4
                //TAMAÑO INFORMACION
                PdfPCell M3_1 = CrearCELDAS("MEDIDA:", 7, 1, 1, 2, 6);
                M3_1.Border = PdfPCell.NO_BORDER;
                PdfPCell M3_2 = CrearCELDAS(llanta.TAMAÑO, 7, 1, 1, 1, 0);
                TABLA2.AddCell(M3_1);
                TABLA2.AddCell(M3_2);
                TABLA2.AddCell(B2_2);
                TABLA2.AddCell(B2_1);
                //LINEA 5
                //FECHA DE NGRESO
                PdfPCell M4_1 = CrearCELDAS("FECHA INGRESO:", 7, 1, 1, 2, 6);
                M4_1.Border = PdfPCell.NO_BORDER;
                PdfPCell M4_2 = CrearCELDAS(llanta.FECHA, 7, 1, 1, 1, 1);
                TABLA2.AddCell(M4_1);
                TABLA2.AddCell(M4_2);
                TABLA2.AddCell(B2_2);
                TABLA2.AddCell(B2_1);
                //LINEA 6
                PdfPCell M5_1 = CrearCELDAS("FECHA ENTREGA:", 7, 1, 1, 2, 6);
                M5_1.Border = PdfPCell.NO_BORDER;
                PdfPCell M5_2 = CrearCELDAS(llanta.FECHAE, 7, 1, 1, 1, 1);
                TABLA2.AddCell(M5_1);
                TABLA2.AddCell(M5_2);
                TABLA2.AddCell(B2_2);
                TABLA2.AddCell(B2_1);
                //LINEA 7
                PdfPCell M6_1 = CrearCELDAS("%", 7, 1, 1, 2, 6);
                M6_1.Border = PdfPCell.NO_BORDER;
                PdfPCell M6_2 = CrearCELDAS("10%", 7, 1, 1, 1, 1);
                TABLA2.AddCell(M6_1);
                TABLA2.AddCell(M6_2);
                TABLA2.AddCell(B2_2);
                TABLA2.AddCell(B2_1);
                //LINEA 8
                PdfPCell M7_1 = CrearCELDAS("OPERADOR", 7, 1, 1, 2, 6);
                M7_1.Border = PdfPCell.NO_BORDER;
                PdfPCell M7_2 = CrearCELDAS("MOVIL 1", 7, 1, 1, 1, 1);
                TABLA2.AddCell(M7_1);
                TABLA2.AddCell(M7_2);
                TABLA2.AddCell(B2_2);
                TABLA2.AddCell(B2_1);
                //LINEA 9
                PdfPCell M8_1 = CrearCELDAS("PLACA", 7, 1, 1, 2, 6);
                M8_1.Border = PdfPCell.NO_BORDER;
                PdfPCell M8_2 = CrearCELDAS("UUX-93D", 7, 1, 1, 1, 1);
                TABLA2.AddCell(M8_1);
                TABLA2.AddCell(M8_2);
                TABLA2.AddCell(B2_2);
                TABLA2.AddCell(B2_1);
                CF1.Colspan = 3;

                PdfPCell C1_3 = new PdfPCell(new Phrase("INFORMACION DAÑO", der3));
                C1_3.HorizontalAlignment = Element.ALIGN_CENTER;
                C1_3.VerticalAlignment = Element.ALIGN_MIDDLE;
                C1_3.BorderWidth = 1.5f;
                C1_3.Colspan = 3;
                C1_3.Border = PdfPCell.TOP_BORDER;

                C1_3.FixedHeight = 20f;
                TABLA2.AddCell(CF1);
                TABLA2.AddCell(C1_3);
                TABLA2.AddCell(B2_1);
                //TRAER IMAGENES
                String X3 = @PA + @"\X3.jpeg";
                iTextSharp.text.Image IX3 = iTextSharp.text.Image.GetInstance(X3);
                PdfPCell F2_3 = new PdfPCell(IX3);
                F2_3.FixedHeight = 150f;
                F2_3.HorizontalAlignment = 1;
                F2_3.Padding = 2;
                F2_3.BorderWidthRight = 0.5f;
                F2_3.BorderWidthLeft = 2f;
                F2_3.BorderWidthTop = 0.5f;
                F2_3.BorderWidthBottom = 0.5f;
                F2_3.Rowspan = R1;
                //IMAGEN 2
                String X4 = @PA + @"\X5.jpeg";
                iTextSharp.text.Image IX4 = iTextSharp.text.Image.GetInstance(X4);
                PdfPCell F2_4 = new PdfPCell(IX4);
                F2_4.FixedHeight = 150f;
                F2_4.HorizontalAlignment = 1;
                F2_4.Padding = 2;
                F2_4.BorderWidthRight = 2;
                F2_4.BorderWidthLeft = 0.5f;
                F2_4.BorderWidthTop = 0.5f;
                F2_4.BorderWidthBottom = 0.5f;
                F2_4.Rowspan = R1;
                PdfPCell D1_1 = CrearCELDAS("BANDA:", 7, 1, 1, 2, 6);
                D1_1.Border = PdfPCell.NO_BORDER;
                PdfPCell D1_2 = CrearCELDAS(llanta.BANDA, 7, 1, 1, 1, 1);
                TABLA2.AddCell(F2_3);
                TABLA2.AddCell(D1_1);
                TABLA2.AddCell(D1_2);
                TABLA2.AddCell(B2_2);

                TABLA2.AddCell(F2_4);
                TABLA2.AddCell(B2_1);

                PdfPCell D2_1 = CrearCELDAS("COSTADO:", 7, 1, 1, 2, 6);
                D2_1.Border = PdfPCell.NO_BORDER;
                PdfPCell D2_2 = CrearCELDAS(llanta.COSTADO, 7, 1, 1, 1, 1);
                TABLA2.AddCell(D2_1);
                TABLA2.AddCell(D2_2);
                TABLA2.AddCell(B2_2);
                TABLA2.AddCell(B2_1);
                PdfPCell D3_1 = CrearCELDAS("HOMBRO:", 7, 1, 1, 2, 6);
                D3_1.Border = PdfPCell.NO_BORDER;
                PdfPCell D3_2 = CrearCELDAS(llanta.HOMBRO, 7, 1, 1, 1, 1);
                TABLA2.AddCell(D3_1);
                TABLA2.AddCell(D3_2);
                TABLA2.AddCell(B2_2);
                TABLA2.AddCell(B2_1);

                PdfPCell D4_1 = CrearCELDAS("OTRO:", 7, 1, 1, 2, 6);
                D4_1.Border = PdfPCell.NO_BORDER;
                PdfPCell D4_2 = CrearCELDAS(llanta.HOMBRO, 7, 1, 1, 1, 1);
                TABLA2.AddCell(D4_1);
                TABLA2.AddCell(D4_2);
                TABLA2.AddCell(B2_2);
                TABLA2.AddCell(B2_1);
                PdfPCell D5_1 = CrearCELDAS("LONG LARGO cm:", 7, 1, 1, 2, 6);
                D5_1.Border = PdfPCell.NO_BORDER;
                PdfPCell D5_2 = CrearCELDAS(llanta.HOMBRO, 7, 1, 1, 1, 1);
                TABLA2.AddCell(D5_1);
                TABLA2.AddCell(D5_2);
                TABLA2.AddCell(B2_2);
                TABLA2.AddCell(B2_1);
                PdfPCell D6_1 = CrearCELDAS("LONG ANCHO cm:", 7, 1, 1, 2, 6);
                D6_1.Border = PdfPCell.NO_BORDER;
                PdfPCell D6_2 = CrearCELDAS(llanta.HOMBRO, 7, 1, 1, 1, 1);
                TABLA2.AddCell(D6_1);
                TABLA2.AddCell(D6_2);
                TABLA2.AddCell(B2_2);
                TABLA2.AddCell(B2_1);

                PdfPCell D7_1 = CrearCELDAS("PROFUNDIDAD mm:", 7, 1, 1, 2, 6);
                D7_1.Border = PdfPCell.NO_BORDER;
                PdfPCell D7_2 = CrearCELDAS(llanta.HOMBRO, 7, 1, 1, 1, 1);
                TABLA2.AddCell(D7_1);
                TABLA2.AddCell(D7_2);
                TABLA2.AddCell(B2_2);
                TABLA2.AddCell(B2_1);

                PdfPCell D8_1 = CrearCELDAS("PROFUNDIDAD mm:", 7, 1, 1, 2, 6);
                D8_1.Border = PdfPCell.NO_BORDER;
                PdfPCell D8_2 = CrearCELDAS(llanta.HOMBRO, 7, 1, 1, 1, 1);
                TABLA2.AddCell(D8_1);
                TABLA2.AddCell(D8_2);
                TABLA2.AddCell(B2_2);
                TABLA2.AddCell(B2_1);

                pdoc.Add(TABLA2);

                PdfPCell BLANCO_D = CrearCELDAS("", 7, 1, 1, 2, 1);
                BLANCO_D.Border = PdfPCell.RIGHT_BORDER;
                PdfPCell BLANCO_I = CrearCELDAS("", 7, 1, 1, 2, 1);
                BLANCO_I.Border = PdfPCell.LEFT_BORDER;
                PdfPCell BLANCO2_I = CrearCELDAS("", 7, 1, 1, 2, 1);
                BLANCO2_I.Border = PdfPCell.LEFT_BORDER;
                BLANCO2_I.FixedHeight = 3f;
                PdfPCell B2_5 = CrearCELDAS("", 7, 1, 1, 2, 1);
                B2_5.Border = PdfPCell.NO_BORDER;

                PdfPTable TABLA3 = new PdfPTable(new float[] { 11f, 2f, 11f, 2f, 11f, 4f, 11f, 2f, 11f, 4f, 11f, 2f, 11f, 2f });
                CF1.Colspan = 14;
                TABLA3.HorizontalAlignment = 1;
                TABLA3.AddCell(CF1);

                PdfPCell CX1_1 = CrearCELDAS("UNIDADES DE RPARACION UTILIZADAS", 7, 1, 1, 2, 6);
                CX1_1.Border = PdfPCell.LEFT_BORDER;
                CX1_1.Colspan = 5;
                PdfPCell CX1_2 = CrearCELDAS("MATERIALES BASICOS", 7, 1, 1, 1, 1);
                CX1_2.Border = PdfPCell.NO_BORDER;
                CX1_2.Colspan = 3;
                B2_2.Colspan = 14;
                PdfPCell B2_3 = CrearCELDAS("", 7, 14, 1, 1, 1);
                B2_3.FixedHeight = 3f;
                B2_3.Colspan = 14;
                B2_3.Border = PdfPCell.RIGHT_BORDER | PdfPCell.LEFT_BORDER;
                TABLA3.AddCell(B2_3);
                TABLA3.AddCell(CX1_1);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(CX1_2);
                BLANCO_D.Colspan = 5;
                TABLA3.AddCell(BLANCO_D);
                BLANCO_D.Colspan = 1;

                //CC
                PdfPCell W1_1 = CrearCELDAS("CINTURON RADIAL:", 5, 1, 1, 2, 1);
                W1_1.Border = PdfPCell.LEFT_BORDER;
                PdfPCell W1_2 = CrearCELDAS("RETELL CR", 5, 1, 1, 1, 1);
                PdfPCell W1_3 = CrearCELDAS("250gr", 5, 1, 1, 1, 1);
                PdfPCell W1_4 = CrearCELDAS("CAUCHO COJIN:", 5, 1, 1, 2, 1);
                W1_4.Border = PdfPCell.NO_BORDER;
                PdfPCell W1_5 = CrearCELDAS("300gr", 5, 1, 1, 1, 1);
                PdfPCell W1_6 = CrearCELDAS("TIEMPO DE VULCANIZACION", 5, 1, 1, 1, 1);
                W1_6.Border = PdfPCell.NO_BORDER;
                W1_6.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                PdfPCell W1_7 = CrearCELDAS("120h", 5, 1, 1, 1, 1);
                W1_7.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                TABLA3.AddCell(B2_3);
                TABLA3.AddCell(W1_1);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W1_2);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W1_3);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W1_4);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W1_5);
                
                B2_5.Rowspan = 3;
                W1_6.Rowspan = 3;
                W1_7.Rowspan = 3;
                BLANCO_D.Rowspan = 3;

                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W1_6);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W1_7);
                TABLA3.AddCell(BLANCO_D);
                B2_3.Border = PdfPCell.RIGHT_BORDER | PdfPCell.LEFT_BORDER;
                BLANCO2_I.Colspan = 9;
                TABLA3.AddCell(BLANCO2_I);
                B2_5.Rowspan = 1;
                BLANCO_D.Rowspan = 1;

                PdfPCell W2_1 = CrearCELDAS("PROTECTORES:", 5, 1, 1, 2, 1);
                W2_1.Border = PdfPCell.LEFT_BORDER;
                PdfPCell W2_2 = CrearCELDAS("RETELL CR", 5, 1, 1, 1, 1);
                PdfPCell W2_3 = CrearCELDAS("250gr", 5, 1, 1, 1, 1);
                PdfPCell W2_4 = CrearCELDAS("CAUCHO BLANDO:", 5, 1, 1, 2, 1);
                W2_4.Border = PdfPCell.NO_BORDER;
                PdfPCell W2_5 = CrearCELDAS("300gr", 5, 1, 1, 1, 1);

                    TABLA3.AddCell(W2_1);
                    TABLA3.AddCell(B2_5);
                    TABLA3.AddCell(W2_2);
                    TABLA3.AddCell(B2_5);
                    TABLA3.AddCell(W2_3);
                    TABLA3.AddCell(B2_5);
                    TABLA3.AddCell(W2_4);       
                    TABLA3.AddCell(B2_5);
                    TABLA3.AddCell(W2_5);
                TABLA3.AddCell(B2_3);

                //
                PdfPCell W3_1 = CrearCELDAS("UNIDAD DE REPARACION U:", 5, 1, 1, 2, 1);
                W3_1.Border = PdfPCell.LEFT_BORDER;
                PdfPCell W3_2 = CrearCELDAS("RETELL CR", 5, 1, 1, 1, 1);
                PdfPCell W3_3 = CrearCELDAS("250gr", 5, 1, 1, 1, 1);
                PdfPCell W3_4 = CrearCELDAS("CAUCHO DURO:", 5, 1, 1, 2, 1);
                W3_4.Border = PdfPCell.NO_BORDER;
                PdfPCell W3_5 = CrearCELDAS("300gr", 5, 1, 1, 1, 1);
                PdfPCell W3_6 = CrearCELDAS("HORAS DE TRABAJO:", 5, 1, 1, 2, 1);
                W3_6.Border = PdfPCell.NO_BORDER;
                W3_6.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                PdfPCell W3_7 = CrearCELDAS("120h", 5, 1, 1, 1, 1);
                W3_7.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                TABLA3.AddCell(W3_1);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W3_2);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W3_3);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W3_4);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W3_5);
                B2_5.Rowspan = 3;
                W3_6.Rowspan = 3;
                W3_7.Rowspan = 3;
                BLANCO_D.Rowspan = 3;
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W3_6);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W3_7);
                TABLA3.AddCell(BLANCO_D);
                BLANCO2_I.Colspan = 9;
                TABLA3.AddCell(BLANCO2_I);
                B2_5.Rowspan = 1;
                BLANCO_D.Rowspan = 1;

                //
                PdfPCell W4_1 = CrearCELDAS("UNIDAD DE REPARACION F:", 5, 1, 1, 2, 1);
                W4_1.Border = PdfPCell.LEFT_BORDER;
                PdfPCell W4_2 = CrearCELDAS("RETELL CR", 5, 1, 1, 1, 1);
                PdfPCell W4_3 = CrearCELDAS("250gr", 5, 1, 1, 1, 1);
                PdfPCell W4_4 = CrearCELDAS("CORDON FABRE:", 5, 1, 1, 2, 1);
                W4_4.Border = PdfPCell.NO_BORDER;
                PdfPCell W4_5 = CrearCELDAS("300gr", 5, 1, 1, 1, 1);
                TABLA3.AddCell(W4_1);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W4_2);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W4_3);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W4_4);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W4_5);
                //CC
                PdfPCell W5_1 = CrearCELDAS("UNIDAD DE REPARACION MC:", 5, 1, 1, 2, 1);
                W5_1.Border = PdfPCell.LEFT_BORDER;
                PdfPCell W5_2 = CrearCELDAS("RETELL CR", 5, 1, 1, 1, 1);
                PdfPCell W5_3 = CrearCELDAS("250gr", 5, 1, 1, 1, 1);
                PdfPCell W5_4 = CrearCELDAS("CEMENTO:", 5, 1, 1, 2, 1);
                W5_4.Border = PdfPCell.NO_BORDER;
                PdfPCell W5_5 = CrearCELDAS("300gr", 5, 1, 1, 1, 1);
                PdfPCell W5_6 = CrearCELDAS("", 5, 1, 1, 1, 1);
                W5_6.Border = PdfPCell.NO_BORDER;
                W5_6.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                PdfPCell W5_7 = CrearCELDAS("", 5, 1, 1, 1, 1);
                W5_7.Border = PdfPCell.NO_BORDER;
                W5_7.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                TABLA3.AddCell(B2_3);
                TABLA3.AddCell(W5_1);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W5_2);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W5_3);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W5_4);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W5_5);

                B2_5.Rowspan = 3;
                W5_6.Rowspan = 3;
                W5_7.Rowspan = 3;
                BLANCO_D.Rowspan = 3;

                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W5_6);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W5_7);
                TABLA3.AddCell(BLANCO_D);
                BLANCO2_I.Colspan = 9;
                TABLA3.AddCell(BLANCO2_I);
                B2_5.Rowspan = 1;
                BLANCO_D.Rowspan = 1;

                PdfPCell W6_1 = CrearCELDAS("UNIDAD DE REPARACION BC:", 5, 1, 1, 2, 1);
                W6_1.Border = PdfPCell.LEFT_BORDER;
                PdfPCell W6_2 = CrearCELDAS("RETELL CR", 5, 1, 1, 1, 1);
                PdfPCell W6_3 = CrearCELDAS("250gr", 5, 1, 1, 1, 1);
                PdfPCell W6_4 = CrearCELDAS("DISOLVENTE:", 5, 1, 1, 2, 1);
                W6_4.Border = PdfPCell.NO_BORDER;
                PdfPCell W6_5 = CrearCELDAS("30gr", 5, 1, 1, 1, 1);
                TABLA3.AddCell(W6_1);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W6_2);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W6_3);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W6_4);
                TABLA3.AddCell(B2_5);
                TABLA3.AddCell(W6_5);
                B2_3.Border = PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER | PdfPCell.BOTTOM_BORDER;
                TABLA3.AddCell(B2_3);

                pdoc.Add(TABLA3);
                pdoc.Close();   

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private PdfPCell CrearCELDAS(string TEXTO, int TamañoLetra, int Colspan, int Rowspan, int HAlignament, int PADDING)
        {
            BaseFont Titulo = BaseFont.CreateFont("c:\\windows\\fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font der1 = new iTextSharp.text.Font(Titulo, TamañoLetra);
            PdfPCell A1 = new PdfPCell(new Phrase(TEXTO, der1));
            A1.Colspan = Colspan;
            A1.Rowspan = Rowspan;
            A1.PaddingRight = PADDING;
            A1.VerticalAlignment = Element.ALIGN_CENTER;
            A1.HorizontalAlignment = HAlignament;
            A1.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            return A1;
            /*ALIGNAMENT INT VALUES
             * ALIGN_LEFT=0
             * ALIGN_CENTER=1
             * ALIGN_RIGHT=2
            */

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Materiales DMateriales = new Materiales();
            DMateriales.M1 = M1;
            DMateriales.Visible = true;
            DMateriales.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click_1(object sender, EventArgs e)
        {
            iconButton4.Visible = false;
            iconButton6.Visible = true;
            iconButton5.Visible = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            T_Marca.Enabled = true;
            T_Tamaño.Enabled = true;
            T_Serie.Enabled = true;
            T_Nombre.Enabled = true;
            T_Valor.Enabled = true;
            T_Abono.Enabled = true;
            T_Direccion.Enabled = true;
            T_Barrio.Enabled = true;
            T_Ciudad.Enabled = true;
            T_Telefono.Enabled = true;
            C_Estado.Enabled = true;
            C_Lote.Enabled = true;
            C_Posicion.Enabled = true;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show( "Desea cancelar el cambio de datos?", "Advertencia", MessageBoxButtons.OKCancel);
            if (dialog == DialogResult.OK)
            {
                iconButton6.Visible = false;
                iconButton5.Visible = false;
                iconButton4.Visible = true;
                T_Marca.Text = llanta.MARCA;
                T_Tamaño.Text = llanta.TAMAÑO;
                T_Serie.Text = llanta.SERIE;
                T_Valor.Text = llanta.VALOR;
                T_Abono.Text = llanta.ABONO;
                T_Nombre.Text = llanta.SOLICITANTE;
                T_Orden.Text = llanta.ORDEN_S;
                T_Direccion.Text = llanta.DIRECCION;
                T_Barrio.Text = llanta.BARRIO;
                T_Ciudad.Text = llanta.CIUDAD;
                T_Telefono.Text = llanta.TELEFONO;
                T_Marca.Enabled = false;
                T_Tamaño.Enabled = false;
                T_Serie.Enabled = false;
                T_Nombre.Enabled = false;
                T_Valor.Enabled = false;
                T_Abono.Enabled = false;
                T_Direccion.Enabled = false;
                T_Barrio.Enabled = false;
                T_Ciudad.Enabled = false;
                T_Telefono.Enabled = false;
                C_Estado.Enabled = false;
                C_Lote.Enabled = false;
                C_Posicion.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;

            }
            else if(dialog==DialogResult.Cancel)
            {
                
            }
            
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Desea cambiar los datos?", "Advertencia", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {

                llanta.MARCA = T_Marca.Text;
                llanta.TAMAÑO = T_Tamaño.Text;
                llanta.SERIE = T_Serie.Text;
                DateTime D1 = dateTimePicker1.Value;
                DateTime D2 = dateTimePicker2.Value;
                llanta.FECHA = D1.ToString("dd/MM/yy");
                llanta.FECHAS = D2.ToString("dd/MM/yy");
                llanta.VALOR = T_Valor.Text;
                llanta.ABONO = T_Abono.Text;
                llanta.SOLICITANTE = T_Nombre.Text;
                llanta.DIRECCION = T_Direccion.Text;
                llanta.BARRIO = T_Barrio.Text;
                llanta.CIUDAD = T_Ciudad.Text;
                llanta.TELEFONO = T_Telefono.Text;
                llanta.E_A = C_Estado.Text;
                llanta.POSICION = C_Posicion.Text;
                llanta.UBICACION = C_Lote.Text;
                if (llanta.Actualizar())
                {
                    iconButton4.Visible = true;
                    iconButton5.Visible = false;
                    iconButton6.Visible = false;
                    MessageBox.Show("Actualizado con Exito");
                    T_Marca.Enabled = false;
                    T_Tamaño.Enabled = false;
                    T_Serie.Enabled = false;
                    T_Nombre.Enabled = false;
                    T_Valor.Enabled = false;
                    T_Abono.Enabled = false;
                    T_Direccion.Enabled = false;
                    T_Barrio.Enabled = false;
                    T_Ciudad.Enabled = false;
                    T_Telefono.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    dateTimePicker2.Enabled = false;
                    C_Estado.Enabled = false;
                    C_Lote.Enabled = false;
                    C_Posicion.Enabled = false;
                }
                else
                {
                    MessageBox.Show(llanta.Comentario_llanta);
                }

            }
            else if(result==DialogResult.Cancel)
            {

            }
            
        }
    }
    public class RoundRectangle : IPdfPCellEvent
    {
        public void CellLayout(PdfPCell cell, Rectangle rect, PdfContentByte[] canvas)
        {
            PdfContentByte cb = canvas[PdfPTable.LINECANVAS];
            cb.RoundRectangle(rect.Left,rect.Bottom,rect.Width,rect.Height,7 );
            cb.SetLineWidth(2f);
            cb.SetCMYKColorStrokeF(0f, 0f, 0f, 1f);
            cb.Stroke();
        } 
    }


}
