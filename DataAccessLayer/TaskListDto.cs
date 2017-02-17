using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TaskListDto
    {
        public int TaskListId { get; set; }
        public string ListName { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int SortOrder { get; set; }
    }
}
