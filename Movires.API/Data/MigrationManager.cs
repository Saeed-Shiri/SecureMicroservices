using Microsoft.EntityFrameworkCore;

namespace Movies.API.Data
{
    public static class MigrationManager
    {
        public static async Task MigrateAsync<TContext>(this IServiceCollection serviceCollection, Func<TContext, IServiceProvider, Task> seeder) where TContext : DbContext
        {
            
                var provider = serviceCollection.BuildServiceProvider();
                await using var scope = provider
                    .CreateAsyncScope();

                var context = scope.ServiceProvider.GetRequiredService<TContext>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<TContext>>();
            try
            {
                if (context.Database.IsRelational())
                {
                    logger.LogInformation($"Started Db Migration: {typeof(TContext).Name} at {DateTime.Now}");

                    await context.Database.MigrateAsync();

                    logger.LogInformation($"Migration Completed: {typeof(TContext).Name} at {DateTime.Now}");
                }

                await seeder(context, provider);


            }
            catch (Exception e)
            {

                logger.LogError(e, $"An error occurred while migrating db: {typeof(TContext).Name}");
            }
        }


    }
}
