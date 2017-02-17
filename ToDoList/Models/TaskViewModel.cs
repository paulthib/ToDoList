﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class TaskViewModel
    {
        [MaxLength(50)]
        public string TaskName { get; set; }
        public int SortOrder { get; set; }
    }
}