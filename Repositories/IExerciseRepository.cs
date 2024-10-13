using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exercise_tracker.Models;

namespace exercise_tracker.Repositories
{
    public interface IExerciseRepository
    {
        Exercise GetById(int id);
        IEnumerable<Exercise> GetAll();
        void Add(Exercise exercise);
        void Update(Exercise exercise);
        void Delete(Exercise exercise);
    }
}