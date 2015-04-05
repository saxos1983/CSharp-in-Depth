namespace Chapter11_LINQ.Queries
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    using Chapter11_LINQ.Model;

    [Description("Listing 11.17a with Group Join")]
    public class GroupJoinAssignee
    {
        static void Main()
        {
            var query = from user in SampleData.AllUsers
                        join defect in SampleData.AllDefects on user equals defect.AssignedTo into joinedDefects
                        select new { Name = user.Name, Defects = joinedDefects };

            foreach (var entry in query)
            {
                Console.WriteLine(entry.Name);
                foreach (var defect in entry.Defects)
                {
                    Console.WriteLine("  [{0}] {1}", defect.Severity, defect.Summary);
                }
            }
        }
    }
}