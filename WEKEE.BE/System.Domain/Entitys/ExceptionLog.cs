using System;
using System.Collections.Generic;

#nullable disable

namespace System.Domain.Entitys
{
    public partial class ExceptionLog
    {
        public int Id { get; set; }
        public string ServerError { get; set; }
        public int? AccountCreate { get; set; }
        public string IpAccount { get; set; }
        public string Level { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorTrace { get; set; }
        public DateTime DateRaised { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdateCount { get; set; }
        public bool? IsFix { get; set; }
    }
}
