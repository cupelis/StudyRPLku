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
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            using (AuthorDAL service = new AuthorDAL())
            {
                var authors = service.GetData().ToList();
                if (TempData["Message"] != null)
                {
                    ViewBag.msg = TempData["Message"].ToString();
                }
                return View(authors);
            }
            
        }

        public ActionResult CreateAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAuthor(Authors au)
        {
            using (AuthorDAL service = new AuthorDAL())
            {
                try
                {
                    service.tambah(au);
                    TempData["Message"] = Helper.MsgBox.GetMsg("success", "Success! ", "Your data has been added");

                }
                catch (Exception ex)
                {

                    TempData["Message"] = Helper.MsgBox.GetMsg("danger", "Error", ex.Message);

                }

            }
            return RedirectToAction("Index");
        }

        //-------------------------------------------------------------

        //public ActionResult EditAuthor(int id)
        //{
        //    using (AuthorDAL service = new AuthorDAL())
        //    {
        //        var Author = service.GetDataByID(id);
        //        return View(Author);
        //    }
        //}
        //[HttpPost, ActionName("EditAuthors")] //blm bisa
        //public ActionResult EditPost(int? id, Authors Aut) //int? --> bisa diisi nilai NULL
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    using (AuthorDAL service = new AuthorDAL())
        //    {

        //        try
        //        {
        //            service.Edit(id.Value, Aut);
        //            TempData["Message"] = Helper.MsgBox.GetMsg("success", "Success! ", "Your data has been updated");

        //        }
        //        catch (Exception ex)
        //        {
        //            TempData["Message"] = Helper.MsgBox.GetMsg("danger", "Error", ex.Message);

        //        }
        //    }
        //    return RedirectToAction("Index");

        //}

        public ActionResult EditAuthor(int id)
        {
            using (AuthorDAL service = new AuthorDAL())
            {
                var author = service.GetDataByID(id);
                return View(author);
            }
        }
        [HttpPost, ActionName("EditAuthor")] //blm bisa
        public ActionResult EditPost(int? id, Authors cat) //int? --> bisa diisi nilai NULL
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (AuthorDAL service = new AuthorDAL())
            {

                try
                {
                    service.Edit(id.Value, cat);
                    TempData["Message"] = Helper.MsgBox.GetMsg("success", "Success! ", "Your data has been updated");

                }
                catch (Exception ex)
                {
                    TempData["Message"] = Helper.MsgBox.GetMsg("danger", "Error", ex.Message);

                }
            }
            return RedirectToAction("Index");

        }



        //------------------------------------------------------------------------------------------------------

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                using (AuthorDAL service = new AuthorDAL())
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
            using (AuthorDAL aut = new AuthorDAL())
            {
                var result = aut.Search(txtSearch).ToList();
                return View("Index", result);
            }
        }
    }
}