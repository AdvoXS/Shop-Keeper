using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopKeeper
{
    class SubOptimCalcClass
    {
        CPU cpu;
        public int countFounded, indexFounded;
        public List<int> foundedIndexCpus;
        public bool oneCPU;

        public SubOptimCalcClass(string mainKriterii, int minKrit1, int maxKrit1, int minKrit2, int maxKrit2)
        {
            List<int> newArr = new List<int>();
            foundedIndexCpus = new List<int>();
            newArr.Add(0);
            cpu = new CPU();
            calcBorder(mainKriterii, minKrit1, maxKrit1, minKrit2, maxKrit2);
            oneCPU = false;
            if (mainKriterii == "Количество ядер")
            {
                int max = int.MinValue;
                for (int i = 0; i < foundedIndexCpus.Count; i++)
                {
                    if (cpu.cpuList.ElementAt(foundedIndexCpus[i]).Value.countCores_CPU > max)
                    {
                        max = cpu.cpuList.ElementAt(foundedIndexCpus[i]).Value.countCores_CPU;
                        countFounded = 1;
                        indexFounded = foundedIndexCpus[i];
                        if (foundedIndexCpus.Count != 0)
                        {
                            newArr.Clear();
                            newArr.Add(0);
                        }
                        newArr[0] = foundedIndexCpus[i];
                    }
                    else if (cpu.cpuList.ElementAt(foundedIndexCpus[i]).Value.countCores_CPU == max)
                    {
                        countFounded++;
                        newArr.Add(foundedIndexCpus[i]);
                    }
                }
            }
            else if (mainKriterii == "Тактовая частота")
            {
                int max = int.MinValue;
                for (int i = 0; i < foundedIndexCpus.Count; i++)
                {
                    if (cpu.cpuList.ElementAt(foundedIndexCpus[i]).Value.frequency_CPU> max)
                    {
                        max = cpu.cpuList.ElementAt(foundedIndexCpus[i]).Value.frequency_CPU;
                        countFounded = 1;
                        indexFounded = foundedIndexCpus[i];
                        if (newArr.Count != 0)
                        {
                            newArr.Clear();
                            newArr.Add(0);
                        }
                        newArr[0] = foundedIndexCpus[i];
                    }
                    else if (cpu.cpuList.ElementAt(foundedIndexCpus[i]).Value.frequency_CPU == max)
                    {
                        countFounded++;
                        newArr.Add(foundedIndexCpus[i]);
                    }
                }
            }
            else if (mainKriterii == "Цена")
            {
                int max = int.MaxValue;
                for (int i = 0; i < foundedIndexCpus.Count; i++)
                {
                    if (cpu.cpuList.ElementAt(foundedIndexCpus[i]).Value.price_CPU < max)
                    {
                        max = cpu.cpuList.ElementAt(foundedIndexCpus[i]).Value.price_CPU;
                        countFounded = 1;
                        indexFounded = foundedIndexCpus[i];
                        if (newArr.Count != 0)
                        {
                            newArr.Clear();
                            newArr.Add(0);
                        }
                        newArr[0] = foundedIndexCpus[i];
                    }
                    else if (cpu.cpuList.ElementAt(foundedIndexCpus[i]).Value.price_CPU == max)
                    {
                        countFounded++;
                        newArr.Add(foundedIndexCpus[i]);
                    }
                }
            }

            if (countFounded > 1)
            {
                oneCPU = false;
            }
            else if (countFounded == 1)
            {
                foundedIndexCpus = newArr;
                oneCPU = true;
            }
        }
        private void calcBorder(string main, int min1,int max1,int min2, int max2)
        {
            int nowCPUs = 0;
           
            for (int i = 0; i < cpu.GetCountCPUs(); i++)
            {
                if (main == "Количество ядер" && cpu.cpuList.ElementAt(i).Value.frequency_CPU >= min1 && cpu.cpuList.ElementAt(i).Value.frequency_CPU <= max1
                        && cpu.cpuList.ElementAt(i).Value.price_CPU >= min2 && cpu.cpuList.ElementAt(i).Value.price_CPU <= max2)
                {foundedIndexCpus.Add(i); nowCPUs++; }

                else if (main == "Тактовая частота" && cpu.cpuList.ElementAt(i).Value.countCores_CPU >= min1 && cpu.cpuList.ElementAt(i).Value.countCores_CPU <= max1
                        && cpu.cpuList.ElementAt(i).Value.price_CPU >= min2 && cpu.cpuList.ElementAt(i).Value.price_CPU <= max2)
                { foundedIndexCpus.Add(i); nowCPUs++; }
                else if (main == "Цена" && cpu.cpuList.ElementAt(i).Value.countCores_CPU>= min1 && cpu.cpuList.ElementAt(i).Value.countCores_CPU<= max1
                        && cpu.cpuList.ElementAt(i).Value.frequency_CPU >= min2 && cpu.cpuList.ElementAt(i).Value.frequency_CPU <= max2)
                { foundedIndexCpus.Add(i); nowCPUs++; }
            }
        }
    }
}
