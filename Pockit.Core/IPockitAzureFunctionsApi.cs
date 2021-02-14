using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Pockit.Core.DTOs;
using Refit;

namespace Pockit.Core 
{
    public interface IPockitAzureFunctionsApi
    {
        [Get("/GetPockitClientId")]
        Task<string> GetPockitClientIdAsync();
    }
}
