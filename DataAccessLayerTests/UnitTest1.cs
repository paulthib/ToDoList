using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using Database;

namespace DataAccessLayerTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void TestSetup()
        {
            ITaskListManager c = new TaskListManager();
            c.ClearAllTasks();
            var data = c.GetAll();
            Assert.AreEqual(0, data.Count);
        }

        [TestMethod]
        public void TestMethod_Add()
        {
            ITaskListManager c = new TaskListManager();
            ToDoTask task = new ToDoTask()
            {
                ToDoListID = 1,
                ToDoTaskName = "My new task",
                SortOrder = 0
            };
            var addedTask = c.Add(task);
            var data = c.GetAll();
            Assert.AreEqual(1, data.Count);
        }

        private const string UpdatedTaskName = "Modified task name";
        [TestMethod]
        public void TestMethod_AddModify()
        {
            ITaskListManager c = new TaskListManager();
            ToDoTask task = new ToDoTask()
            {
                ToDoListID = 1,
                ToDoTaskName = "My new task",
                SortOrder = 0
            };
            c.Add(task);
            var data = c.GetAll();
            Assert.AreEqual(1, data.Count);

            task.ToDoTaskName = UpdatedTaskName;
            c.Update(task);
            var updatedTask = c.Get(task.ToDoTaskID);
            Assert.AreEqual(UpdatedTaskName, updatedTask.ToDoTaskName);

        }

        [TestMethod]
        public void TestMethod_AddDelete()
        {
            ITaskListManager c = new TaskListManager();
            ToDoTask task = new ToDoTask()
            {
                ToDoListID = 1,
                ToDoTaskName = "My next task",
                SortOrder = 0
            };
            var addedTask = c.Add(task);
            var data = c.GetAll();
            Assert.AreEqual(1, data.Count);

            //remove the item, then check
            c.Remove(addedTask.ToDoTaskID);
            data = c.GetAll();
            Assert.AreEqual(0, data.Count);

        }
    }
}
