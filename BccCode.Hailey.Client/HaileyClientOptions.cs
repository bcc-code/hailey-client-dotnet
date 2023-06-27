using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BccCode.Hailey.Client
{
    public class HaileyClientOptions
    {

        public string ApiKey { get; set; }

        public string ApiBasePath { get; set; } = "https://hhr-employee-view-openapi-demo.azurewebsites.net";
    }
}
