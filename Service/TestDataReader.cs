using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Framework.Model;
using AngleSharp.Text;

namespace Framework.Service
{
    public class TestDataReader
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public Engine engine { get; set; }


        private string execPath;

        public TestDataReader(string environment)
        {
            execPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            engine = new Engine();
            engine.NumberOfInstances = int.Parse(ExtractValueFromFile(environment, "NumberOfInstances"));
            engine.OperatingSystem = ExtractValueFromFile(environment, "OperatingSystem");
            engine.ProvisioningModel = ExtractValueFromFile(environment, "ProvisioningModel");
            engine.MachineFamily = ExtractValueFromFile(environment, "MachineFamily");
            engine.Series = ExtractValueFromFile(environment, "Series");
            engine.MachineType = ExtractValueFromFile(environment, "MachineType");
            engine.AddGPUs = bool.Parse(ExtractValueFromFile(environment, "AddGPUs"));
            engine.GPUType = ExtractValueFromFile(environment, "GPUType");
            engine.NumberOfGPUs = ExtractValueFromFile(environment, "NumberOfGPUs");
            engine.LocalSSD = ExtractValueFromFile(environment, "LocalSSD");
            engine.DataCenterLocation = ExtractValueFromFile(environment, "DataCenterLocation");
            engine.CommitedUsage = ExtractValueFromFile(environment, "CommitedUsage");
        }

        private string ExtractValueFromFile(string environment, string property)
        {
            string result = String.Empty;
            using (var reader = new StreamReader(Path.Combine(execPath, "Resources", $"{environment}.properties")))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(property))
                    {
                        result = line.Substring(line.IndexOf('=') + 1);
                    }
                }
            }
            return result;
        }
    }
}
