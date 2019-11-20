using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPR_Week1
{
    class FCFSDiskScheduling : IScheduleStrategy
    {
        public string getName()
        {
            return "FCFS Disk Scheduling";
        }

        public int nextNumber(List<int> lstNumber, int previousNumber, int startPoint)
        {
            return lstNumber.First();
        }

     
    }
}
