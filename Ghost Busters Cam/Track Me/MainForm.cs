using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Media;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace GhostBustersCam
{
    public partial class MainForm : Form
    {
        private SoundPlayer SoundTrack = null;
        private Thread ExecThread = null;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SoundTrack = new SoundPlayer("GB.wav");
            ExecThread = new Thread(new ThreadStart(CaptureMotion));
            ExecThread.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ExecThread != null && ExecThread.IsAlive)
                ExecThread.Abort();
        }

        private void CaptureMotion()
        {
            try
            {
                float wFactor = (float)this.Width / (float)CaptureBox.Width;
                float hFactor = (float)this.Height / (float)CaptureBox.Height;

                CvArr array = null;
                CvCapture cap = CvCapture.FromCamera(CaptureDevice.Any);

                this.Invoke(new Action(() =>
                {
                    lblLoading.Visible = false;
                    GBBox.Visible = true;
                    CamBox.Visible = true;
                    RadarBox.Visible = true;
                    lblGhost.Visible = true;
                    GhostBox.Visible = true;
                    lblDescription.Visible = true;
                    CaptureBox.Visible = true;
                }));

                SoundTrack.Play();
                SoundTrack = new SoundPlayer("Alarm.wav");

                Thread.Sleep(3600);

                while (true)
                {
                    IplImage img = cap.QueryFrame();

                    if (img == null)
                        continue;

                    //int black = img
                    //if (black < 10)
                    //{
                    //    MessageBox.Show("Please get off cameras' field of view and switch off the lights!", "Ghost Busters Cam");

                    //    continue;
                    //}

                    img.Flip(array, FlipMode.Y);

                    string filepath = "haarcascade_frontalface_alt2.xml";

                    CvHaarClassifierCascade cascade = CvHaarClassifierCascade.FromFile(filepath);
                    CvSeq<CvAvgComp> faces = Cv.HaarDetectObjects(img, cascade, Cv.CreateMemStorage(), 3.0, 1,
                                                                    HaarDetectionType.Zero, new CvSize(70, 70), 
                                                                    new CvSize(500, 500));

                    Bitmap Image = BitmapConverter.ToBitmap(img);
                    Image.SetResolution(240, 180);

                    this.Invoke(new Action(() =>
                    {
                        CaptureBox.Image = Image;
                    }));

                    foreach (CvAvgComp face in faces)
                    {
                        IplImage ClonedImage = img.Clone();
                        Cv.SetImageROI(ClonedImage, face.Rect);

                        IplImage ThisFace = Cv.CreateImage(face.Rect.Size, ClonedImage.Depth, ClonedImage.NChannels);
                        Cv.Copy(ClonedImage, ThisFace, null);
                        Cv.ResetImageROI(ClonedImage);

                        Bitmap GhostImage = BitmapConverter.ToBitmap(ThisFace);
                        GhostImage.SetResolution(114, 103);

                        img.DrawRect(face.Rect, CvColor.Red, 3);

                        Bitmap FaceImage = BitmapConverter.ToBitmap(img);
                        FaceImage.SetResolution(240, 180);
                        
                        this.Invoke(new Action(() =>
                        {
                            AlertTimer.Enabled = true;

                            CaptureBox.Image = FaceImage;
                            GhostBox.Image = GhostImage;
                        }));

                        SoundTrack.Play();

                        Thread.Sleep(2500);

                        this.Invoke(new Action(() =>
                        {
                            AlertTimer.Enabled = false;
                            lblGhostAlert.Visible = false;
                        }));

                        SoundTrack.Stop();

                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void AlertTimer_Tick(object sender, EventArgs e)
        {
            if (lblGhostAlert.Visible == true)
                lblGhostAlert.Visible = false;
            else
                lblGhostAlert.Visible = true;
        }
    }
}
