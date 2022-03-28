using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geek_Text.Controllers
{
    public class WishListController : Controller
    {
        // GET: WishListController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WishListController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WishListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WishListController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WishListController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WishListController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WishListController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WishListController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
