using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyRPLku.Models;
using StudyRPLku.DAL;
using System.Net;

namespace StudyRPLku.Controllers
{
    public class CategoriesController : Controller
    {
        private CommerceModels db = new CommerceModels();
        // GET: Categories
        public ActionResult Index()
        {
            using ( CategoriesDAL servis = new CategoriesDAL())
            {
                var categori = servis.GetData().ToList();
                if (TempData["Message"] != null)
                {
                    ViewBag.msg = TempData["Message"].ToString();
                }
                return View(categori);
            }
            
        }

        public ActionResult CreateCategories()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategories(Categories cat)
        {
            using (CategoriesDAL service = new CategoriesDAL())
            {

                try
                {
                    service.tambah(cat);
                    TempData["Message"] = Helper.MsgBox.GetMsg("success", "Success! ", "Your data " + cat.CategoryName + " has been added");

                }
                catch (Exception ex)
                {
                    TempData["Message"] = Helper.MsgBox.GetMsg("danger", "Error", ex.Message);

                }


            }
            return RedirectToAction("Index");
        }

        public ActionResult EditCategories(int id)
        {
            using (CategoriesDAL service = new CategoriesDAL())
            {
                var category = service.GetDataByID(id);
                return View(category);
            }
        }
        [HttpPost, ActionName("EditCategories")] //blm bisa
        public ActionResult EditPost(int? id, Categories cat) //int? --> bisa diisi nilai NULL
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (CategoriesDAL service = new CategoriesDAL())
            {

                try
                {
                    service.Edit(id.Value, cat);
                    TempData["Message"] = Helper.MsgBox.GetMsg("success", "Success! ", "Your data " + cat.CategoryName + " has been updated");

                }
                catch (Exception ex)
                {
                    TempData["Message"] = Helper.MsgBox.GetMsg("danger", "Error", ex.Message);

                }
            }
            return RedirectToAction("Index");

        }


        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                using (CategoriesDAL service = new CategoriesDAL())
                    try
                    {
                        service.Delete(id.Value);
                        TempData["Message"] = Helper.MsgBox.GetMsg("success", "Success! ", "Your data has been removed");

                    }
                    catch (Exception ex)
                    {

                        TempData["Message"] = Helper.MsgBox.GetMsg("danger", "Error", ex.Message);

                    }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Search(string txtSearch)
        {
            using (CategoriesDAL cat = new CategoriesDAL())
            {
                var result = cat.Search(txtSearch).ToList();
                return View("Index", result);
            }
        }
    }
}