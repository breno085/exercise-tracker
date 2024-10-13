using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using exercise_tracker.Context;
using Microsoft.Extensions.DependencyInjection;
using exercise_tracker.Repositories;
using exercise_tracker.Services;
using exercise_tracker.Controller;
using exercise_tracker;
using System.Globalization;

CultureInfo culture = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

// Create a HostBuilder to enable DI
var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<ExerciseContext>(options =>
            options.UseSqlite("Data Source=exercise.db"));
        
        // Register ExerciseRepository with DI
        services.AddScoped<IExerciseRepository, ExerciseRepository>();
        services.AddTransient<ExerciseService>();
        services.AddTransient<ExerciseController>();
        services.AddTransient<UserInput>();
    })
    .Build();

using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;
var userInput = services.GetRequiredService<UserInput>();

userInput.MainMenu();





