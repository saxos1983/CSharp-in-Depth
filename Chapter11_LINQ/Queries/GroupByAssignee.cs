namespace Chapter11_LINQ.Queries
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    using Chapter11_LINQ.Model;

    [Description("Listing 11.17")]
    public class GroupByAssignee
    {
        static void Main()
        {
            var query = from defect in SampleData.AllDefects
                        where defect.AssignedTo != null
                        group defect by defect.AssignedTo;

            foreach (var entry in query)
            {
                Console.WriteLine(entry.Key);
                foreach (var defect in entry)
                {
                    Console.WriteLine("  [{0}] {1}", defect.Severity, defect.Summary);
                }
            }
        }
    }
}