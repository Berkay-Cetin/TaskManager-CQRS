using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Enums;

namespace TaskManager.Infrastructure.Services
{
    public class EnvironmentService
    {
        public string EnvironmentName { get; }
        public CustomEnvironments Environment { get; }
        public string ApiUrl { get; }
        public string UiUrl { get; }

        public EnvironmentService(EnvironmentConfiguration configuration)
        {
            switch (configuration.EnvironmentName)
            {
                case "Production":
                    this.Environment = CustomEnvironments.Production;
                    this.ApiUrl = "";
                    this.UiUrl = "";
                    break;
                case "Staging":
                    this.Environment = CustomEnvironments.Staging;
                    this.ApiUrl = "";
                    this.UiUrl = "";
                    break;
                case "Development":
                    this.Environment = CustomEnvironments.Development;
                    this.ApiUrl = "http://localhost:5257";
                    break;
                case "Test":
                    this.Environment = CustomEnvironments.Test;
                    this.ApiUrl = "no-url";
                    this.UiUrl = "no-url";
                    break;
            }

            this.EnvironmentName = configuration.EnvironmentName;
        }
    }
}
