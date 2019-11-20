using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPR_Week1
{
    class ScanDiskScheduling : IScheduleStrategy
    {
        public string getName()
        {
            return "Scan Disk Scheduling";
        }
    
        public int nextNumber(List<int> lstNumber, int previousNumber, int startPoint)
        {

            bool tempDir = true;
            int readValue = tempDir ? 100 : 0;

            List<int> sortedRequest = new List<int>();
            foreach (int i in lstNumber)
            {
                sortedRequest.Add(i);
            }
           // sortedRequest.Add(startPoint);
            sortedRequest.Sort();
            int position = 0;
            int temp = int.MaxValue;
            for(int i = 0; i < sortedRequest.Count(); i++)
            {
                if(Math.Abs(sortedRequest[i]- startPoint) < temp)
                {
                    temp = Math.Abs(sortedRequest[i] - startPoint);
                }
            }
            for (int i = 0; i < sortedRequest.Count(); i++)
            {
                if (Math.Abs(sortedRequest[i] - startPoint) == temp)
                {
                   position= i;
                    break;
                }
            }
            for (int i = 0;i<sortedRequest.Count();i++)
            {
                if (tempDir)
                {
                    if (sortedRequest[position-i] < previousNumber)
                    {
     
                        continue;
                    }
                    readValue = sortedRequest[position-i];
                    break;
                }
                if (sortedRequest[position + i] > previousNumber)
                {
                    i++;
                    continue;
                }
                readValue = sortedRequest[position+i];
                break;
            }
            if (readValue == 100 || readValue == 0)
            {
                tempDir = !tempDir;
            }

            return readValue;

        }
    }
}
//for(i=0;i<n;i++)
// {
// scanf("%d",&d[i]);
// }
// d[n]=disk;
// n=n+1;
// for(i=0;i<n;i++)    // sorting disk locations
// {
//  for(j=i;j<n;j++)
//  {
//    if(d[i]>d[j])
//    {
//    temp=d[i];
//    d[i]=d[j];
//    d[j]=temp;
//    }
//  }
// }
// max=d[n];
// for(i=0;i<n;i++)   // to find loc of disc in array
// {
// if(disk==d[i]) { dloc=i; break;  }
// }
// for(i=dloc;i>=0;i--)
// {
// printf("%d -->", d[i]);
// }
// printf("0 -->");
// for(i=dloc+1;i<n;i++)
// {
// printf("%d-->", d[i]);
// }