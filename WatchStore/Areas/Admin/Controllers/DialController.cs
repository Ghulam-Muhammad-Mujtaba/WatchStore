using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchStore.DataAccess.Repository.IRepository;
using WatchStore.Models.Models;
using WatchStore.Utility;

namespace WatchStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class DialController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DialController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Dial> dials = _unitOfWork.Dial.GetAll();
            return View(dials);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Dial obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Dial.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Dial created successfully";
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
            var dial = _unitOfWork.Dial.GetFirstOrDefault(u => u.Id == id);
            if (dial == null)
            {
                return NotFound();
            }
            return View(dial);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Dial obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Dial.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Dial updated successfully";
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
            var dial = _unitOfWork.Dial.GetFirstOrDefault(u => u.Id == id);
            if (dial == null)
            {
                return NotFound();
            }
            if (dial == null)
            {
                return NotFound();
            }
            return View(dial);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(Dial obj)
        {

            _unitOfWork.Dial.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Dial deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
