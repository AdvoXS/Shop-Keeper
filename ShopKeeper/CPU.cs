using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopKeeper
{
    class CPU
    {
        public Dictionary<string, CPU> cpuList;
        public Dictionary<string, string> cpuToImageCPU;
        public string type_CPU { get; set; }//тип процессора(домашний,рабочий,игровой,серверный)
        public string socket_CPU { get; set; }
        //public string typeRAM_CPU //тип оперативной памяти подд. процессором
        public int frequency_CPU { get; set; }//частота процессора
        public int countCores_CPU { get; set; }//количество ядер(вместе с виртульными)
        public int price_CPU { get; set; }//стоимость процессора
        public bool integratedVideo_CPU { get; set; } //интегрированное видеоядро (APU?)
        public bool includedCS_CPU { get; set; }//система охлаждения в комплекте
        static public string[] charactersCpu ={ "Количество ядер", "Тактовая частота", "Стоимость","Интегрированное видеоядро",
                "Cистема охлаждения в комплекте" };


        public CPU()
        {
            cpuList = new Dictionary<string, CPU>();
            cpuToImageCPU = new Dictionary<string, string>();
            addCPUs();
        }
        public CPU(string type, string socket, int frequency,int countCores,int price,bool integratedVideo, bool includedCS)
        {
            type_CPU = type;
            socket_CPU = socket;
            frequency_CPU = frequency;
            countCores_CPU = countCores;
            price_CPU = price ;
            integratedVideo_CPU = integratedVideo;
            includedCS_CPU = includedCS;
        }
        public int GetCountCPUs()
        {
            return cpuList.Count;
        }
        private void addCPUs()
        {
            //добавление процессоров в бд
            //1
            cpuList.Add("AMD Sempron 2650 BOX", new CPU("Home", "AM1", 1450, 2, 1599, true, true));
            cpuToImageCPU.Add("AMD Sempron 2650 BOX", "Pictures_CPU/AMD_SEPRON_2650.jpg");
            //2
            cpuList.Add("AMD Athlon 200GE OEM", new CPU("Home", "AM4", 3200, 4, 1599, true, false));
            cpuToImageCPU.Add("AMD Athlon 200GE OEM", "Pictures_CPU/AMD_ATHLON_200GE.jpg");
            //3
            cpuList.Add("Intel Celeron G3930 BOX", new CPU("Home", "LGA 1511", 2900, 2, 3350, true, true));
            cpuToImageCPU.Add("Intel Celeron G3930 BOX", "Pictures_CPU/INTEL_CELERON_G3930.jpg");
            //4
            cpuList.Add("Intel Celeron G4900 OEM", new CPU("Home", "LGA 1511", 3100, 2, 3350, true,false));
            cpuToImageCPU.Add("Intel Celeron G4900 OEM", "Pictures_CPU/INTEL_CELERON_G4900.jpg");
            //5
            cpuList.Add("AMD FX-6300 OEM", new CPU("Game", "AM3+", 3500, 6, 3350, false, false));
            cpuToImageCPU.Add("AMD FX-6300 OEM", "Pictures_CPU/AMD_FX_6300.jpg");
            //6
            cpuList.Add("Intel Pentium Gold G5400 OEM", new CPU("Office", "LGA 1511", 3700, 4, 4550, true, false));
            cpuToImageCPU.Add("Intel Pentium Gold G5400 OEM", "Pictures_CPU/INTEL_PENTIUM_G5400.jpg");
            //7
            cpuList.Add("Intel Celeron G4920 BOX", new CPU("Office", "LGA 1511", 3200, 2, 4850, true, true));
            cpuToImageCPU.Add("Intel Celeron G4920 BOX", "Pictures_CPU/INTEL_CELERON_G4920.jpg");
            //8
            cpuList.Add("AMD FX-8300 BOX", new CPU("Game", "AM3+", 3300, 8, 4750, false, true));
            cpuToImageCPU.Add("AMD FX-8300 BOX", "Pictures_CPU/AMD_FX_8300.jpg");
            //9
            cpuList.Add("AMD Ryzen 3 2300X OEM", new CPU("Game", "AM4",3500,4,6999,false,false));
            cpuToImageCPU.Add("AMD Ryzen 3 2300X OEM", "Pictures_CPU/AMD_RYZEN_2300X.jpg");
            //10
            cpuList.Add("Intel Core i3-8100 OEM", new CPU("Office", "LGA 1511", 3500,4,8799,true,false));
            cpuToImageCPU.Add("Intel Core i3-8100 OEM", "Pictures_CPU/AMD_RYZEN_2300X.jpg");
            //11
            cpuList.Add("Intel Xeon E3-1230 v6 OEM", new CPU("Server", "LGA 1155",3000,4,16499,false,false));
            cpuToImageCPU.Add("Intel Xeon E3-1230 v6 OEM", "Pictures_CPU/INTEL_XEON_E3_1230.jpg");
            //12
            cpuList.Add("Intel Xeon E3-1245 v6 OEM", new CPU("Server", "LGA 1155",3500,8,26299,true,false));
            cpuToImageCPU.Add("Intel Xeon E3-1245 v6 OEM", "Pictures_CPU/INTEL_XEON_E3_1245.jpg");
            //13
            cpuList.Add("AMD Ryzen Threadripper 1900X BOX", new CPU("Server", "sTR4",3800,16,22499,false,true));
            cpuToImageCPU.Add("AMD Ryzen Threadripper 1900X BOX", "Pictures_CPU/AMD_Ryzen_Threadripper_1900X.jpg");
        }
    }
}
