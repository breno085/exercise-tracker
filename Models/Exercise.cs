using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise_tracker.Models;

public class Exercise
{
    public int Id { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public TimeSpan Duration { get; set; }
    public string Comments { get; set; }
}