using FitnessMaster.Models;
using static FitnessMaster.Models.CheatMeal;

namespace FitnessMaster.Data
{

    public static class CheatMealDataStore
    {
        public static Dictionary<string, CheatMeal> CheatMealRecordsList { get; set; }

        static CheatMealDataStore()
        {
            CheatMealRecordsList = new Dictionary<string, CheatMeal>();

			Random rnd = new Random();
            Array cheatMealTypeValues = Enum.GetValues(typeof(CheatMealType));

            for (int i = 0; i < 10; i++)
            {
                CheatMealType randomCheatMeal = (CheatMealType)cheatMealTypeValues.GetValue(rnd.Next(cheatMealTypeValues.Length));
                AddCheatMealRecord(new CheatMeal(randomCheatMeal, DateTime.Now, rnd.Next(1, 10) * 100));
            }
		}

        public static CheatMeal GetCheatMealRecord(string id)
        {
            return CheatMealRecordsList[id];
        }

        public static void AddCheatMealRecord(CheatMeal cheatMeal)
        {
            CheatMealRecordsList.Add(cheatMeal.Id, cheatMeal);
        }

        public static void EditCheatMealRecord(CheatMeal cheatMeal)
        {
            CheatMealRecordsList[cheatMeal.Id] = cheatMeal;
        }

        public static void RemoveCheatMealRecord(CheatMeal cheatMeal)
        {
            CheatMealRecordsList.Remove(cheatMeal.Id);
        }
    }
}
