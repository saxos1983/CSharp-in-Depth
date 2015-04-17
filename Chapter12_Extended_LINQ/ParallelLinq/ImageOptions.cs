namespace Chapter12_Extended_LINQ.ParallelLinq
{
    public class ImageOptions
    {
        public static readonly ImageOptions Default = new ImageOptions(4000, 1024, 3.2, 2.5, -2.1, -1.25);

        public int ImageHeight { get; private set; }

        public int ImageWidth { get; private set; }

        public int MaxIterations { get; private set; }

        public double SampleWidth { get; private set; }

        public double SampleHeight { get; private set; }

        public double OffsetX { get; private set; }
        
        public double OffsetY { get; private set; }

        public ImageOptions(int maxIterations, int imageWidth, double sampleWidth, double sampleHeight, double offsetX, double offsetY)
        {
            this.ImageWidth = imageWidth;
            this.ImageHeight = (int)(sampleHeight * imageWidth / sampleWidth);
            this.MaxIterations = maxIterations;
            this.SampleWidth = sampleWidth;
            this.SampleHeight = sampleHeight;
            this.OffsetX = offsetX;
            this.OffsetY = offsetY;
        }
    }
}