using Arfware.ArfBlocks.Core.Abstractions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Infrastructure.Models;

namespace TaskManager.Application.Configurations
{
    public class ProjectConfigurations : IConfigurationClass
    {
        public RelationalDbConfiguration RelationalDbConfiguration {  get; set; }
    }
}
