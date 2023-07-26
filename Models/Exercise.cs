using FitnessMaster.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FitnessMaster.Models
{
    public class Exercise
    {
        public enum ExerciseType
        {
            [Display(Name = "Running")]
            Running,
            [Display(Name = "Cycling")]
            Cycling,
            [Display(Name = "Swimming")]
            Swimming,
            [Display(Name = "Push Ups")]
            PushUps,
            [Display(Name = "Weight Lifting")]
            WeightLifting,
            [Display(Name = "Squats")]
            Squats
        }

        public readonly Dictionary<ExerciseType, int> caloriesBurnedPerMinute = new Dictionary<ExerciseType, int>(){
            {ExerciseType.Running, 800 / 60},
            {ExerciseType.Cycling, 600 / 60},
            {ExerciseType.Swimming, 500 / 60},
            {ExerciseType.PushUps, 550 / 60},
            {ExerciseType.WeightLifting, 700 / 60},
            {ExerciseType.Squats, 550 / 60},
        };

		public Exercise() { }

		public Exercise(ExerciseType name, DateTime createdDate, int duration)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            CreatedDate = createdDate;
            Duration = duration;
            CaloriesBurned = caloriesBurnedPerMinute[name] * duration;
        }

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [DisplayName("Exercise Type")]
		[EnumDataType(typeof(ExerciseType))]
		[Required]
        public ExerciseType Name { get; set; }

        [DisplayName("Created Date")]
        [Required]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Duration in Minutes")]
        [Required]
        public int Duration { get; set; }

        [DisplayName("Calories Burned")]
		[Required]
        public int CaloriesBurned { get; set; }

        public void CalculateCaloryBurn()
        {
			this.CaloriesBurned = caloriesBurnedPerMinute[this.Name] * this.Duration;
		}
	}
}
