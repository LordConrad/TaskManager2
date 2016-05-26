using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager2.DataAccess.Services
{
    public interface ITaskService
    {
        IEnumerable<Models.Task> GetAllTasks();
    }
}
