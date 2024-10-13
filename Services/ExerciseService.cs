using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exercise_tracker.Models;
using exercise_tracker.Repositories;

namespace exercise_tracker.Services
{
    public class ExerciseService
    {
        private readonly IExerciseRepository _repository;

        public ExerciseService(IExerciseRepository repository)
        {
            _repository = repository;
        }

        public Exercise GetExerciseById(int id)
        {
            var exercise = _repository.GetById(id);
            
            if (exercise == null)
            {
                Console.WriteLine($"Exercise with {id} not found.");
            }

            return exercise;
        }

        public IEnumerable<Exercise> GetAllExercises()
        {
            return _repository.GetAll();
        }

        public void AddExercise(Exercise exercise)
        {
            exercise.Duration = exercise.DateEnd - exercise.DateStart;
            _repository.Add(exercise);
        }

        public void UpdateExercise(Exercise exercise)
        {
            
            exercise.Duration = exercise.DateEnd - exercise.DateStart;
            _repository.Update(exercise);
        }

        public void DeleteExercise(int id)
        {
            var exerciseToDelete = _repository.GetById(id);

            if (exerciseToDelete != null)
            {
                _repository.Delete(exerciseToDelete);
                Console.WriteLine("Exercise delete sucessfully.");
            }
            else
            {
                Console.WriteLine($"Exercise with {id} not found.");
            }
        }
    }
}