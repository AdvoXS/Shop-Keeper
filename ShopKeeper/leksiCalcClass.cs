using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
namespace ShopKeeper
{
    class leksiCalcClass
    {
        Dictionary<int, Grid> pubStatus;
        CPU cpu;
        public int countFounded,indexFounded;
        List<int> foundedIndexCpus;
       public leksiCalcClass(Dictionary<int, Grid> stat)
        {
            pubStatus = stat;
            cpu = new CPU();
            countFounded = 0;
            indexFounded = 0;
            foundedIndexCpus = new List<int>();
        }
        public void Calc()
        {
            foundedIndexCpus.Add(0);
            if(pubStatus.ElementAt(0).Value.Name== "multiGrid")
            {
                int max = int.MinValue;
                for(int i = 0; i < cpu.GetCountCPUs(); i++)
                {
                    if (cpu.cpuList.ElementAt(i).Value.countCores_CPU > max)
                    {
                        max = cpu.cpuList.ElementAt(i).Value.countCores_CPU;
                        countFounded = 1;
                        indexFounded = i;
                        if (foundedIndexCpus.Count != 0)
                        {
                            foundedIndexCpus.Clear();
                            foundedIndexCpus.Add(0);
                        }
                        foundedIndexCpus[0] = i;
                    }
                    else if(cpu.cpuList.ElementAt(i).Value.countCores_CPU == max)
                    {
                        countFounded++;
                        foundedIndexCpus.Add(i);
                    }
                }
                if (countFounded > 1 && pubStatus.ElementAt(1).Value.Name == "speedGrid")
                {
                    int newcount = countFounded;
                    int[] newIndex = foundedIndexCpus.ToArray();
                    max = int.MinValue;
                    for (int i = 0; i < newcount; i++)
                    {
                        if (cpu.cpuList.ElementAt(newIndex[i]).Value.frequency_CPU > max)
                        {
                            max = cpu.cpuList.ElementAt(newIndex[i]).Value.frequency_CPU;
                            countFounded = 1;
                            indexFounded = foundedIndexCpus[i];
                            if (foundedIndexCpus.Count != 0)
                            {
                                foundedIndexCpus.Clear();
                                foundedIndexCpus.Add(0);
                            }
                            foundedIndexCpus[0] = i;
                        }
                        else if (cpu.cpuList.ElementAt(newIndex[i]).Value.frequency_CPU == max)
                        {
                            countFounded++;
                            foundedIndexCpus.Add(i);
                        }
                    }
                }
                else if(countFounded > 1 && pubStatus.ElementAt(1).Value.Name == "gameGrid")
                {
                    int newcount = countFounded;
                    int[] newIndex = foundedIndexCpus.ToArray();
                    max = int.MaxValue ;
                    for (int i = 0; i < newcount; i++)
                    {
                        if (cpu.cpuList.ElementAt(newIndex[i]).Value.price_CPU < max)
                        {
                            max = cpu.cpuList.ElementAt(newIndex[i]).Value.price_CPU;
                            countFounded = 1;
                            indexFounded = newIndex[i];
                            if (foundedIndexCpus.Count != 0)
                            {
                                foundedIndexCpus.Clear();
                                foundedIndexCpus.Add(0);
                            }
                            foundedIndexCpus[0] = i;
                        }
                        else if (cpu.cpuList.ElementAt(newIndex[i]).Value.price_CPU == max)
                        {
                            countFounded++;
                            foundedIndexCpus.Add(i);
                        }
                    }
                }
            }


            if (pubStatus.ElementAt(0).Value.Name == "speedGrid")
            {
               int max = int.MinValue;
                    for (int i = 0; i < cpu.GetCountCPUs(); i++)
                    {
                        if (cpu.cpuList.ElementAt(i).Value.frequency_CPU > max)
                        {
                        max = cpu.cpuList.ElementAt(i).Value.frequency_CPU;
                countFounded = 1;
                            indexFounded = i;
                            if (foundedIndexCpus.Count != 0)
                            {
                                foundedIndexCpus.Clear();
                                foundedIndexCpus.Add(0);
                            }
                            foundedIndexCpus[0] = i;
                        }
                        else if (cpu.cpuList.ElementAt(i).Value.frequency_CPU == max)
                        {
                            countFounded++;
                            foundedIndexCpus.Add(i);
                        }
                    }
                
                if (countFounded > 1 && pubStatus.ElementAt(1).Value.Name == "multiGrid")
                {
                    int newcount = countFounded;
                    int[] newIndex = foundedIndexCpus.ToArray();
                    max = int.MinValue;
                    for (int i = 0; i < newcount; i++)
                    {
                        if (cpu.cpuList.ElementAt(newIndex[i]).Value.countCores_CPU > max)
                        {
                            max = cpu.cpuList.ElementAt(newIndex[i]).Value.countCores_CPU;
                            countFounded = 1;
                            indexFounded = newIndex[i];
                            if (foundedIndexCpus.Count != 0)
                            {
                                foundedIndexCpus.Clear();
                                foundedIndexCpus.Add(0);
                            }
                            foundedIndexCpus[0] = i;
                        }
                        else if (cpu.cpuList.ElementAt(foundedIndexCpus[i]).Value.countCores_CPU == max)
                        {
                            countFounded++;
                            foundedIndexCpus.Add(i);
                        }
                    }
                }
                else if (countFounded > 1 && pubStatus.ElementAt(1).Value.Name == "gameGrid")
                {
                    int newcount = countFounded;
                    int[] newIndex = foundedIndexCpus.ToArray();
                    max = int.MaxValue;
                    for (int i = 0; i < newcount; i++)
                    {
                        if (cpu.cpuList.ElementAt(newIndex[i]).Value.price_CPU < max)
                        {
                            max = cpu.cpuList.ElementAt(newIndex[i]).Value.price_CPU;
                            countFounded = 1;
                            indexFounded = newIndex[i];
                            if (foundedIndexCpus.Count != 0)
                            {
                                foundedIndexCpus.Clear();
                                foundedIndexCpus.Add(0);
                            }
                            foundedIndexCpus[0] = i;
                        }
                        else if (cpu.cpuList.ElementAt(i).Value.price_CPU == max)
                        {
                            countFounded++;
                            foundedIndexCpus.Add(i);
                        }
                    }
                    
                }
            }


            if (pubStatus.ElementAt(0).Value.Name == "gameGrid")
            {
                int max = int.MaxValue;
                for (int i = 0; i < cpu.GetCountCPUs(); i++)
                {
                    if (cpu.cpuList.ElementAt(i).Value.price_CPU < max)
                    {
                        max = cpu.cpuList.ElementAt(i).Value.price_CPU;
                        countFounded = 1;
                        indexFounded = i;
                        if (foundedIndexCpus.Count != 0)
                        {
                            foundedIndexCpus.Clear();
                            foundedIndexCpus.Add(0);
                        }
                        foundedIndexCpus[0] = i;
                    }
                    else if (cpu.cpuList.ElementAt(i).Value.price_CPU == max)
                    {
                        countFounded++;
                        foundedIndexCpus.Add(i);
                    }
                }
                if (countFounded > 1 && pubStatus.ElementAt(1).Value.Name == "speedGrid")
                {
                    int newcount = countFounded;
                    int[] newIndex = foundedIndexCpus.ToArray();
                    max = int.MinValue;
                    for (int i = 0; i < newcount; i++)
                    {
                        if (cpu.cpuList.ElementAt(newIndex[i]).Value.frequency_CPU > max)
                        {
                            max = cpu.cpuList.ElementAt(newIndex[i]).Value.frequency_CPU;
                            countFounded = 1;
                            indexFounded = newIndex[i];
                            if (foundedIndexCpus.Count != 0)
                            {
                                foundedIndexCpus.Clear();
                                foundedIndexCpus.Add(0);
                            }
                            foundedIndexCpus[0] = i;
                        }
                        else if (cpu.cpuList.ElementAt(newIndex[i]).Value.countCores_CPU == max)
                        {
                            countFounded++;
                            foundedIndexCpus.Add(i);
                        }
                    }
                }
                else if (countFounded > 1 && pubStatus.ElementAt(1).Value.Name == "multiGrid")
                {
                    int newcount = countFounded;
                    int[] newIndex = foundedIndexCpus.ToArray();
                    max = int.MinValue;
                    for (int i = 0; i < newcount; i++)
                    {

                        if (cpu.cpuList.ElementAt(newIndex[i]).Value.countCores_CPU > max)
                        {
                            max = cpu.cpuList.ElementAt(newIndex[i]).Value.countCores_CPU;
                            countFounded = 1;
                            indexFounded = newIndex[i];
                            if (foundedIndexCpus.Count != 0)
                            {
                                foundedIndexCpus.Clear();
                                foundedIndexCpus.Add(0);
                            }
                            foundedIndexCpus[0] = i;
                        }
                        else if (cpu.cpuList.ElementAt(newIndex[i]).Value.countCores_CPU == max)
                        {
                            countFounded++;
                            foundedIndexCpus.Add(i);
                        }
                    }
                }
            }
        }
    }
}
