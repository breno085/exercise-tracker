using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exercise_tracker.Models;
using exercise_tracker.Services;

namespace exercise_tracker.Controller
{
    public class ExerciseController
    {
        private readonly ExerciseService _exerciseService;

        public ExerciseController(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public Exercise GetExerciseById(int id)
        {
            return _exerciseService.GetExerciseById(id);
        }

        public void AddExercise(Exercise exercise)
        {

            _exerciseService.AddExercise(exercise);
        }

        public IEnumerable<Exercise> GetAllExercises()
        {
            return _exerciseService.GetAllExercises();
        }

        public void UpdateExercise(Exercise exercise)
        {
            _exerciseService.UpdateExercise(exercise);
        }

        public void DeleteExercise(int id)
        {
            _exerciseService.DeleteExercise(id);
        }
    }
}