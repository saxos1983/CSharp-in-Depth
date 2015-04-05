namespace Chapter11_LINQ.Queries
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    using Chapter11_LINQ.Model;

    [Description("Listing 11.19")]
    public class GroupByContinuation
    {
        static void Main()
        {
            var query = from defect in SampleData.AllDefects
                        where defect.AssignedTo != null
                        group defect by defect.AssignedTo
                        into groupedDefects
                        select new { Name = groupedDefects.Key, Count = groupedDefects.Count() };

            foreach (var entry in query)
            {
                Console.WriteLine("{0}: {1}", entry.Name, entry.Count);
            }
        }
    }
}