using FitnessMaster.Data;
using FitnessMaster.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessMaster.Controllers
{
    public class CheatMealController : Controller
    {

        public IActionResult Index()
        {
            List<CheatMeal> cheatMealRecordList = CheatMealDataStore.CheatMealRecordsList.Values.ToList();
            return View(cheatMealRecordList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CheatMeal cheatMeal)
        {
            if (ModelState.IsValid)
            {
                cheatMeal.CalculateCaloryGain();
                CheatMealDataStore.AddCheatMealRecord(cheatMeal);
                TempData["success"] = "Cheat Meal added successfully";
                return RedirectToAction("Index");
            }
            return View(cheatMeal);
        }

        //GET
        public IActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordFromMemory = CheatMealDataStore.GetCheatMealRecord(id);

            if (recordFromMemory == null)
            {
                return NotFound();
            }

            return View(recordFromMemory);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CheatMeal cheatMeal)
        {
            if (ModelState.IsValid)
            {
                cheatMeal.CalculateCaloryGain();
                CheatMealDataStore.EditCheatMealRecord(cheatMeal);
                TempData["success"] = "Cheat Meal updated successfully";
                return RedirectToAction("Index");
            }
            return View(cheatMeal);
        }

		//GET
		public IActionResult Delete(string? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var recordFromMemory = CheatMealDataStore.GetCheatMealRecord(id);

			if (recordFromMemory == null)
			{
				return NotFound();
			}

			return View(recordFromMemory);
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(CheatMeal cheatMeal)
		{
			if (ModelState.IsValid)
			{
                CheatMealDataStore.RemoveCheatMealRecord(cheatMeal);
				TempData["success"] = "Cheat Meal removed successfully";
				return RedirectToAction("Index");
			}
			return View(cheatMeal);
		}
	}
}
