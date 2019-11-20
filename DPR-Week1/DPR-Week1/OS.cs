using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPR_Week1
{
    public class OS
    {
        private IScheduleStrategy scheduleStrategy;
        private List<int> lstRequest = new List<int>();
        private List<int> alreadyRead = new List<int>();
        public int previousNumber;

        public int StartPoint {get; set;}
        public void reset()
        {
            lstRequest.Clear();
            previousNumber = 0;
        }
        public List<int> getAlreadyRead()
        {
            return alreadyRead;
        }
        public List<int> getlstRequest()
        {
            return lstRequest;
        }
        public void Add(int request)
        {
            lstRequest.Add(request);
        }
        public void AddStrategy( IScheduleStrategy schedule)
        {
            this.scheduleStrategy = schedule;
        }
        public void readNext()
        {
            this.previousNumber = this.scheduleStrategy.nextNumber(lstRequest, this.previousNumber, this.StartPoint);
            this.lstRequest.Remove(previousNumber);
            this.alreadyRead.Add(previousNumber);

        }
    }
}
