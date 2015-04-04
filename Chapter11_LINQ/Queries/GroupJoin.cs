namespace Chapter11_LINQ.Queries
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    using Chapter11_LINQ.Model;

    [Description("Listing 11.13")]
    public class GroupJoin
    {
        static void Main()
        {
            var query = from defect in SampleData.AllDefects
                        join subscription in SampleData.AllSubscriptions on defect.Project equals subscription.Project
                            into joinedSubscriptions
                        select new { Defect = defect, Subscription = joinedSubscriptions };

            foreach (var entry in query)
            {
                Console.WriteLine(entry.Defect.Summary);
                foreach (var subscription in entry.Subscription)
                {
                    Console.WriteLine(" {0}", subscription.EmailAddress);
                }
            }
        }
    }
}