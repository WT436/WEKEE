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
    public class RoleQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                          new UnitOfWork<AuthorizationContext>(new AuthorizationContext());

        public async Task<IList<Role>> GetAllActive()
                     => await unitOfWork.GetRepository<Role>().GetAllAsync(m => m.IsActive == true);


        #region Hiển thị
        public async Task<IPagedList<Role>> GetAllListPageAsync(PagedListInput pagedListInput)
                     => await unitOfWork.GetRepository<Role>()
                                        .GetPagedListAsync(pageIndex: pagedListInput.PageIndex,
                                                           pageSize: pagedListInput.PageSize);

        public IPagedList<Role> GetAllListPage(PagedListInput pagedListInput)
               => unitOfWork.GetRepository<Role>()
                            .GetPagedList(pageIndex: pagedListInput.PageIndex,
                                           pageSize: pagedListInput.PageSize);
        #endregion

        #region sắp xếp

        #region Sắp Xếp theo tên
        public IPagedList<Role> GetNameOrderByAsc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Role>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderBy(m => m.Name));

        public IPagedList<Role> GetNameOrderByDesc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Role>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderByDescending(m => m.Name));

        public async Task<IPagedList<Role>> GetNameOrderByAscAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Role>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderBy(m => m.Name));

        public async Task<IPagedList<Role>> GetNameOrderByDescAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Role>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderByDescending(m => m.Name));
        #endregion

        #region Sắp Xếp theo datetime
        public IPagedList<Role> GetDateCreateOrderByAsc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Role>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderBy(m => m.DateCreate));

        public IPagedList<Role> GetDateCreateOrderByDesc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Role>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderByDescending(m => m.DateCreate));

        public async Task<IPagedList<Role>> GetDateCreateOrderByAscAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Role>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderBy(m => m.DateCreate));

        public async Task<IPagedList<Role>> GetDateCreateOrderByDescAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Role>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderByDescending(m => m.DateCreate));
        #endregion

        #endregion

        #region tìm kiếm
        public Role GetAllId(int id)
        => unitOfWork.GetRepository<Role>().GetFirstOrDefault(predicate: m => m.Id == id);

        public async Task<Role> GetAllIdAsync(int id)
                     => await unitOfWork.GetRepository<Role>()
                                        .GetFirstOrDefaultAsync(predicate: m => m.Id == id);

        public IList<Role> GetAllActive(bool active)
               => unitOfWork.GetRepository<Role>()
                            .GetAll(m => m.IsActive == active)
                            .ToList();

        public async Task<IList<Role>> GetAllActiveAsync(bool active)
                     => await unitOfWork.GetRepository<Role>().GetAllAsync(m => m.IsActive == active);

        public IList<Role> GetAllNameExact(string name)
               => unitOfWork.GetRepository<Role>()
                            .GetAll(m => m.Name == name)
                            .ToList();

        public async Task<IList<Role>> GetAllNameExactAsync(string name)
                     => await unitOfWork.GetRepository<Role>()
                                        .GetAllAsync(m => m.Name == name);

        #endregion

        #region sắp sếp tìm kiếm
        #endregion

        #region Tạo mới dữ liệu
        public void Insert(Role Role)
        {
            unitOfWork.GetRepository<Role>()
                      .Insert(Role);
            unitOfWork.SaveChanges();
        }
        public async Task InsertAsync(Role Role)
        {
            await unitOfWork.GetRepository<Role>()
                            .InsertAsync(Role);
            unitOfWork.SaveChanges();
        }
        #endregion

        #region Xóa bản ghi
        public bool RemoveUnique(int id)
        {
            unitOfWork.GetRepository<Role>().Delete(id);
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
                    if (unitOfWork.GetRepository<Role>().Exists(m => m.Id == item))
                    {
                        unitOfWork.GetRepository<Role>()
                                  .Delete(item);
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
            var data = unitOfWork.GetRepository<Role>().GetFirstOrDefault(predicate: m => m.Id == id);
            if (data != null)
            {
                data.IsActive = !data.IsActive;
                unitOfWork.GetRepository<Role>()
                          .Update(data);
            }
            return true;
        }
        public int UpdateMultiple(List<int> ids)
        {
            int count = 0;
            foreach (var item in ids)
            {
                var data = unitOfWork.GetRepository<Role>()
                                     .GetFirstOrDefault(predicate: m => m.Id == item);
                if (data != null)
                {
                    data.IsActive = !data.IsActive;
                    unitOfWork.GetRepository<Role>()
                              .Update(data);
                    count++;
                }
            }

            unitOfWork.SaveChanges();
            return count++; ;
        }
        #endregion

        #region Edit
        public bool EditUnique(Role role)
        {
            var data = unitOfWork.GetRepository<Role>()
                                 .GetFirstOrDefault(predicate: m => m.Id == role.Id);
            if (data != null)
            {
                data.Name = role.Name;
                data.LevelRole = role.LevelRole;
                data.RoleId = role.RoleId;
                data.Description = role.Description;
                data.IsDelete = role.IsDelete;
                data.IsActive = role.IsActive;
                data.DateCreate = DateTime.Now;
                unitOfWork.GetRepository<Role>()
                          .Update(data);
                unitOfWork.SaveChanges();
            }
            return true;
        }
        public int EditMultiple(List<Role> role)
        {
            int count = 0;
            foreach (var item in role)
            {
                var data = unitOfWork.GetRepository<Role>()
                                     .GetFirstOrDefault(predicate: m => m.Id == item.Id);
                if (data != null)
                {
                    data.Name = item.Name;
                    data.LevelRole = item.LevelRole;
                    data.RoleId = item.RoleId;
                    data.Description = item.Description;
                    data.IsDelete = item.IsDelete;
                    data.IsActive = item.IsActive;
                    data.DateCreate = DateTime.Now;
                    unitOfWork.GetRepository<Role>()
                              .Update(data);
                    count++;
                }
            }

            unitOfWork.SaveChanges();
            return count++; ;
        }
        #endregion

        #region Đếm bản ghi
        public int CountId(int id)
                  => unitOfWork.GetRepository<Role>()
                               .Count(m => m.Id == id);
        public async Task<int> CountIdAsync(int id)
                  => await unitOfWork.GetRepository<Role>()
                               .CountAsync(m => m.Id == id);
        public int CountName(string name)
                   => unitOfWork.GetRepository<Role>()
                                .Count(m => m.Name.ToUpper() == name.ToUpper());

        public async Task<int> CountNameAsync(string name)
                     => await unitOfWork.GetRepository<Role>()
                                        .CountAsync(m => m.Name.ToUpper() == name.ToUpper());

        public int CountNameExact(string name)
                  => unitOfWork.GetRepository<Role>()
                               .Count(m => m.Name == name);

        public async Task<int> CountNameExactAsync(string name)
                     => await unitOfWork.GetRepository<Role>()
                                        .CountAsync(m => m.Name == name);

        #endregion

    }
}