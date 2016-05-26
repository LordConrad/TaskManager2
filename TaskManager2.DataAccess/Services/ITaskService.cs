using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager2.DataAccess.Models;

namespace TaskManager2.DataAccess.Services
{
    public interface ITaskService
    {
        IEnumerable<MyTaskInList> GetAllTasks();
    }
}
