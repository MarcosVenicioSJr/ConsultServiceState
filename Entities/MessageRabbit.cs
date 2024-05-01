using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultServiceState.Entities
{
    public class MessageRabbit
    {
        public string Queue { get; set; }
        public string Message { get; set; }
    }
}
