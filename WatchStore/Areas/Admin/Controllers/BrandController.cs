using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchStore.DataAccess.Repository.IRepository;
using WatchStore.Models.Models;
using WatchStore.Utility;

namespace WatchStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class BrandController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Brand> brands = _unitOfWork.Brand.GetAll();

            return View(brands);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Brand obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Brand.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Brand Created Successfully";
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
            var brand = _unitOfWork.Brand.GetFirstOrDefault(u => u.Id == id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Brand obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Brand.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Brand Updated Successfully";
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
            var brand = _unitOfWork.Brand.GetFirstOrDefault(u => u.Id == id);
            if (brand == null)
            {
                return NotFound();
            }
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(Brand obj)
        {

            _unitOfWork.Brand.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Brand Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}
