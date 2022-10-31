using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;



namespace bitmap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
            int width = 300;
            int height = 200;
            byte[] pixels = new byte[width * height*2];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width * 2; j++)
                {

                    pixels[i * width * 2 + j] = 250;

                }

            }

            //BitmapSource bitmap = BitmapSource.Create(width, height, 96, 96, PixelFormats.Gray16, null, pixels, width * 16 / 8);
            //this.image1.Source = bitmap;

            int size = Marshal.SizeOf(pixels[0]) * pixels.Length;

            IntPtr pnt = Marshal.AllocHGlobal(size);
            Marshal.Copy(pixels, 0, pnt, pixels.Length);
            System.Drawing.Bitmap bitmaptest = new System.Drawing.Bitmap(width, height, width * 16 / 8, System.Drawing.Imaging.PixelFormat.Format16bppGrayScale, pnt);
            Console.Write(bitmaptest.GetPixel(0, 20));

            BitmapImage bitmapImage = new BitmapImage();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                bitmaptest.Save(ms, bitmaptest.RawFormat);
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
            }
            this.image1.Source = bitmapImage;
            //System.Drawing.Image _serverImage = System.Drawing.Image.FromFile("");
            ////Bitmap serverImage = new Bitmap(_serverImage);
            ////_serverImage.Dispose();
            //if (bitmaptest != null)
            //{
            //    bitmaptest.Save("f:\\1.bmp");
            //}
            



            // create render bitmap  
            //var rtbitmap = new RenderTargetBitmap(bitmap.PixelWidth,
            //    bitmap.PixelHeight,
            //    bitmap.DpiX,
            //    bitmap.DpiY,
            //    PixelFormats.Pbgra32);
            //var drawingVisual = new DrawingVisual();
            //using (var dc = drawingVisual.RenderOpen())
            //{
            //    // draw source image  
            //    dc.DrawImage(bitmap, new Rect(0, 0, bitmap.Width, bitmap.Height));
            //    //draw path
            //    //dc.DrawGeometry(Brushes.Red, null, pg);
            //}

            //rtbitmap.Render(drawingVisual);
            //uint[] templateArray = new uint[width * height];
            //rtbitmap.CopyPixels(templateArray, width * 4, 0);

            //IList<uint> values = new List<uint>();
            //uint value = 0;
            //for (int i = 0; i < pixels.Length; i++)
            //{
            //    value += 2;
            //    values.Add(pixels[i]);
            //    if (values.Count == width)
            //    {
                    
            //    }
            //}

            
           
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.UriSource = new Uri(@"F:\wpf_mytest\bitmap\11.jpg");//获取或设置BitmapImage的Uri源
            bitmapImage.EndInit();//表示BitmapImage初始化结束
            bitmapImage.Freeze();
            this.image1.Source = bitmapImage;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            var bitmapImage = new BitmapImage();
            using (FileStream fs = new FileStream(@"F:\wpf_mytest\bitmap\11.jpg", FileMode.Open))
            {
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = fs;
                bitmapImage.EndInit();
            }

            //FileStream fs = new FileStream(@"F:\111.png", FileMode.Open);
            //bitmapImage.BeginInit();
            //bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            //bitmapImage.StreamSource = fs;
            //bitmapImage.EndInit();
            //fs.Close();
            bitmapImage.Freeze();
            this.image1.Source = bitmapImage;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileStream fileStream = new FileStream(@"F:\wpf_mytest\bitmap\11.jpg", FileMode.Open, FileAccess.Read, FileShare.Read);
                byte[] bytes = new byte[fileStream.Length];
                fileStream.Read(bytes, 0, bytes.Length);
                fileStream.Close();
                Stream stream = new MemoryStream(bytes);

                stream.Read(bytes, 0, bytes.Length);
                // 设置当前流的位置为流的开始    
                stream.Seek(0, SeekOrigin.Begin);
                MemoryStream mstream = null;
                mstream = new MemoryStream(bytes);
                Bitmap bm = new Bitmap(mstream);


                System.Drawing.Image image1 = System.Drawing.Image.FromFile(@"F:\wpf_mytest\bitmap\11.jpg");
                float dpix = image1.HorizontalResolution;
                float dpiy = image1.VerticalResolution;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
