using System.Collections.Generic;
using Database;

namespace DataAccessLayer
{
    public interface ITaskListManager
    {
        ToDoTask Add(ToDoTask task);
        void ClearAllTasks();
        ToDoTask Get(int taskId);
        List<TaskListDto> GetAll();
        void Remove(int taskId);
        ToDoTask Update(ToDoTask task);
    }
}