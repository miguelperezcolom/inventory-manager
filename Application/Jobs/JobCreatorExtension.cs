using Domain.Services.Factories;
using Hangfire;

namespace Application.Jobs;

public static class JobCreatorExtension
{
    
    public static IApplicationBuilder AddJobs(this IApplicationBuilder app) {

        //todo: move trigger to api when distributed
        var serviceProvider = app.ApplicationServices;
        var _commandFactory = serviceProvider.GetService(typeof(CommandFactory)) 
            as CommandFactory;
        
        RecurringJob.AddOrUpdate(
            "expirationDatesCheckerJob",
            () => ExpireItems(_commandFactory),
            Cron.Daily);

        return app;
    }

    private static void ExpireItems(CommandFactory commandFactory)
    {
        var command = commandFactory.CreateMarkAsExpiredCommand(DateOnly.FromDateTime(DateTime.Now));
        //todo: use dispatcher
        command.RunAsync();
    }
}