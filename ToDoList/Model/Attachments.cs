using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Model
{
    public class Attachments
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int? TaskId { get; set; }
        [ForeignKey("TaskId")]
        public virtual todolist Todolist { get; set; }
    }
}
