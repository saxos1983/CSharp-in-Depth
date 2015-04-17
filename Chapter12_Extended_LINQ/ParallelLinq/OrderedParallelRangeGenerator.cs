namespace ParallelLinq
{
    using System.ComponentModel;
    using System.Linq;

    [Description("Ordered Parallel Generator")]
    public class OrderedParallelRangeGenerator : MandelbrotGenerator
    {
        public OrderedParallelRangeGenerator(ImageOptions options)
            : base(options)
        {
        }

        protected override byte[] GeneratePixels()
        {
            var query = from row in ParallelEnumerable.Range(0, Height).AsParallel()
                        from col in ParallelEnumerable.Range(0, Width)
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