namespace Chapter12_Extended_LINQ.ParallelLinq
{
    using System.ComponentModel;
    using System.Linq;

    [Description("Ordered Parallel Range Generator")]
    public class OrderedParallelRangeGenerator : MandelbrotGenerator
    {
        public OrderedParallelRangeGenerator(ImageOptions options)
            : base(options)
        {
        }

        protected override byte[] GeneratePixels()
        {
            var query = from row in Enumerable.Range(0, this.Height).AsParallel().AsOrdered()
                        from col in Enumerable.Range(0, this.Width)
                        select this.ComputeIndex(row, col);
            return query.ToArray();
        }

        static void Main()
        {
            var generator = new OrderedParallelRangeGenerator(ImageOptions.Default);
            generator.Display();
        }
    }
}