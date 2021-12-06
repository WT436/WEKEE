using System;
using System.Collections.Generic;
using System.Text;

namespace System.Domain.Dtos
{
    public class ExceptionDtos
    {
        public int Id { get; set; }
        public string ServerError { get; set; }
        public int? AccountCreate { get; set; }
        public string IpAccount { get; set; }
        public string Level { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorTrace { get; set; }
        public int UpdateCount { get; set; }
        public bool? IsFix { get; set; }
    }
}
