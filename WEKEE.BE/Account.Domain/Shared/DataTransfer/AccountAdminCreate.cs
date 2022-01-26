using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer
{
    public class AccountAdminCreate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool AcceptTermOfService { get; set; }
        public string TimeZone { get; set; }
        public bool FacebookId { get; set; }
        public bool GoogleId { get; set; }
        public bool ZaloId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string NumberPhone { get; set; }
        public string Password { get; set; }
        public int IsStatus { get; set; }
        public string AdressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string AdressLine3 { get; set; }
        public string DescriptionAdress { get; set; }
        public bool? IsActive { get; set; }
        public string Coordinates { get; set; }
        public string Picture { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
    }
}
