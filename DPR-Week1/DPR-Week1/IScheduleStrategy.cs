using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPR_Week1
{
    public interface IScheduleStrategy
    {
         string getName();
        int nextNumber(List<int> lstNumber, int previousNumber,int startPoint);

    }
}
