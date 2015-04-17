namespace Chapter12_Extended_LINQ.ParallelLinq
{
    using System.ComponentModel;
    using System.Linq;

    [Description("Unordered Parallel Pixels Generator")]
    public class UnorderedParallelPixelsGenerator : MandelbrotGenerator
    {
        public UnorderedParallelPixelsGenerator(ImageOptions options)
            : base(options)
        {
        }

        protected override byte[] GeneratePixels()
        {
            var pixels = from row in Enumerable.Range(0, Height)
                         from col in Enumerable.Range(0, Width)
                         select new { row, col };

            var query = pixels.AsParallel().Select(px => ComputeIndex(px.row, px.col));

            return query.ToArray();
        }

        static void Main()
        {
            var generator = new UnorderedParallelPixelsGenerator(ImageOptions.Default);
            generator.Display();
        }
    }
}