using EventHub.Data;
using Microsoft.EntityFrameworkCore;

namespace EventHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<EventHubContext>()
                .UseSqlServer(
                    "Server=(localdb)\\MSSQLLocalDB;Database=EventHub;Trusted_Connection=True;TrustServerCertificate=True")
                .Options;

            using var context = new EventHubContext(options);
            context.Database.EnsureCreated();

            Console.WriteLine("EventHub database is ready.");
        }
    }
}
