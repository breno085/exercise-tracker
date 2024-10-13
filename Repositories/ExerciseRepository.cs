using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exercise_tracker.Context;
using exercise_tracker.Models;
using exercise_tracker.Repositories;

namespace exercise_tracker.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ExerciseContext _context;

        public ExerciseRepository(ExerciseContext context)
        {
            _context = context;
        }

        public Exercise GetById(int id)
        {
            return _context.Exercises.Find(id);
        }

        public IEnumerable<Exercise> GetAll()
        {
            return _context.Exercises.ToList();
        }

        public void Add(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            _context.SaveChanges();
        }

        public void Update(Exercise exercise)
        {
            _context.Exercises.Update(exercise);
            _context.SaveChanges();
        }

        public void Delete(Exercise exercise)
        {
            _context.Exercises.Remove(exercise);
            _context.SaveChanges();
        }
    }
}