using System;
using System.Collections.Generic;
using System.Text;

namespace Pockit.Core.DTOs 
{
    public sealed class GetTemporaryCodeDTO 
    {
        public GetTemporaryCodeDTO(string code, string state)
        {
            Code = code;
            State = state;
        }
        
        public string Code { get; }
        
        public string State { get; }
    }
}
