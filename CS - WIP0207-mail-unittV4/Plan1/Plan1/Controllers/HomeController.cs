using System;
using System.Web.Mvc;
using Plan1.Models;
	
namespace Plan1.Controllers 
{
    [HandleError]
    public class HomeController : Controller
    {

        IPermissionRepository _repository;

        public HomeController() : this(new EF_PermissionRepository()) { }

        public HomeController(IPermissionRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index()
        {
            ViewData["ControllerName"] = this.ToString();
            return View("Index", _repository.GetAllPermissions());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int? id)
        {
            int idx = id.HasValue ? (int)id : 0;
            Permission cnt = _repository.GetPermissionByID(idx);
            return View("Details", cnt);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View("Create");
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Permission PermissionToCreate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.CreateNewPermission(PermissionToCreate);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
                ViewData["CreateError"] = "Unable to create; view innerexception";
            }

            return View("Create");

        }


        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            var PermissionToEdit = _repository.GetPermissionByID(id);

            return View(PermissionToEdit);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            Permission cnt = _repository.GetPermissionByID(id);

            try
            {
                if (TryUpdateModel(cnt))
                {
                    _repository.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {   // For Demo purpose only
                // Production apps should not display exception data.
                if (ex.InnerException != null)
                    ViewData["EditError"] = ex.InnerException.ToString();
                else
                    ViewData["EditError"] = ex.ToString();
            }

            

            return View(cnt);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            var conToDel = _repository.GetPermissionByID(id);
            return View(conToDel);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _repository.DeletePermission(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult About()
        {
            return View();
        }
    }
}

