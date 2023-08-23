using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchStore.DataAccess.Repository.IRepository;
using WatchStore.Models.Models;
using WatchStore.Utility;

namespace WatchStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class BandController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Band> bands = _unitOfWork.Band.GetAll();
            return View(bands);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Band obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Band.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Band created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var band = _unitOfWork.Band.GetFirstOrDefault(u => u.Id == id);
            if (band == null)
            {
                return NotFound();
            }
            return View(band);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Band obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Band.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Band updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var band = _unitOfWork.Band.GetFirstOrDefault(u => u.Id == id);
            if (band == null)
            {
                return NotFound();
            }
            if (band == null)
            {
                return NotFound();
            }
            return View(band);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(Band obj)
        {

            _unitOfWork.Band.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Band deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
