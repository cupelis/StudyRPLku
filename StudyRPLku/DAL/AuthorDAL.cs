using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using StudyRPLku.Models;

namespace StudyRPLku.DAL
{
    public class AuthorDAL :IDisposable
    {
        private CommerceModels db = new CommerceModels();
        public void Dispose()
        {
            db.Dispose();
        }

        public IQueryable<Authors> GetData()
        {
            var hasil = from a in db.Authors orderby a.AuthorID select a;
            return hasil;
        }

        public string getNameByID(int auID)
        {
            var first = (from a in db.Authors where a.AuthorID == auID select a.FirstName).SingleOrDefault();
            var last = (from a in db.Authors where a.AuthorID == auID select a.LastName).SingleOrDefault();

            return first + "" + last;
        }

        public Authors GetDataByID(int auID)
        {
            var result = (from a in db.Authors where a.AuthorID == auID select a).SingleOrDefault();
            return result;
        }



        // -- 

        public void tambah(Authors obj)
        {
            try
            {
                db.Authors.Add(obj);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        ////Edit cara 1
        //public void Edits(int AuID, Authors obj)
        //{
        //    var result = GetDataByID(AuID);
        //    if (result != null)
        //    {
        //        result.FirstName = obj.FirstName;
        //        result.LastName = obj.LastName;
        //        result.Email = obj.Email;
        //        try
        //        {
        //            db.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {

        //            throw new Exception(ex.Message);
        //        }
        //    }
        //}
        ////Edit cara 2
        //public void Edit(Authors obj)
        //{
        //    var model = GetDataByID(obj.AuthorID);
        //    if (model != null)
        //    {
        //        model.FirstName = obj.FirstName;
        //        model.LastName = obj.LastName;
        //        model.Email = obj.Email;
        //        try
        //        {
        //            db.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {

        //            throw new Exception(ex.Message);
        //        }
        //    }
        //}
        public void Edit(int value, Authors Cat)
        {
            var result = GetDataByID(Cat.AuthorID);
            if (result != null)
            {
                result.FirstName = Cat.FirstName;
                result.LastName = Cat.LastName;
                result.Email = Cat.Email;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Data Tidak Ditemukan!");
            }
        }



        public void Delete(int AuID)
        {
            var result = GetDataByID(AuID);
            if (result != null)
                db.Authors.Remove(result);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<Authors> Search(string txtSearch)
        {
            var result = from a in db.Authors
                         where a.FirstName.ToLower().Contains(txtSearch.ToLower())
                         select a;
                         
            return result;
        }

        //----------------- Coba Search -----------------------------------\\

        //private IQueryable<Authors> txtSearch()
        //{
        //    var result = from b in db.Authors.Include("Authors")
        //                 orderby b.FirstName
        //                 select new Authors
        //                 {
        //                     FirstName = b.FirstName,
        //                     LastName = b.LastName,
        //                     Email = b.Email
        //                 };
        //}

        //public IQueryable<Authors> SearchAuthor(String SelectAuthor)
        //{
        //    IQueryable<Authors> result;
        //    if (SelectAuthor == "FirstName")
        //    {
        //        result = from b in db.Authors.Include("Authors")
        //                 orderby b.FirstName
        //                 where b.FirstName.ToLower().Contains(txtSearch.Tolower())
        //                 select new Authors
        //                 {
        //                     FirstName = b.FirstName,
        //                     LastName = b.LastName,
        //                     Email = b.Email
        //                 };
        //    }

    }
}