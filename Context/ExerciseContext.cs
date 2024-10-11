using Microsoft.EntityFrameworkCore;
using exercise_tracker.Models;

namespace exercise_tracker.Context;

public class ExerciseContext : DbContext
{
    public ExerciseContext(DbContextOptions<ExerciseContext> options) : base(options)
    {

    }
    public DbSet<Exercise> Exercises { get; set; }
}