using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Parse;

namespace ParseStarter.Web.Controllers
{
    public class TestObjectController : Controller
    {
        //
        // GET: /Foo/
        public async Task<ActionResult> Index()
        {
            var query = ParseObject.GetQuery("TestObject");
            query.Limit(25);
            var results = await query.FindAsync();
            var model =
                results.Select(
                    x =>
                    {
                        var expando = new ExpandoObject();
                        var dictObj = (ICollection<KeyValuePair<string, object>>) expando;
                        dictObj.Add(new KeyValuePair<string, object>("ObjectId", x.ObjectId));
                        dictObj.Add(new KeyValuePair<string, object>("CreatedAt", x.CreatedAt));
                        dictObj.Add(new KeyValuePair<string, object>("UpdatedAt", x.UpdatedAt));
                        dictObj.Add(new KeyValuePair<string, object>("Properties",
                            x.ToDictionary(p => p.Key, p => p.Value)));
                        dynamic dyn = expando;
                        return dyn;
                    });
            return View(model);
        }

        ////
        //// GET: /Foo/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        ////
        //// GET: /Foo/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /Foo/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /Foo/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /Foo/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /Foo/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /Foo/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
