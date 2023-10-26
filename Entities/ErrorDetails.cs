using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// This class represents an error details object with its status code and message
    /// </summary>
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        /// <summary>
        /// This method returns a JSON string representation of the error details object 
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
