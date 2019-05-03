using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopKeeper
{
    class lowBorderCalc
    {
        CPU objCPU;
        public int countFoundedCPUs;
        public List<int> indexFoundedCPUs;
        public lowBorderCalc(int minCores, int maxCores, int minFrenq, int maxFrenq,
            int minPrice, int maxPrice)
        {
            objCPU = new CPU();
            indexFoundedCPUs = new List<int>();
            countFoundedCPUs = 0;
            for (int i = 0; i < objCPU.GetCountCPUs(); i++)
            {

                if ((objCPU.cpuList.ElementAt(i).Value.countCores_CPU >= minCores && objCPU.cpuList.ElementAt(i).Value.countCores_CPU <= maxCores)
                        && (objCPU.cpuList.ElementAt(i).Value.frequency_CPU >= minFrenq && objCPU.cpuList.ElementAt(i).Value.frequency_CPU <= maxFrenq)
                        && (objCPU.cpuList.ElementAt(i).Value.price_CPU >= minPrice && objCPU.cpuList.ElementAt(i).Value.price_CPU <= maxPrice
                       ))
                {
                    countFoundedCPUs++;
                    indexFoundedCPUs.Add(i);
                }
            }
        }
    }
}
