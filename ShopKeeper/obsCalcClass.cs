using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopKeeper
{
    class obsCalcClass
    {
        CPU objCPU;
        int []weightsCPU;
        int indexFounded;
        public obsCalcClass(float coresWeight,float taktWeight,float priceWeight)
        {
            objCPU = new CPU();
            normCPUS();
        }
        private void normCPUS()
        {
            int steps = 5;

            int minCores = 2;
            int maxCores = 17;
            int minTakt = 1450;
            int maxTakt = 3802;
            int minPrice = 1600;
            int maxPrice = 22502;

            float stepCores = (maxCores - minCores) / steps;
            float stepTakt = (maxTakt - minTakt) / steps;
            float stepPrice = (maxPrice-minPrice) / steps;

            float[] stepsCores = new float[steps];
            float[] stepsTakt = new float[steps];
            float[] stepsPrice = new float[steps];
            stepsCores[0] = minCores;
            stepsTakt[0] = minTakt;
            stepsPrice[0] = minPrice;

            for(int i = 1; i < steps; i++)
            {
                stepsCores[i] = stepsCores[i - 1] + stepCores;
                stepsTakt[i] = stepsTakt[i - 1] + stepTakt;
                stepsPrice[i] = stepsPrice[i - 1] + stepPrice;
            }
            int vozrX = 1;
            int ubyvX = 5;
            for(int i = 0; i < objCPU.GetCountCPUs(); i++)
            {
                for(int j = 0; j < steps-1; j++)
                {
                    vozrX = 1;
                    ubyvX = 5;
                    if (objCPU.cpuList.ElementAt(i).Value.countCores_CPU>=stepsCores[j] &&
                        objCPU.cpuList.ElementAt(i).Value.countCores_CPU < stepsCores[j + 1])
                    {
                        objCPU.cpuList.ElementAt(i).Value.countCores_CPU = vozrX;
                    }
                    if(objCPU.cpuList.ElementAt(i).Value.frequency_CPU >= stepsTakt[j] &&
                        objCPU.cpuList.ElementAt(i).Value.frequency_CPU < stepsTakt[j + 1])
                    {
                        objCPU.cpuList.ElementAt(i).Value.frequency_CPU = vozrX;
                    }
                    if (objCPU.cpuList.ElementAt(i).Value.price_CPU>= stepsPrice[j] &&
                        objCPU.cpuList.ElementAt(i).Value.price_CPU < stepsPrice[j + 1])
                    {
                        objCPU.cpuList.ElementAt(i).Value.price_CPU = ubyvX;
                    }
                    vozrX++;
                    ubyvX--;
                }
            }
        }
        private void calc()
        {
            int max = int.MinValue;
            indexFounded= 0;
            weightsCPU = new int[objCPU.GetCountCPUs()];
            for(int i = 0; i < weightsCPU.Length; i++)
            {
                if( (objCPU.cpuList.ElementAt(i).Value.countCores_CPU +
                    objCPU.cpuList.ElementAt(i).Value.frequency_CPU +
                    objCPU.cpuList.ElementAt(i).Value.price_CPU) > max)
                {
                    max = objCPU.cpuList.ElementAt(i).Value.countCores_CPU +
                    objCPU.cpuList.ElementAt(i).Value.frequency_CPU +
                    objCPU.cpuList.ElementAt(i).Value.price_CPU;
                    indexFounded = i;
                }
            }
            
        }
    }
}
