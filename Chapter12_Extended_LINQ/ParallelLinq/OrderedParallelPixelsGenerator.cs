namespace Chapter12_Extended_LINQ.ParallelLinq
{
    using System.ComponentModel;
    using System.Linq;

    [Description("Ordered Parallel Pixels Generator")]
    public class OrderedParallelPixelsGenerator : MandelbrotGenerator
    {
        public OrderedParallelPixelsGenerator(ImageOptions options)
            : base(options)
        {
        }

        protected override byte[] GeneratePixels()
        {
            var pixels = from row in Enumerable.Range(0, Height)
                         from col in Enumerable.Range(0, Width)
                         select new { row, col };

            var query = pixels.AsParallel().AsOrdered().Select(px => ComputeIndex(px.row, px.col));

            return query.ToArray();
        }

        static void Main()
        {
            var generator = new OrderedParallelPixelsGenerator(ImageOptions.Default);
            generator.Display();
        }
    }
}