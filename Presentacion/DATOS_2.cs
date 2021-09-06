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
        public string FM3 = "";
        
        public DATOS_2()
        {
           
            InitializeComponent();
        }

        private void DATOS_2_Load(object sender, EventArgs e)
        {

            llanta.ORDEN_S = M1;
            llanta.DATOS();
            axAcroPDF1.Visible = false;
            MessageBox.Show(M1);
            CrearPDF();
            CrearFACTURA();
            label1.Font = new System.Drawing.Font(label1.Font,FontStyle.Bold);
            label10.Font = new System.Drawing.Font(label1.Font, FontStyle.Bold);
            label15.Font = new System.Drawing.Font(label1.Font, FontStyle.Bold);
            label3.Text = "MARCA: " + llanta.MARCA_LLANTA;
            label4.Text = "TAMAÑO:   " +llanta.TAMAÑO;
            label5.Text = "SERIE:   " + llanta.SERIE;
            label6.Text = "FECHA DE INGRESO: " + llanta.FECHA;
            label7.Text = "VALOR: " + llanta.VALOR;
            label2.Text = "ABONO: " + llanta.ABONO;
            label8.Text = "ORDEN DE SERVICIO:   " + llanta.ORDEN_S;
            label9.Text = "NOMBRE:   " + llanta.SOLICITANTE;
            label11.Text = "DIRECCION:   " + llanta.DIRECCION;
            label12.Text = "BARRIO:   " + llanta.BARRIO;
            label13.Text = "CIUDAD:   " + llanta.CIUDAD;
            label14.Text = "TELEFONO:   " + llanta.CIUDAD;
            label17.Text = "LOTE:   " + llanta.UBICACION;
            label16.Text = "POSICION:   " + llanta.POSICION;
            label19.Text = "ESTADO ACTUAL:   " + llanta.E_A;

            ver();
        }

        public void ver()
        {
            if (Form1.ALFA == "A")
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
                C2_3 = new PdfPCell(new Phrase("MARCA:  "+llanta.MARCA_LLANTA, der));
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
                C3_4 = new PdfPCell(new Phrase("SALIDA:  "+llanta.FECHAE, der));
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
                String AE = @PA + @"\PN1.png";
                String AF = @PA + @"\AN1.jpg";
                Document pdoc = new Document(iTextSharp.text.PageSize.A5, 10, 10, 10, 10);
                PdfWriter pWriter = PdfWriter.GetInstance(pdoc, new FileStream(AA, FileMode.Create));
                pdoc.Open();
                // CREAR MEMBRETE
                PdfPTable TABLA1 = new PdfPTable(new float[] { 100f });
                TABLA1.HorizontalAlignment = 1;
                //CARGAR IMAGEN DE LA IPS
                iTextSharp.text.Image myImage = iTextSharp.text.Image.GetInstance(AE);
                PdfPCell celda = new PdfPCell(myImage);
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                celda.FixedHeight = 70;
                celda.PaddingBottom = 2;
                celda.PaddingTop = 2;
                celda.PaddingLeft = 2;
                celda.Rowspan = 8;
                TABLA1.AddCell(celda);
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
                C7_5 = new PdfPCell(new Phrase("FECHA:", SERIE9));
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
                C9_1 = new PdfPCell(new Phrase("MARCA: " + llanta.MARCA_LLANTA, SERIE9));
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
    }
}
