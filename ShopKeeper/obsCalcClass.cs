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
        public int indexFounded;
        public obsCalcClass(float coresWeight,float taktWeight,float priceWeight)
        {
            objCPU = new CPU();
            normCPUS();
            calc(coresWeight,taktWeight,priceWeight);
        }
        private void normCPUS()
        {
            int steps = 20;

            float minCores = 1;
            float maxCores = 16;
            float minTakt = 1446;
            float maxTakt = 3856;
            float minPrice = 1597;
            float maxPrice = 26301;

            float stepCores = (maxCores - minCores) / steps;
            float stepTakt = (maxTakt - minTakt) / steps;
            float stepPrice = (maxPrice-minPrice) / steps;

            float[] stepsCores = new float[steps+1];
            float[] stepsTakt = new float[steps+1];
            float[] stepsPrice = new float[steps+1];
            stepsCores[0] = minCores;
            stepsTakt[0] = minTakt;
            stepsPrice[0] = minPrice;

            for(int i = 1; i < steps+1; i++)
            {
                stepsCores[i] = stepsCores[i - 1] + stepCores;
                stepsTakt[i] = stepsTakt[i - 1] + stepTakt;
                stepsPrice[i] = stepsPrice[i - 1] + stepPrice;
            }
            int vozrX = 1;
            int ubyvX = steps;
            for(int i = 0; i < 13; i++)
            {
                vozrX = 1;
                ubyvX = steps;
                for (int j = 0; j < steps; j++)
                {
                    if (objCPU.cpuList.ElementAt(i).Value.countCores_CPU>stepsCores[j] &&
                        objCPU.cpuList.ElementAt(i).Value.countCores_CPU <= stepsCores[j + 1])
                    {
                        objCPU.cpuList.ElementAt(i).Value.countCores_CPU = vozrX;
                    }
                    if(objCPU.cpuList.ElementAt(i).Value.frequency_CPU > stepsTakt[j] &&
                        objCPU.cpuList.ElementAt(i).Value.frequency_CPU <= stepsTakt[j + 1])
                    {
                        objCPU.cpuList.ElementAt(i).Value.frequency_CPU = vozrX;
                    }
                    if (objCPU.cpuList.ElementAt(i).Value.price_CPU> stepsPrice[j] &&
                        objCPU.cpuList.ElementAt(i).Value.price_CPU <= stepsPrice[j + 1])
                    {
                        objCPU.cpuList.ElementAt(i).Value.price_CPU = ubyvX;
                    }
                    vozrX++;
                    ubyvX--;
                }
            }
        }
        private void calc(float cor,float takt,float prices)
        {
            float max = int.MinValue;
            indexFounded= 0;
            weightsCPU = new int[objCPU.GetCountCPUs()];
            for(int i = 0; i < weightsCPU.Length; i++)
            {
                if( (objCPU.cpuList.ElementAt(i).Value.countCores_CPU*cor +
                    objCPU.cpuList.ElementAt(i).Value.frequency_CPU*takt +
                    objCPU.cpuList.ElementAt(i).Value.price_CPU*prices) > max)
                {
                    max = objCPU.cpuList.ElementAt(i).Value.countCores_CPU*cor +
                    objCPU.cpuList.ElementAt(i).Value.frequency_CPU*takt +
                    objCPU.cpuList.ElementAt(i).Value.price_CPU*prices;
                    indexFounded = i;
                }
            }
            
        }
    }
}
