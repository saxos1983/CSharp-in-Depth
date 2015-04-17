namespace ParallelLinq
{
    using System.ComponentModel;
    using System.Linq;

    [Description("Single Threaded Generator")]
    public class SingleThreadedGenerator : MandelbrotGenerator
    {
        public SingleThreadedGenerator(ImageOptions options)
            : base(options)
        {
        }

        protected override byte[] GeneratePixels()
        {
            var query = from row in Enumerable.Range(0, Height)
                        from column in Enumerable.Range(0, Width)
                        select this.ComputeIndex(row, column);

            // The same but in extension method form (which is not very easy to read here)
            
            //var query = Enumerable.Range(0, Height)
            //    .SelectMany(row => Enumerable.Range(0, Width), (row, col) => ComputeIndex(row, col));

            return query.ToArray();
        }

        static void Main()
        {
            var generator = new SingleThreadedGenerator(ImageOptions.Default);
            generator.Display();
        }
    }
}