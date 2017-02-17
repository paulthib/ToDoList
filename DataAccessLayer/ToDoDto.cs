using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ToDoDto
    {
        public int ToDoTaskID { get; set; }
        public int ToDoListID { get; set; }
        public string ToDoTaskName { get; set; }
        public int SortOrder { get; set; }
        public string ToDoListName { get; set; }
        public int ToDoListId { get; set; }

        public ToDoDto(ToDoTask task)
        {
            ToDoTaskID = task.ToDoTaskID;
            ToDoListID = task.ToDoListID;
            ToDoTaskName = task.ToDoTaskName;
            SortOrder = task.SortOrder;
            //ToDoListName = task.t
            //ToDoListId = task.
        }
    }
}
