using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exercise_tracker.Controller;
using exercise_tracker.Models;

namespace exercise_tracker;

public class UserInput
{
    private readonly ExerciseController _controller;

    public UserInput(ExerciseController controller)
    {
        _controller = controller;
    }
    public void MainMenu()
    {
        bool closeMenu = false;

        while (!closeMenu)
        {
            Console.WriteLine("Exercise Tracker\n");

            Console.WriteLine("What would you like to do?");

            Console.WriteLine("1 - Add Exercise");
            Console.WriteLine("2 - Get Exercise");
            Console.WriteLine("3 - Get All Exercises");
            Console.WriteLine("4 - Update Exercise");
            Console.WriteLine("5 - Delete Exercise");
            Console.WriteLine("0 - Close Menu");

            string answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    AddExercise();
                    break;
                case "2":
                    GetExercise();
                    break;
                case "3":
                    ShowExercises();
                    break;
                case "4":
                    UpdateExercise();
                    break;
                case "5":
                    DeleteExercise();
                    break;
                case "0":
                    closeMenu = true;
                    break;
                default:
                    Console.WriteLine("Type a valid answer.");
                    break;
            }
        }
    }
    public void AddExercise()
    {
        var exercise = new Exercise();

        // A method like PopulateExerciseData can modify the exercise object because when you pass an object (like exercise) to a method,
        // you're passing a reference to the object, not a copy.
        // This means any changes made to the object's properties inside the method will affect the original object.
        // This works with reference types like classes, arrays, delegates, interfaces, objects, and strings.
        // It DOESN'T work with value types like int, bool, double, char, structs (e.g., DateTime), and enums.
        // For value types, changes inside the method won't affect the original value unless passed using the ref or out keyword.
        
        PopulateExerciseData(exercise);
        _controller.AddExercise(exercise);
    }

    public void GetExercise()
    {
        int exerciseId = ValidateId("get");
        var exercise = _controller.GetExerciseById(exerciseId);

        Console.WriteLine($"ID: {exercise.Id}\nStart: {exercise.DateStart}\nEnd: {exercise.DateEnd}\nDuration: {exercise.Duration}\nComments: {exercise.Comments}\n");
    }

    public void ShowExercises()
    {
        var exercises = _controller.GetAllExercises();

        Console.WriteLine("All Exercises:");
        foreach (var exercise in exercises)
        {
            Console.WriteLine($"ID: {exercise.Id}\nStart: {exercise.DateStart}\nEnd: {exercise.DateEnd}\nDuration: {exercise.Duration}\nComments: {exercise.Comments}\n");
        }
    }

    public void DeleteExercise()
    {
        int exerciseId = ValidateId("delete");
        _controller.DeleteExercise(exerciseId);
    }
    public void UpdateExercise()
    {
        int exerciseId = ValidateId("update");
        var exerciseToUpdate = _controller.GetExerciseById(exerciseId);

        if (exerciseToUpdate != null)
        {
            // In Entity Framework, you cannot simply create a new object and overwrite the retrieved entity (exerciseToUpdate) 
            // because the new object would be treated as a different instance, and EF wouldn’t track it as the original entity.
            // If you were to assign a completely new object, EF would not recognize it as an update of the existing record in the database and you would get an error.
            // Therefore, instead of creating a new Exercise object and overwriting it, we update the individual properties of the 
            // retrieved exercise object. Entity Framework will track the changes to the properties and update the corresponding record in the database.
            // This approach ensures that the entity remains tracked by EF, allowing it to perform the update properly.

            PopulateExerciseData(exerciseToUpdate); // Update the individual properties of the existing entity

            _controller.UpdateExercise(exerciseToUpdate); // Call the controller to update the entity
        }
        else
        {
            Console.WriteLine($"Exercise with ID {exerciseId} not found.");
        }
    }

    private void PopulateExerciseData(Exercise exercise)
    {
        var (startDate, endDate) = GetValidDateRange();

        exercise.DateStart = startDate;
        exercise.DateEnd = endDate;

        exercise.Comments = GetComments();
    }

    private int ValidateId(string operation)
    {
        bool validInt;
        int exerciseId;

        do
        {
            Console.WriteLine($"Type the ID of the exercise you want to {operation}");

            validInt = int.TryParse(Console.ReadLine(), out exerciseId);

            if (!validInt)
            {
                Console.WriteLine("Type a valid integer.");
            }
        } while (!validInt);

        return exerciseId;
    }

    private (DateTime startDate, DateTime endDate) GetValidDateRange()
    {
        DateTime dateStart;
        DateTime dateEnd;

        // This logic can be reused for both add and update
        do
        {
            dateStart = ValidateDateTime("start");
            dateEnd = ValidateDateTime("end");

            if (dateStart > dateEnd)
            {
                Console.WriteLine("End time must be after start time.");
            }
        } while (dateStart > dateEnd);

        return (dateStart, dateEnd);
    }

    private string GetComments()
    {
        Console.WriteLine("Comments: ");
        return Console.ReadLine();
    }

    private DateTime ValidateDateTime(string endOrStart)
    {
        DateTime dateInput;

        while (true)
        {
            Console.WriteLine($"Type {endOrStart} time: (format: dd/MM/yyyy HH:mm)");
            string input = Console.ReadLine();

            if (DateTime.TryParseExact(input, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out dateInput))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid format. Please enter the date in the correct format (dd/MM/yyyy HH:mm).");
            }
        }

        return dateInput;
    }
}