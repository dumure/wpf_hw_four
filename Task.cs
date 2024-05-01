using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_hw_four
{
    internal class Task
    {
        public string TaskText { get; }
        public DateTime TaskDeadline { get; }
        public States State { get; }

        public Task(string taskText, DateTime taskDeadline, States state)
        {
            TaskText = taskText;
            TaskDeadline = taskDeadline;
            State = state;
        }
        public override string ToString()
        {
            return $"{TaskText} - {TaskDeadline.ToString("yyyy-MM-dd")}";
        }
    }
}
