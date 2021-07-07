using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FmApi.Models
{
     public class State
     {
          public int id { get; set; }
          public string stateCode { get; set; }
          public int nationId { get; set; }
          public string stateName { get; set; }
     }
}
