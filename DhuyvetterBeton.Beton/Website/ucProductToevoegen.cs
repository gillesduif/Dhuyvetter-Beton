using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BL;
using System.Net;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace DhuyvetterBeton.Beton.Website
{
    public partial class ucProductToevoegen : DevExpress.XtraEditors.XtraUserControl
    {
        string printscreen = string.Empty;
        Image FileImage;
        Image resizedImageMedium;
        Image resizedImageKlein;
        string imgLocationMedium = string.Empty;
        string imgLocationKlein = string.Empty;
        string user;
        string versie;
        FrmHoofdVenster frmhoofd;
        public ucProductToevoegen(FrmHoofdVenster frmhoofd1, string User, string versie1)
        {
            frmhoofd = frmhoofd1;
            InitializeComponent();
            user = User;
            versie = versie1;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<OmschrijvingProduct> omschrijvingProducts = OmschrijvingProduct.KrijgAlleOmschrijvingen();
            List<Formule> formules = Formule.KrijgAlleFormules();
            List<Categorie> categories = Categorie.KrijgAlleCategories();
            cboProductOmschrijving.Properties.Items.AddRange(omschrijvingProducts.ToArray());
            cboFormule.Properties.Items.AddRange(formules.ToArray());
            cboCategorie.Properties.Items.AddRange(categories.ToArray());
            timer1.Stop();
        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (f.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.Move(f.FileName, cboFormule.Text + "groot.png");
                FileImage  = Image.FromFile(cboFormule.Text + "groot.png");
                #region afbeeldingThumbnail
                resizedImageKlein = ResizeImage(FileImage, 50, 50);
                resizedImageKlein.Save(@"Z:\SHOP\" + cboFormule.Text + "thumb.png");
                imgLocationKlein = @"Z:\SHOP\" + cboFormule.Text + "thumb.png";
                #endregion

                #region afbeeldingwebshop
                resizedImageMedium = ResizeImage(FileImage, 220, 220);
                resizedImageMedium.Save(@"Z:\SHOP\"+cboFormule.Text + ".png");
                pictureEdit1.Image = resizedImageMedium; 
                imgLocationMedium = @"Z:\SHOP\" + cboFormule.Text + ".png";
                #endregion
            }


        }
        private void uploadFile(string FTPAddress, string filePath, string username, string password)
        {
            //Create FTP request
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(FTPAddress + "/" + Path.GetFileName(filePath));

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            //Load the file
            FileStream stream = File.OpenRead(filePath);
            byte[] buffer = new byte[stream.Length];

            stream.Read(buffer, 0, buffer.Length);
            stream.Close();

            //Upload file
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();

            MessageBox.Show("Uploaded Successfully");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            uploadFile("ftp://185.41.127.34/dhuyvetterbeton.com/wwwroot/img/shop/items/"+ cboCategorie.Text, imgLocationMedium, "ftpprogram", "Woefie!96");
            uploadFile("ftp://185.41.127.34/dhuyvetterbeton.com/wwwroot/img/shop/thumbs/" + cboCategorie.Text, imgLocationKlein, "ftpprogram", "Woefie!96");
            ProductWebshop productWebshop = new ProductWebshop();
            productWebshop.Categorie = ((Categorie)cboCategorie.SelectedItem);
            productWebshop.Formule = ((Formule)cboFormule.SelectedItem);
            productWebshop.OmschrijvingProduct = ((OmschrijvingProduct)cboProductOmschrijving.SelectedItem);
          
                String formuleNaam = productWebshop.Formule.Naam;
                string formuleNaamCorrect = formuleNaam.Replace(" ", "%20");

                String categorieNaam = productWebshop.Categorie.Naam;
                string categorieNaamCorrect = categorieNaam.Replace(" ", "%20");

                productWebshop.AfbeeldingLocatie = "/img/shop/items/" + categorieNaamCorrect + "/" + formuleNaamCorrect + ".png";
                productWebshop.ThumbLocatie = "/img/shop/thumbs/" + categorieNaamCorrect + "/" + formuleNaamCorrect + "thumb.png";

            productWebshop.MaakNieuwProductWebshop();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            Categorie categorie = new Categorie(txtNaamCategorie.Text);
            categorie.MaakNieuweCategorie();

            WebRequest request = WebRequest.Create("ftp://185.41.127.34/dhuyvetterbeton.com/wwwroot/img/shop/items/" + txtNaamCategorie.Text);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.Credentials = new NetworkCredential("ftpprogram", "Woefie!96");
            using (var resp = (FtpWebResponse)request.GetResponse())
            {
               // MessageBox.Show(resp.StatusCode.ToString());
            }
            WebRequest request1 = WebRequest.Create("ftp://185.41.127.34/dhuyvetterbeton.com/wwwroot/img/shop/thumbs/" + txtNaamCategorie.Text);
            request1.Method = WebRequestMethods.Ftp.MakeDirectory;
            request1.Credentials = new NetworkCredential("ftpprogram", "Woefie!96");
            using (var resp = (FtpWebResponse)request1.GetResponse())
            {
               // MessageBox.Show(resp.StatusCode.ToString());
            }
            txtNaamCategorie.Text = string.Empty;
            List<Categorie> categories = Categorie.KrijgAlleCategories();
            cboCategorie.Properties.Items.Clear();
            cboCategorie.Properties.Items.AddRange(categories.ToArray());
        }

        private void cboProductOmschrijving_SelectedIndexChanged(object sender, EventArgs e)
        {
            string productOmschrijvingformule = ((OmschrijvingProduct)cboProductOmschrijving.SelectedItem).Formule;
            int index = 0;
            foreach (Formule formule in cboFormule.Properties.Items)
            {
                if (formule.Naam == productOmschrijvingformule)
                {
                    cboFormule.SelectedIndex = index;
                    break;
                }
                index++;
            }
        }
    }
}
