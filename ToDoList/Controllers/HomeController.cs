using DataAccessLayer;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        //use autofac for dependency injection
        private ITaskListManager _taskListManager;
        public HomeController(ITaskListManager taskListManager)
        {
            _taskListManager = taskListManager;
        }

        public ActionResult Index()
        {
            var data = _taskListManager.GetAll();

            return View();
        }

        [HttpGet]
        public JsonResult GetData(int number = 10)
        {
            var data = _taskListManager.GetAll().OrderBy(t => t.SortOrder);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditTask(int? id)
        {
            var model = _taskListManager.Get(id.Value);

            return PartialView(model);
        }

        [HttpPost]
        public JsonResult EditTask(ToDoTask model)
        {
            var updatedModel = _taskListManager.Update(model);

            return Json(new
            {
                success = true
            }
            , JsonRequestBehavior.AllowGet);
        }

        public JsonResult Remove(int id)
        {
            ViewBag.Message = "Your application description page.";

            return Json(new
            {
                success = true,
                errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage)
            }
            ,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateTask(TaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false,
                    errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage)
                });
            }

            ToDoTask task = new ToDoTask()
            {
                ToDoListID = 1,
                ToDoTaskName = model.TaskName,
                SortOrder = model.SortOrder
            };
            var newTask = _taskListManager.Add(task);

            var data = _taskListManager.GetAll();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteRecord(int id)
        {
            ViewBag.Message = "Your application description page.";

            _taskListManager.Remove(id);
            var data = _taskListManager.GetAll();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}