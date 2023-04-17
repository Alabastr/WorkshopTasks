using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_4.Models;
using Workshop_4.Services;

namespace Workshop_4.Logic
{
    public class JobLogic : IJobLogic
    {
        IList<Job> jobs;
        IList<Job> jobsOrdered;
        IMessenger messenger;
        IJobEditorService editorService;

        public JobLogic(IMessenger messenger, IJobEditorService editorService)
        {
            this.messenger = messenger;
            this.editorService = editorService;
        }
        public int AllCost
        {
            get
            {
                return jobsOrdered.Count == 0 ? 0 : jobsOrdered.Sum(t => t.Cost);
            }
        }

    
        public void AddToJobs(Job job)
        {
            jobs.Add(job.GetCopy());
            messenger.Send("Job added to order", "OrderInfo");
        }

        public void AddToOrder(Job job)
        {
            jobsOrdered.Add(job.GetCopy());
            messenger.Send("Job added to order", "OrderInfo");
        }

        public void RemoveFromOrder(Job job)
        {
            jobs.Remove(job.GetCopy());
            messenger.Send("Job removed from order", "OrderInfo");
        }

        public void EditJob(Job job)
        {
            editorService.Edit(job);
        }

        public void EditOrder(Job job)
        {
            editorService.Edit(job);
        }

        public void SetupCollections(IList<Job> jobsOrdered, IList<Job> jobs)
        {
            this.jobs = jobs;
            this.jobsOrdered = jobsOrdered;
        }
    }
}
