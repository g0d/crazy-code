using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.Blob;
using System.Collections.Generic;

namespace TrackMe
{
    public partial class MainForm : Form
    {
        //private System.Timers.Timer DelayTimer = null;
        private int mode = 1;
        private Thread ExecThread = null;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //DelayTimer = new System.Timers.Timer(30);
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
                    radioButton1.Visible = true;
                    radioButton2.Visible = true;
                }));
                
                while (true)
                {
                    IplImage img = cap.QueryFrame();

                    if (img == null)
                        continue;
                    
                    img.Flip(array, FlipMode.Y);

                    if (mode == 1)
                    {
                        string filepath = "haarcascade_frontalface_alt2.xml";

                        CvHaarClassifierCascade cascade = CvHaarClassifierCascade.FromFile(filepath);
                        CvSeq<CvAvgComp> faces = Cv.HaarDetectObjects(img, cascade, Cv.CreateMemStorage(), 3.0, 1,
                                                                      HaarDetectionType.Zero, new CvSize(70, 70), 
                                                                      new CvSize(500, 500));

                        foreach (CvAvgComp face in faces)
                        {
                            //IplImage ClonedImage = img.Clone();
                            //Cv.SetImageROI(ClonedImage, face.Rect);
                            //IplImage ThisFace = Cv.CreateImage(face.Rect.Size, ClonedImage.Depth, ClonedImage.NChannels);
                            //Cv.Copy(ClonedImage, ThisFace, null);
                            //Cv.ResetImageROI(ClonedImage);

                            //Bitmap FaceImage = BitmapConverter.ToBitmap(ThisFace);
                            //FaceImage.SetResolution(240, 180);
                            //CaptureBox.Image = FaceImage;

                            img.DrawRect(face.Rect, CvColor.Red, 3);

                            Bitmap FaceImage = BitmapConverter.ToBitmap(img);
                            FaceImage.SetResolution(240, 180);
                            CaptureBox.Image = FaceImage;

                            this.Invoke(new Action(() =>
                            {
                                LifeBox.Left = (int)(face.Rect.Left * wFactor - (float)(LifeBox.Width / 2.0) - (float)(this.Width / 2.0));
                                LifeBox.Top = (int)(face.Rect.Top * hFactor - (float)(LifeBox.Height / 2.0) - (float)(this.Height / 2.0));

                                if (LifeBox.Left > (this.Width - LifeBox.Width - 12))
                                    LifeBox.Left = (this.Width - LifeBox.Width - 24);

                                if (LifeBox.Top > (this.Height - LifeBox.Height - 48))
                                    LifeBox.Top = (this.Height - LifeBox.Height - 48);

                                if (LifeBox.Left < 12)
                                    LifeBox.Left = 12;

                                if (LifeBox.Top < 12)
                                    LifeBox.Top = 12;

                                Thread.Sleep(30);
                            }));

                            break;
                        }
                    }
                    else
                    {
                        int AllBlobs = 0;

                        CvBlobs blobs = null;
                        IplImage imgHSVsrc = Cv.CreateImage(Cv.GetSize(img), BitDepth.U8, 3);
                        IplImage imgHSVdst = Cv.CreateImage(Cv.GetSize(img), BitDepth.U8, 1);

                        Cv.CvtColor(img, imgHSVsrc, ColorConversion.BgrToHsv);
                        Cv.InRangeS(imgHSVsrc, new CvScalar(86, 80, 30), new CvScalar(115, 250, 250), imgHSVdst);
                        Cv.ReleaseImage(imgHSVsrc);
                        
                        blobs = new CvBlobs(imgHSVdst);
                        blobs.FilterByArea(7000, 40000);
                        
                        AllBlobs = blobs.Count;
                        
                        foreach (KeyValuePair<int, CvBlob> blob in blobs)
                        {
                            CvBlob CurrentBlob = blob.Value;
                            CvRect BlobRect = CurrentBlob.Rect;
                            CvPoint Point1, Point2;

                            Point1.X = BlobRect.X;
                            Point1.Y = BlobRect.Y;
                            Point2.X = BlobRect.X + BlobRect.Width;
                            Point2.Y = BlobRect.Y + BlobRect.Height;

                            img.DrawRect(Point1, Point2, CvColor.LightGreen, 3, LineType.AntiAlias);

                            this.Invoke(new Action(() =>
                            {
                                LifeBox.Left = (int)(BlobRect.Left * wFactor - (float)(LifeBox.Width / 2.0) - (float)(this.Width / 2.0));
                                LifeBox.Top = (int)(BlobRect.Top * hFactor - (float)(LifeBox.Height / 2.0) - (float)(this.Height / 2.0));

                                if (LifeBox.Left > (this.Width - LifeBox.Width - 12))
                                    LifeBox.Left = (this.Width - LifeBox.Width - 24);
                                
                                if (LifeBox.Top > (this.Height -  LifeBox.Height - 48))
                                    LifeBox.Top = (this.Height - LifeBox.Height - 48);

                                if (LifeBox.Left < 12)
                                    LifeBox.Left = 12;

                                if (LifeBox.Top < 12)
                                    LifeBox.Top = 12;

                                Thread.Sleep(30);
                            }));

                            break;
                        }

                        Bitmap Item = BitmapConverter.ToBitmap(img);
                        Item.SetResolution(240, 180);
                        CaptureBox.Image = Item;

                        Bitmap HSVItem = BitmapConverter.ToBitmap(imgHSVdst);
                        HSVItem.SetResolution(240, 180);
                        HSVCaptureBox.Image = HSVItem;

                        Cv.ReleaseImage(imgHSVdst);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message + "DETAILS: " + e.StackTrace);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            mode = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            mode = 2;
        }
    }
}
