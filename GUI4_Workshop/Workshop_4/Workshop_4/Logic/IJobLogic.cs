using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_4.Models;

namespace Workshop_4.Logic
{
    public interface IJobLogic
    {
        int AllCost { get; }
        void AddToJobs(Job job);
        void EditJob(Job job);
        void AddToOrder(Job job);
        void EditOrder(Job job);
        void RemoveFromOrder(Job job);
        void SetupCollections(IList<Job> jobscollection, IList<Job> jobs);
    }
}
