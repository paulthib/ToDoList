//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class ToDoTask
    {
        public int ToDoTaskID { get; set; }
        public int ToDoListID { get; set; }
        public string ToDoTaskName { get; set; }
        public int SortOrder { get; set; }
    
        public virtual ToDoList ToDoList { get; set; }
    }
}
