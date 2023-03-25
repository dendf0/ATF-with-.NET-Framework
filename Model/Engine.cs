using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Model
{
    public class Engine
    {
        public int NumberOfInstances { get; set; }
        public string OperatingSystem { get; set; }
        public string ProvisioningModel { get; set; }
        public string MachineFamily { get; set; }
        public string Series { get; set; }
        public string MachineType { get; set; }
        public bool AddGPUs { get; set; }
        public string GPUType { get; set; }
        public string NumberOfGPUs { get; set; }
        public string LocalSSD { get; set; }
        public string DataCenterLocation { get; set; }
        public string CommitedUsage { get; set; }
    }
}