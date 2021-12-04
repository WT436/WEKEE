using Account.Domain.Dto;
using Account.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Account.Domain.BoundedContext
{
    public class UrlProcess
    {
        public bool CheckUrl(string path, List<RoleAuthDtos> roleAnonimuosDtos)
        {
            if(path.Contains("/")&& path.Length==1)
            {
                return true;
            }
            // cần check url không hợp lệ  < tìm /api trong url , để xác nhận cần lấy >        
            string subUrl = path[(path.IndexOf("/api".ToLower()) + 5)..];
            // cat lay kieu yeu cau
            return (roleAnonimuosDtos.Any(m => m.NameAtomic.ToLower()
                                                          .Equals(subUrl[..subUrl.IndexOf("/".ToLower())]))
               && roleAnonimuosDtos.Any(m => m.NameResource.ToLower()
                                                          .Equals(subUrl[subUrl.IndexOf("/".ToLower())..])));
        }
    }
}
