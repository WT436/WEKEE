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
    public class ResourceQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                          new UnitOfWork<AuthorizationContext>(new AuthorizationContext());

        #region Hiển thị
        public async Task<IPagedList<Resource>> GetAllListPageAsync(SearchOrderPageInput searchOrderPageInput)
        {
          var a = unitOfWork.GetRepository<Resource>().GetAll();
          return null;
                           
        }
        public IPagedList<Resource> GetAllListPage(PagedListInput pagedListInput)
        {
             var a =  unitOfWork.GetRepository<Resource>()
                            .GetPagedList(pageIndex: pagedListInput.PageIndex,
                                           pageSize: pagedListInput.PageSize);
            return a;
        }
        #endregion

        #region sắp xếp

        #region Sắp Xếp theo tên
        public IPagedList<Resource> GetNameOrderByAsc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Resource>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderBy(m => m.Name));

        public IPagedList<Resource> GetNameOrderByDesc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Resource>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderByDescending(m => m.Name));

        public async Task<IPagedList<Resource>> GetNameOrderByAscAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Resource>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderBy(m => m.Name));

        public async Task<IPagedList<Resource>> GetNameOrderByDescAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Resource>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderByDescending(m => m.Name));
        #endregion

        #region Sắp Xếp theo datetime
        public IPagedList<Resource> GetCreatedAtOrderByAsc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Resource>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderBy(m => m.CreatedAt));

        public IPagedList<Resource> GetCreatedAtOrderByDesc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Resource>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderByDescending(m => m.CreatedAt));

        public async Task<IPagedList<Resource>> GetCreatedAtOrderByAscAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Resource>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderBy(m => m.CreatedAt));

        public async Task<IPagedList<Resource>> GetCreatedAtOrderByDescAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Resource>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderByDescending(m => m.CreatedAt));
        #endregion

        #endregion

        #region tìm kiếm
        public Resource GetAllId(int id)
        => unitOfWork.GetRepository<Resource>().GetFirstOrDefault(predicate: m => m.Id == id);

        public async Task<Resource> GetAllIdAsync(int id)
                     => await unitOfWork.GetRepository<Resource>().GetFirstOrDefaultAsync(predicate: m => m.Id == id);

        public IList<Resource> GetAllActive(bool active)
        => unitOfWork.GetRepository<Resource>().GetAll(m => m.IsActive == active).ToList();

        public async Task<IList<Resource>> GetAllActiveAsync(bool active)
                     => await unitOfWork.GetRepository<Resource>().GetAllAsync(m => m.IsActive == active);

        public IList<Resource> GetAllNameExact(string name)
               => unitOfWork.GetRepository<Resource>().GetAll(m => m.Name == name).ToList();

        public async Task<IList<Resource>> GetAllNameExactAsync(string name)
                     => await unitOfWork.GetRepository<Resource>().GetAllAsync(m => m.Name == name);
        public IList<Resource> GetAllLstById(List<int> ids)
        => unitOfWork.GetRepository<Resource>()
                     .GetAll().Where(m => ids.Contains(m.Id)).ToList();
        #endregion

        #region sắp sếp tìm kiếm
        #endregion

        #region Đếm bản ghi
        public int CountId(int id)
                   => unitOfWork.GetRepository<Resource>().Count(m => m.Id == id);

        public async Task<int> CountIdAsync(int id)
                  => await unitOfWork.GetRepository<Resource>().CountAsync(m => m.Id == id);

        public int CountName(string name)
                   => unitOfWork.GetRepository<Resource>().Count(m => m.Name.ToUpper() == name.ToUpper());

        public async Task<int> CountNameAsync(string name)
                     => await unitOfWork.GetRepository<Resource>().CountAsync(m => m.Name.ToUpper() == name.ToUpper());

        public int CountNameExact(string name)
                  => unitOfWork.GetRepository<Resource>().Count(m => m.Name == name);

        public async Task<int> CountNameExactAsync(string name)
                     => await unitOfWork.GetRepository<Resource>().CountAsync(m => m.Name == name);

        public int CountNameAndTypesExact(string name, string types)
                 => unitOfWork.GetRepository<Resource>().Count(m => m.Name == name && m.TypesRsc == types);

        public async Task<int> CountNameAndTypesExactAsync(string name, string types)
                     => await unitOfWork.GetRepository<Resource>().CountAsync(m => m.Name == name && m.TypesRsc == types);
        #endregion

        #region Tạo mới - Create
        public int Insert(Resource resource)
        {
            unitOfWork.GetRepository<Resource>()
                      .Insert(resource);
            return unitOfWork.SaveChanges();
        }
        public int Insert(List<Resource> resources)
        {
            unitOfWork.GetRepository<Resource>()
                      .Insert(resources);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(Resource resource)
        {
            await unitOfWork.GetRepository<Resource>()
                            .InsertAsync(resource);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(List<Resource> resources)
        {
            await unitOfWork.GetRepository<Resource>()
                            .InsertAsync(resources);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Cập nhật - Update
        public int Update(Resource resource)
        {
            unitOfWork.GetRepository<Resource>()
                      .Update(resource);
            return unitOfWork.SaveChanges();
        }
        public int Update(List<Resource> resources)
        {
            unitOfWork.GetRepository<Resource>()
                      .Update(resources);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> UpdateAsync(Resource resource)
        {
            unitOfWork.GetRepository<Resource>()
                      .Update(resource);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(List<Resource> resources)
        {
            unitOfWork.GetRepository<Resource>()
                      .Update(resources);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Xóa - Delete
        public int Delete(int id)
        {
            unitOfWork.GetRepository<Resource>()
                      .Delete();
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<int> ids)
        {
            unitOfWork.GetRepository<Resource>()
                      .Delete(GetAllLstById(ids));
            return unitOfWork.SaveChanges();
        }
        public int Delete(Resource resource)
        {
            unitOfWork.GetRepository<Resource>()
                      .Delete(resource);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<Resource> resources)
        {
            unitOfWork.GetRepository<Resource>()
                      .Delete(resources);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> DeleteAsync(Resource resource)
        {
            unitOfWork.GetRepository<Resource>()
                      .Delete(resource);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(List<Resource> resources)
        {
            unitOfWork.GetRepository<Resource>()
                      .Delete(resources);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion
    }
}
