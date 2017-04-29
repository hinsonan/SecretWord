using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretWord.Models
{
    public class SecretWordModel
    {
        public int ID { get; set; }
        public string Word { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Username { get; set; }
    }
}
