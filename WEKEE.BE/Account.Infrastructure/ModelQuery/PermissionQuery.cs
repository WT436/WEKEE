using Account.Domain.Shared.Entitys;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Input;
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
        public IPagedList<Permission> GetCreatedAtOrderByAsc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Permission>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderBy(m => m.CreatedAt));

        public IPagedList<Permission> GetCreatedAtOrderByDesc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Permission>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderByDescending(m => m.CreatedAt));

        public async Task<IPagedList<Permission>> GetCreatedAtOrderByAscAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Permission>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderBy(m => m.CreatedAt));

        public async Task<IPagedList<Permission>> GetCreatedAtOrderByDescAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Permission>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderByDescending(m => m.CreatedAt));
        #endregion

        #endregion

        #region tìm kiếm
        public Permission GetAllId(int id)
        => unitOfWork.GetRepository<Permission>()
                     .GetFirstOrDefault(predicate: m => m.Id == id);

        public async Task<Permission> GetAllIdAsync(int id)
        => await unitOfWork.GetRepository<Permission>()
                           .GetFirstOrDefaultAsync(predicate: m => m.Id == id);

        public IList<Permission> GetAllActive(bool active)
        => unitOfWork.GetRepository<Permission>()
                     .GetAll(m => m.IsActive == active).ToList();

        public async Task<IList<Permission>> GetAllActiveAsync(bool active)
        => await unitOfWork.GetRepository<Permission>()
                           .GetAllAsync(m => m.IsActive == active);

        public IList<Permission> GetAllNameExact(string name)
        => unitOfWork.GetRepository<Permission>()
                     .GetAll(m => m.Name == name).ToList();

        public async Task<IList<Permission>> GetAllNameExactAsync(string name)
        => await unitOfWork.GetRepository<Permission>()
                           .GetAllAsync(m => m.Name == name);
        public IList<Permission> GetAllLstById(List<int> ids)
         => unitOfWork.GetRepository<Permission>()
                      .GetAll().Where(m => ids.Contains(m.Id)).ToList();


        #endregion

        #region sắp sếp tìm kiếm
        #endregion

        #region Đếm bản ghi

        public int CountId(int id)
        => unitOfWork.GetRepository<Permission>()
                     .Count(m => m.Id == id);

        public async Task<int> CountIdAsync(int id)
        => await unitOfWork.GetRepository<Permission>()
                           .CountAsync(m => m.Id == id);

        public int CountName(string name)
        => unitOfWork.GetRepository<Permission>()
                     .Count(m => m.Name.ToUpper() == name.ToUpper());

        public async Task<int> CountNameAsync(string name)
        => await unitOfWork.GetRepository<Permission>()
                           .CountAsync(m => m.Name.ToUpper() == name.ToUpper());

        public int CountNameExact(string name)
        => unitOfWork.GetRepository<Permission>()
                     .Count(m => m.Name == name);

        public async Task<int> CountNameExactAsync(string name)
        => await unitOfWork.GetRepository<Permission>()
                           .CountAsync(m => m.Name == name);
        #endregion

        #region Tạo mới - Create
        public int Insert(Permission permission)
        {
            unitOfWork.GetRepository<Permission>()
                      .Insert(permission);
            return unitOfWork.SaveChanges();
        }
        public int Insert(List<Permission> permissions)
        {
            unitOfWork.GetRepository<Permission>()
                      .Insert(permissions);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(Permission permission)
        {
            await unitOfWork.GetRepository<Permission>()
                            .InsertAsync(permission);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(List<Permission> permissions)
        {
            await unitOfWork.GetRepository<Permission>()
                            .InsertAsync(permissions);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Cập nhật - Update
        public int Update(Permission permission)
        {
            unitOfWork.GetRepository<Permission>()
                      .Update(permission);
            return unitOfWork.SaveChanges();
        }
        public int Update(List<Permission> permissions)
        {
            unitOfWork.GetRepository<Permission>()
                      .Update(permissions);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> UpdateAsync(Permission permission)
        {
            unitOfWork.GetRepository<Permission>()
                      .Update(permission);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(List<Permission> permissions)
        {
            unitOfWork.GetRepository<Permission>()
                      .Update(permissions);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Xóa - Delete
        public int Delete(int id)
        {
            unitOfWork.GetRepository<Permission>()
                      .Delete(id);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<int> ids)
        {
            unitOfWork.GetRepository<Permission>()
                      .Delete(ids);
            return unitOfWork.SaveChanges();
        }
        public int Delete(Permission permission)
        {
            unitOfWork.GetRepository<Permission>()
                      .Delete(permission);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<Permission> permissions)
        {
            unitOfWork.GetRepository<Permission>()
                      .Delete(permissions);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> DeleteAsync(Permission permission)
        {
            unitOfWork.GetRepository<Permission>()
                      .Delete(permission);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(List<Permission> permissions)
        {
            unitOfWork.GetRepository<Permission>()
                      .Delete(permissions);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion
    }
}
