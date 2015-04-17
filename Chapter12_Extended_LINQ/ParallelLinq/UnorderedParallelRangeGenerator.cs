namespace ParallelLinq
{
    using System.ComponentModel;
    using System.Linq;

    [Description("Unordered Parallel Generator")]
    public class UnorderedParallelRangeGenerator : MandelbrotGenerator
    {
        public UnorderedParallelRangeGenerator(ImageOptions options)
            : base(options)
        {
        }

        protected override byte[] GeneratePixels()
        {
            var query = from row in Enumerable.Range(0, Height).AsParallel()
                        from col in Enumerable.Range(0, Width)
                        select this.ComputeIndex(row, col);
            return query.ToArray();
        }

        static void Main()
        {
            var generator = new UnorderedParallelRangeGenerator(ImageOptions.Default);
            generator.Display();;
        }
    }
}