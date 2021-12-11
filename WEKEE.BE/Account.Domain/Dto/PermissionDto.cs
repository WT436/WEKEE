﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Dto
{
    public class PermissionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool? IsActive { get; set; }
    }
}
