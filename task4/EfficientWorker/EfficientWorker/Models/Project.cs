using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfficientWorker.Models
{
    //Название проекта, сумма премии рабочего
    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int WorkerID { get; set; }
        public int ProjectCost { get; set; }

        public Worker Worker { get; set; }
    }
}
