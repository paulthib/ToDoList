using Database;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer
{
    public class TaskListManager : ITaskListManager
    {
        public ToDoTask Add(ToDoTask task)
        {
            using (var context = new ToDoListEntities())
            {
                context.ToDoTasks.Add(task);
                context.SaveChanges();

                var data = from t in context.ToDoTasks
                           where t.ToDoTaskID == 1
                           select t;

                //TODO - use a DTO (is it necessary if using poco????)
                ToDoDto dto = new ToDoDto(task);
                return task;
            }

        }
        public ToDoTask Update(ToDoTask task)
        {
            using (var context = new ToDoListEntities())
            {
                context.ToDoTasks.Attach(task);
                var entry = context.Entry(task);
                entry.State = EntityState.Modified;
                entry.Property(e => e.ToDoListID).IsModified = false;
                context.SaveChanges();
                return task;
            }

        }
        public void Remove(int taskId)
        {
            ToDoTask task = new ToDoTask()
            {
                ToDoTaskID = taskId 
            };
            using (var context = new ToDoListEntities())
            {
                context.ToDoTasks.Attach(task);
                context.ToDoTasks.Remove(task);
                context.SaveChanges();
            }

        }

        public ToDoTask Get(int taskId)
        {
            using (var context = new ToDoListEntities())
            {
                //force return of simple poco object instead of proxy
                context.Configuration.ProxyCreationEnabled = false;
                var task = context.ToDoTasks.SingleOrDefault(t => t.ToDoTaskID == taskId);
                return task;
            }

        }

        public void ClearAllTasks()
        {
            using (var context = new ToDoListEntities())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [ToDoTask]");
                context.SaveChanges();
            }

        }
        public List<TaskListDto> GetAll()
        {

            using (var context = new ToDoListEntities())
            {
                var results = from t in context.ToDoTasks
                               join l in context.ToDoLists on t.ToDoListID equals l.ToDoListID
                               orderby t.SortOrder
                              select new TaskListDto()
                              {
                                  TaskListId = t.ToDoListID,
                                  TaskId = t.ToDoTaskID,
                                  ListName = l.ToDoListName,
                                  TaskName = t.ToDoTaskName,
                                  SortOrder = t.SortOrder
                              };
                return results.ToList();
            }

        }
    }

}
