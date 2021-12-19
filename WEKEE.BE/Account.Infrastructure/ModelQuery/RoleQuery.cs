using Account.Domain.Entitys;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Enum;
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
        public IPagedList<Role> GetCreatedAtOrderByAsc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Role>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderBy(m => m.CreatedAt));

        public IPagedList<Role> GetCreatedAtOrderByDesc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Role>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderByDescending(m => m.CreatedAt));

        public async Task<IPagedList<Role>> GetCreatedAtOrderByAscAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Role>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderBy(m => m.CreatedAt));

        public async Task<IPagedList<Role>> GetCreatedAtOrderByDescAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Role>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderByDescending(m => m.CreatedAt));
        #endregion

        #endregion

        #region tìm kiếm
        public Role GetById(int id)
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
        public IList<Role> GetAllLstById(List<int> ids)
        => unitOfWork.GetRepository<Role>()
                     .GetAll().Where(m => ids.Contains(m.Id)).ToList();
        #endregion

        #region sắp sếp tìm kiếm
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

        #region Tạo mới - Create
        public int Insert(Role role)
        {
            unitOfWork.GetRepository<Role>()
                      .Insert(role);
            return unitOfWork.SaveChanges();
        }
        public int Insert(List<Role> roles)
        {
            unitOfWork.GetRepository<Role>()
                      .Insert(roles);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(Role role)
        {
            await unitOfWork.GetRepository<Role>()
                            .InsertAsync(role);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(List<Role> roles)
        {
            await unitOfWork.GetRepository<Role>()
                            .InsertAsync(roles);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Cập nhật - Update
        public int Update(Role role)
        {
            unitOfWork.GetRepository<Role>()
                      .Update(role);
            return unitOfWork.SaveChanges();
        }
        public int Update(List<Role> roles)
        {
            unitOfWork.GetRepository<Role>()
                      .Update(roles);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> UpdateAsync(Role role)
        {
            unitOfWork.GetRepository<Role>()
                      .Update(role);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(List<Role> roles)
        {
            unitOfWork.GetRepository<Role>()
                      .Update(roles);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Xóa - Delete
        public int Delete(int id)
        {
            unitOfWork.GetRepository<Role>()
                      .Delete(id);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<int> ids)
        {
            unitOfWork.GetRepository<Role>()
                      .Delete(ids);
            return unitOfWork.SaveChanges();
        }
        public int Delete(Role role)
        {
            unitOfWork.GetRepository<Role>()
                      .Delete(role);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<Role> roles)
        {
            unitOfWork.GetRepository<Role>()
                      .Delete(roles);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> DeleteAsync(Role role)
        {
            unitOfWork.GetRepository<Role>()
                      .Delete(role);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(List<Role> roles)
        {
            unitOfWork.GetRepository<Role>()
                      .Delete(roles);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion
    }
}