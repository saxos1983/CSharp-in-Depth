namespace Chapter11_LINQ.Queries
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    using Chapter11_LINQ.Model;

    [Description("Listing 11.14")]
    public class GroupJoin2
    {
        static void Main()
        {
            var dates = new DateTimeRange(SampleData.Start, SampleData.End);
            var query = from date in dates
                        join defect in SampleData.AllDefects on date equals defect.Created.Date into groupedDefects
                        select new { Date = date, Count = groupedDefects.Count() };

            foreach (var entry in query)
            {
                Console.WriteLine("{0:d}: {1}", entry.Date, entry.Count);
            }
        }
    }
}