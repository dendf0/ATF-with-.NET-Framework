using Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Service
{
    public class EngineCreator
    {
        public static int NumberOfInstances = 4;
        public static string OperatingSystem = "Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)";
        public static string ProvisioningModel = "Regular";
        public static string MachineFamily = "General purpose";
        public static string Series = "N1";
        public static string MachineType = "n1-standard-8 (vCPUs: 8, RAM: 30GB)";
        public static bool AddGPUs = true;
        public static string GPUType = "NVIDIA Tesla P100";
        public static string NumberOfGPUs = "1";
        public static string LocalSSD = "2x375 GB";
        public static string DataCenterLocation = "Frankfurt (europe-west3)";
        public static string CommitedUsage = "1 Year";

        public static Engine CreateDefaultEngine()
        {
            return new Engine
            {
                NumberOfInstances = NumberOfInstances,
                OperatingSystem = OperatingSystem,
                ProvisioningModel = ProvisioningModel,
                MachineFamily = MachineFamily,
                Series = Series,
                MachineType = MachineType,
                AddGPUs = AddGPUs,
                GPUType = GPUType,
                NumberOfGPUs = NumberOfGPUs,
                LocalSSD = LocalSSD,
                DataCenterLocation = DataCenterLocation,
                CommitedUsage = CommitedUsage
            };
        }
    }
}