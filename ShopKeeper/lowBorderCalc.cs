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
        int countFoundedCPUs;
        List<int> indexFoundedCPUs;
        public lowBorderCalc(int minCores, int maxCores, int minFrenq, int maxFrenq,
            int minPrice, int maxPrice, bool intVideo, bool SO, string type = "", string socket = "")
        {
            objCPU = new CPU();
            countFoundedCPUs = 0;
            for (int i = 0; i < objCPU.GetCountCPUs(); i++)
            {

                if ((objCPU.cpuList.ElementAt(i).Value.socket_CPU == socket || socket == "")
                        && (objCPU.cpuList.ElementAt(i).Value.type_CPU == type || type == "")
                        && (objCPU.cpuList.ElementAt(i).Value.countCores_CPU >= minCores && objCPU.cpuList.ElementAt(i).Value.countCores_CPU <= maxCores)
                        && (objCPU.cpuList.ElementAt(i).Value.frequency_CPU >= minFrenq && objCPU.cpuList.ElementAt(i).Value.frequency_CPU <= maxFrenq)
                        && (objCPU.cpuList.ElementAt(i).Value.price_CPU >= minPrice && objCPU.cpuList.ElementAt(i).Value.price_CPU <= maxPrice
                        && intVideo == objCPU.cpuList.ElementAt(i).Value.integratedVideo_CPU
                        && objCPU.cpuList.ElementAt(i).Value.includedCS_CPU == SO))
                {
                    countFoundedCPUs++;
                    indexFoundedCPUs.Add(i);
                }
            }
        }
    }
}
