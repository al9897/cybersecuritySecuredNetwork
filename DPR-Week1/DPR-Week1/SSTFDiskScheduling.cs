using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPR_Week1
{
    class SSTFDiskScheduling : IScheduleStrategy
    {
        public string getName()
        {
            return "SSTF Disk Scheduling";
        }
        
        public int nextNumber(List<int> lstNumber, int previousNumber, int startPoint)
        {
            int closestToPrevious = int.MaxValue;
            int closestPosition = -1;
            foreach (int req in lstNumber)
            {
                int distance = Math.Abs(startPoint - req);
                if (distance >= closestToPrevious)
                {
                    continue;
                }
                closestToPrevious = distance;
                closestPosition = req;
            }

            return closestPosition;



        }
    }
}
