using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_4.Models;

namespace Workshop_4.Services
{
    class SpecificsEditorViaWindow : IJobEditorService
    {
        public void Edit(Job job)
        {
            new JobEditor(job).ShowDialog();
        }
    }
}
