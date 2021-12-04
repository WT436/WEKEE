using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Dto
{
    public class SubjectDtos
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public int? GorupId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
