using Account.Domain.Entitys;
using Account.Domain.ObjectValues;
using Account.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;
using UnitOfWork.Collections;

namespace Account.Infrastructure.ModelQuery
{
    public class PermissionQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                          new UnitOfWork<AuthorizationContext>(new AuthorizationContext());

        public async Task<IList<Permission>> GetAllActive()
                     => await unitOfWork.GetRepository<Permission>().GetAllAsync(m => m.IsActive == true);

        #region Hiển thị
        public async Task<IPagedList<Permission>> GetAllListPageAsync(PagedListInput pagedListInput)
                     => await unitOfWork.GetRepository<Permission>()
                                        .GetPagedListAsync(pageIndex: pagedListInput.PageIndex,
                                                           pageSize: pagedListInput.PageSize);

        public IPagedList<Permission> GetAllListPage(PagedListInput pagedListInput)
               => unitOfWork.GetRepository<Permission>()
                            .GetPagedList(pageIndex: pagedListInput.PageIndex,
                                           pageSize: pagedListInput.PageSize);
        #endregion

        #region sắp xếp

        #region Sắp Xếp theo tên
        public IPagedList<Permission> GetNameOrderByAsc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Permission>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderBy(m => m.Name));

        public IPagedList<Permission> GetNameOrderByDesc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Permission>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderByDescending(m => m.Name));

        public async Task<IPagedList<Permission>> GetNameOrderByAscAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Permission>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderBy(m => m.Name));

        public async Task<IPagedList<Permission>> GetNameOrderByDescAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Permission>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderByDescending(m => m.Name));
        #endregion

        #region Sắp Xếp theo datetime
        public IPagedList<Permission> GetDateCreateOrderByAsc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Permission>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderBy(m => m.DateCreate));

        public IPagedList<Permission> GetDateCreateOrderByDesc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Permission>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderByDescending(m => m.DateCreate));

        public async Task<IPagedList<Permission>> GetDateCreateOrderByAscAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Permission>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderBy(m => m.DateCreate));

        public async Task<IPagedList<Permission>> GetDateCreateOrderByDescAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Permission>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderByDescending(m => m.DateCreate));
        #endregion

        #endregion

        #region tìm kiếm
        public Permission GetAllId(int id)
        => unitOfWork.GetRepository<Permission>().GetFirstOrDefault(predicate: m => m.Id == id);

        public async Task<Permission> GetAllIdAsync(int id)
                     => await unitOfWork.GetRepository<Permission>().GetFirstOrDefaultAsync(predicate: m => m.Id == id);

        public IList<Permission> GetAllActive(bool active)
        => unitOfWork.GetRepository<Permission>().GetAll(m => m.IsActive == active).ToList();

        public async Task<IList<Permission>> GetAllActiveAsync(bool active)
                     => await unitOfWork.GetRepository<Permission>().GetAllAsync(m => m.IsActive == active);

        public IList<Permission> GetAllNameExact(string name)
               => unitOfWork.GetRepository<Permission>().GetAll(m => m.Name == name).ToList();

        public async Task<IList<Permission>> GetAllNameExactAsync(string name)
                     => await unitOfWork.GetRepository<Permission>().GetAllAsync(m => m.Name == name);

        #endregion

        #region sắp sếp tìm kiếm
        #endregion

        #region Tạo mới dữ liệu
        public void Insert(Permission Permission)
        {
            unitOfWork.GetRepository<Permission>()
                           .Insert(Permission);
            unitOfWork.SaveChanges();
        }
        public async Task InsertAsync(Permission Permission)
        {
            await unitOfWork.GetRepository<Permission>()
                           .InsertAsync(Permission);
            unitOfWork.SaveChanges();
        }
        #endregion

        #region Xóa bản ghi
        public bool RemoveUnique(int id)
        {
            unitOfWork.GetRepository<Permission>().Delete(id);
            unitOfWork.SaveChanges();
            return true;
        }
        public int RemoveMultiple(List<int> ids)
        {
            int count = 0;
            if (ids != null || ids.Count != 0)
            {
                foreach (var item in ids)
                {
                    if (unitOfWork.GetRepository<Permission>().Exists(m => m.Id == item))
                    {
                        unitOfWork.GetRepository<Permission>().Delete(item);
                        count++;
                    }
                }
            }
            unitOfWork.SaveChanges();
            return count++; ;
        }
        #endregion

        #region Update
        public bool UpdateUnique(int id)
        {
            var data = unitOfWork.GetRepository<Permission>().GetFirstOrDefault(predicate: m => m.Id == id);
            if (data != null)
            {
                data.IsActive = !data.IsActive;
                unitOfWork.GetRepository<Permission>().Update(data);
            }
            return true;
        }
        public int UpdateMultiple(List<int> ids)
        {
            int count = 0;
            foreach (var item in ids)
            {
                var data = unitOfWork.GetRepository<Permission>().GetFirstOrDefault(predicate: m => m.Id == item);
                if (data != null)
                {
                    data.IsActive = !data.IsActive;
                    unitOfWork.GetRepository<Permission>().Update(data);
                    count++;
                }
            }

            unitOfWork.SaveChanges();
            return count++; ;
        }
        #endregion

        #region Edit
        public bool EditUnique(Permission Permission)
        {
            var data = unitOfWork.GetRepository<Permission>().GetFirstOrDefault(predicate: m => m.Id == Permission.Id);
            if (data != null)
            {
                data.Name = Permission.Name;
                data.Description = Permission.Description;
                data.IsActive = Permission.IsActive;
                data.DateCreate = DateTime.Now;
                unitOfWork.GetRepository<Permission>().Update(data);
                unitOfWork.SaveChanges();
            }
            return true;
        }
        public int EditMultiple(List<Permission> permission)
        {
            int count = 0;
            foreach (var item in permission)
            {
                var data = unitOfWork.GetRepository<Permission>().GetFirstOrDefault(predicate: m => m.Id == item.Id);
                if (data != null)
                {
                    data.Name = item.Name;
                    data.Description = item.Description;
                    data.IsActive = item.IsActive;
                    data.DateCreate = DateTime.Now;
                    unitOfWork.GetRepository<Permission>().Update(data);
                    count++;
                }
            }

            unitOfWork.SaveChanges();
            return count++; ;
        }
        #endregion

        #region Đếm bản ghi

        public int CountId(int id)
                  => unitOfWork.GetRepository<Permission>().Count(m => m.Id ==id);

        public async Task<int> CountIdAsync(int id)
                  => await unitOfWork.GetRepository<Permission>().CountAsync(m => m.Id == id);

        public int CountName(string name)
                   => unitOfWork.GetRepository<Permission>().Count(m => m.Name.ToUpper() == name.ToUpper());

        public async Task<int> CountNameAsync(string name)
                     => await unitOfWork.GetRepository<Permission>().CountAsync(m => m.Name.ToUpper() == name.ToUpper());

        public int CountNameExact(string name)
                  => unitOfWork.GetRepository<Permission>().Count(m => m.Name == name);

        public async Task<int> CountNameExactAsync(string name)
                     => await unitOfWork.GetRepository<Permission>().CountAsync(m => m.Name == name);
        #endregion

    }
}
