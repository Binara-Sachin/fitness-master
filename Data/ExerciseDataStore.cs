using FitnessMaster.Models;
using static FitnessMaster.Models.Exercise;

namespace FitnessMaster.Data
{

    public static class ExerciseDataStore
    {
        public static Dictionary<string, Exercise> ExerciseRecordsList { get; set; }

        static ExerciseDataStore()
        {
			ExerciseRecordsList = new Dictionary<string, Exercise>();

			Random rnd = new Random();
            Array exerciseTypeValues = Enum.GetValues(typeof(ExerciseType));

            for (int i = 0; i < 10; i++)
            {
                ExerciseType randomExercise = (ExerciseType)exerciseTypeValues.GetValue(rnd.Next(exerciseTypeValues.Length));
                AddExerciseRecord(new Exercise(randomExercise, DateTime.Now, rnd.Next(5, 60)));
            }
		}

        public static Exercise GetExerciseRecord(string id)
        {
            return ExerciseRecordsList[id];
        }

        public static void AddExerciseRecord(Exercise exercise)
        {
            ExerciseRecordsList.Add(exercise.Id, exercise);
        }

        public static void EditExerciseRecord(Exercise exercise)
        {
            ExerciseRecordsList[exercise.Id] = exercise;
        }

        public static void RemoveExerciseRecord(Exercise exercise)
        {
            ExerciseRecordsList.Remove(exercise.Id);
        }
    }
}
