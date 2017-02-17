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
    //TODO - use IOC constiner for dependency injection
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ITaskListManager taskListManager = new TaskListManager();
            var data = taskListManager.GetAll();

            return View();
        }

        [HttpGet]
        public JsonResult GetData(int number = 10)
        {
            ITaskListManager taskListManager = new TaskListManager();
            var data = taskListManager.GetAll();

            return Json(data, JsonRequestBehavior.AllowGet);
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

            ITaskListManager taskListManager = new TaskListManager();
            ToDoTask task = new ToDoTask()
            {
                ToDoListID = 1,
                ToDoTaskName = model.TaskName,
                SortOrder = model.SortOrder
            };
            var newTask = taskListManager.Add(task);

            var data = taskListManager.GetAll();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteRecord(int id)
        {
            ViewBag.Message = "Your application description page.";

            ITaskListManager taskListManager = new TaskListManager();
            taskListManager.Remove(id);
            var data = taskListManager.GetAll();

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