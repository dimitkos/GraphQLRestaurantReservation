using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DatabaseContext
{
    class MigrationsContextFactory : IDesignTimeDbContextFactory<GraphQLDbContext>
    {
        public GraphQLDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetFullPath(@"../GraphQLRestaurantReservation/"))
                .AddJsonFile("appsettings.json")
                //.AddJsonFile("appsettings.Development.json", optional: false)
                .Build();

            var builder = new DbContextOptionsBuilder<GraphQLDbContext>();
            builder.UseSqlServer(configuration.GetConnectionString("GraphqlConnection"));

            return new GraphQLDbContext(builder.Options);
        }
    }
}
