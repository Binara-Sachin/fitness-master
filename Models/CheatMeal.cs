using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;

namespace FitnessMaster.Models
{
    public class CheatMeal
    {
        public enum CheatMealType
        {
            [Display(Name = "Pizza")]
            Pizza,
            [Display(Name = "Burger")]
            Burger,
            [Display(Name = "Hot Dog")]
            HotDog,
            [Display(Name = "Milkshake")]
            Milkshake,
            [Display(Name = "Submarine")]
            Submarine,
            [Display(Name = "Chocolate")]
            Chocolate
        }

        public readonly Dictionary<CheatMealType, int> caloriesPer100g = new Dictionary<CheatMealType, int>(){
            {CheatMealType.Pizza, 266},
            {CheatMealType.Burger, 295},
            {CheatMealType.HotDog, 290},
            {CheatMealType.Milkshake, 112},
            {CheatMealType.Submarine, 200},
            {CheatMealType.Chocolate, 546},
        };

        public CheatMeal() { }

        public CheatMeal(CheatMealType name, DateTime createdDate, int duration)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            CreatedDate = createdDate;
            Amount = duration;
            CaloriesGained = caloriesPer100g[name] * duration;
        }

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [DisplayName("Cheat Meal")]
        [EnumDataType(typeof(CheatMealType))]
        [Required]
        public CheatMealType Name { get; set; }

        [DisplayName("Date")]
        [Required]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Amount in grams")]
        [Required]
        public int Amount { get; set; }

        [DisplayName("Calories Gained")]
        [Required]
        public int CaloriesGained { get; set; }

        public void CalculateCaloryGain()
        {
            this.CaloriesGained = caloriesPer100g[this.Name] * this.Amount / 100;
        }
    }
}
