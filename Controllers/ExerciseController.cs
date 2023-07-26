using FitnessMaster.Data;
using FitnessMaster.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace FitnessMaster.Controllers
{
    public class ExerciseController : Controller
    {

        public IActionResult Index()
        {
            List<Exercise> exerciseRecordList = ExerciseDataStore.ExerciseRecordsList.Values.ToList();
            return View(exerciseRecordList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                exercise.CalculateCaloryBurn();
                ExerciseDataStore.AddExerciseRecord(exercise);
                TempData["success"] = "Exercise record added successfully";
                return RedirectToAction("Index");
            }
            return View(exercise);
        }

        //GET
        public IActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordFromMemory = ExerciseDataStore.GetExerciseRecord(id);

            if (recordFromMemory == null)
            {
                return NotFound();
            }

            return View(recordFromMemory);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                exercise.CalculateCaloryBurn();
                ExerciseDataStore.EditExerciseRecord(exercise);
                TempData["success"] = "Exercise record updated successfully";
                return RedirectToAction("Index");
            }
            return View(exercise);
        }

		//GET
		public IActionResult Delete(string? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var recordFromMemory = ExerciseDataStore.GetExerciseRecord(id);

			if (recordFromMemory == null)
			{
				return NotFound();
			}

			return View(recordFromMemory);
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(Exercise exercise)
		{
			if (ModelState.IsValid)
			{
				ExerciseDataStore.RemoveExerciseRecord(exercise);
				TempData["success"] = "Exercise record removed successfully";
				return RedirectToAction("Index");
			}
			return View(exercise);
		}
	}
}
