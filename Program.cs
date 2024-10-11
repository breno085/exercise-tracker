using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using exercise_tracker.Context;
using Microsoft.Extensions.DependencyInjection;

// Create a HostBuilder to enable DI
var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<ExerciseContext>(options =>
            options.UseSqlite("Data Source=exercise.db"));
        // services.AddTransient<ExerciseService>(); // Uncomment when you need the service
    })
    .Build();

