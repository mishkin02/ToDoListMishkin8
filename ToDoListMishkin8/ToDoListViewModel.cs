using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListMishkin8
{
    public class ToDoTask
    {
        public string Name { get; set; }
        public bool Check { get; set; }

        public ToDoTask(string name, bool check)
        {
            Name = name;
            Check = check;
        }
    }
}
