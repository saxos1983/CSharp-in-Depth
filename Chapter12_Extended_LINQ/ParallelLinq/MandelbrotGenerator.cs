namespace Chapter12_Extended_LINQ.ParallelLinq
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    public abstract class MandelbrotGenerator
    {
        private readonly ImageOptions options;

        protected MandelbrotGenerator(ImageOptions options)
        {
            this.options = options;
        }

        public int Width { get { return this.options.ImageWidth; }}
        
        public int Height { get { return this.options.ImageHeight; }}

        protected abstract byte[] GeneratePixels();

        public void Display()
        {
            Stopwatch watch = Stopwatch.StartNew();
            byte[] imageData = this.GeneratePixels();
            watch.Stop();

            Console.WriteLine("Image Generation took {0}ms", watch.ElapsedMilliseconds);

            using (Image image = this.CreateBitmap(imageData))
            {
                Form form = this.CreateForm(image);
                // Will block until form is closed.
                Application.Run(form);
            }
            
        }

        private Form CreateForm(Image image)
        {
            return new Form
                            {
                                Controls = { new PictureBox() { Image = image, Dock = DockStyle.Fill } },
                                FormBorderStyle = FormBorderStyle.FixedSingle,
                                ClientSize = image.Size,
                                Text = "Mandelbrot Image"
                            };
        }

        private Image CreateBitmap(byte[] imageData)
        {
            unsafe
            {
                fixed (byte* ptr = imageData)
                {
                    IntPtr scan0 = new IntPtr(ptr);
                    Bitmap bitmap = new Bitmap(this.Width, this.Height, this.Width, PixelFormat.Format8bppIndexed, scan0);
                    ColorPalette palette = bitmap.Palette;
                    palette.Entries[0] = Color.White;
                    for (int i = 1; i < 256; i++)
                    {
                        palette.Entries[i] = Color.FromArgb((i * 7) % 256, (i * 5) % 256, 255);
                    }
                    bitmap.Palette = palette;
                    return (Image)bitmap.Clone();
                }
            }
        }

        protected byte ComputeIndex(int row, int col)
        {
            double x = (col * this.options.SampleWidth) / this.Width + this.options.OffsetX;
            double y = (row * this.options.SampleHeight) / this.Height + this.options.OffsetY;

            double y0 = y;
            double x0 = x;

            for (int i = 0; i < this.options.MaxIterations; i++)
            {
                if (x * x + y * y >= 4)
                {
                    return (byte)((i % 255) + 1);
                }
                double xtemp = x * x - y * y + x0;
                y = 2 * x * y + y0;
                x = xtemp;
            }
            return 0;
        }
    }
}