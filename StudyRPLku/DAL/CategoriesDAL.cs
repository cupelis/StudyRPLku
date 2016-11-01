using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudyRPLku.Models;
using System.Text;
using System.Threading.Tasks;


namespace StudyRPLku.DAL
{
    public class CategoriesDAL : IDisposable
    {
        private CommerceModels db = new CommerceModels();



        public void tambah(Categories target)
        {
            try
            {
                db.Categories.Add(target);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<Categories> GetData()
        {
            var result = from c in db.Categories orderby c.CategoryName ascending select c;
            return result;
        }

        public void Dispose()
        {
            db.Dispose();
        }


        public void Edit(int value,Categories Cat)
        {
            var result = GetDataByID(Cat.CategoryID);
            if (result != null)
            {
                result.CategoryName = Cat.CategoryName;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Data Tidak Ditemukan!");
            }
        }




        public Categories GetDataByID(int catID)
        {
            var result = (from c in db.Categories where c.CategoryID == catID select c).SingleOrDefault(); //ngambil satu data
            return result;
        }
        public string GetNameByID(int catID)
        {
            var result = (from c in db.Categories where c.CategoryID == catID select c.CategoryName).SingleOrDefault();
            return result;
        }


        public void Delete(int CatID)
        {
            var result = GetDataByID(CatID);
            if (result != null)
                db.Categories.Remove(result);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //Search
        public IQueryable<Categories> Search(string txtSearch)
        {
            var result = from a in db.Categories
                         where a.CategoryName.ToLower().Contains(txtSearch.ToLower())
                         select a;
            return result;
        }
        //Search
        //public IQueryable<Categories> SearchCategories (string txtSearch)
        //{
        //    IQueryable<Categories> result;
        //    if (txtSearch == "CategoryName")
        //    {
        //        result = from c in db.Categories.Include("Categories")
        //                 orderby c.CategoryName.ToLower().Contains(txtSearch.ToLower())
        //                 select new Categories
        //                 {
        //                     CategoryName = c.CategoryName

        //                 };
                
        //    }
            
        //}

    //    public IQueryable<Categories> SearchByCategories(string txtSearch)
    //    {
    //        IQueryable<Categories> result;
    //        if (txtSearch == "CategoryName")
    //        {
    //            result = from b in db.Categories.Include("Categories")
    //                     orderby b.CategoryName
    //                     where b.CategoryName.ToLower().Contains(txtSearch.ToLower())
    //                     select new Categories
    //                     {
    //                         CategoryID = b.CategoryID,
    //                         CategoryName = b.CategoryName
                             
    //                     };

    //        }
    //        else
    //        {
    //            result = from b in db.Categories.Include("Categories")
    //                     orderby b.CategoryName
    //                     where b.CategoryName.ToLower().Contains(txtSearch.ToLower())
    //                     select new Categories
    //                     {
    //                         CategoryID = b.CategoryID,
    //                         CategoryName = b.CategoryName
    //                     };
    //        }
    //        return result;
    //    }
    }
}