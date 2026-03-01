using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class TaskItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = "";
        public DateTime Due { get; set;} = DateTime.Now;
        public string Status { get; set; } = "Open"; // Open / Completed
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? CompletedAt { get; set; } = null;
        public int? MinutesSpent { get; set; } = null;
        public string AssignmentType { get; set; } = "";

    }
}
