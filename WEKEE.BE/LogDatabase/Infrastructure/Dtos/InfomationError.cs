using System;
using System.Collections.Generic;
using System.Text;

namespace LogDatabase.Infrastructure.Dtos
{
    public class InfomationError
    {
        public Exception Exception { get; set; }
        public string ServerError { get; set; }
        public int? AccountCreate { get; set; }
        public string IpAccount { get; set; }
        public string Level { get; set; }
    }
}
