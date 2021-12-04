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
    public class ResourceQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                          new UnitOfWork<AuthorizationContext>(new AuthorizationContext());

        #region Hiển thị
        public async Task<IPagedList<Resource>> GetAllListPageAsync(PagedListInput pagedListInput)
                     => await unitOfWork.GetRepository<Resource>()
                                        .GetPagedListAsync(pageIndex: pagedListInput.PageIndex,
                                                           pageSize: pagedListInput.PageSize);

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
        public IPagedList<Resource> GetDateCreateOrderByAsc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Resource>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderBy(m => m.DateCreate));

        public IPagedList<Resource> GetDateCreateOrderByDesc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Resource>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderByDescending(m => m.DateCreate));

        public async Task<IPagedList<Resource>> GetDateCreateOrderByAscAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Resource>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderBy(m => m.DateCreate));

        public async Task<IPagedList<Resource>> GetDateCreateOrderByDescAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Resource>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderByDescending(m => m.DateCreate));
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

        #endregion

        #region sắp sếp tìm kiếm
        #endregion

        #region Tạo mới dữ liệu
        public void Insert(Resource resource)
        {
            unitOfWork.GetRepository<Resource>()
                           .Insert(resource);
            unitOfWork.SaveChanges();
        }
        public async Task InsertAsync(Resource resource)
        {
            await unitOfWork.GetRepository<Resource>()
                           .InsertAsync(resource);
            unitOfWork.SaveChanges();
        }
        #endregion

        #region Xóa bản ghi
        public bool RemoveUnique(int id)
        {
            unitOfWork.GetRepository<Resource>().Delete(id);
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
                    if (unitOfWork.GetRepository<Resource>().Exists(m => m.Id == item))
                    {
                        unitOfWork.GetRepository<Resource>().Delete(item);
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
            var data = unitOfWork.GetRepository<Resource>().GetFirstOrDefault(predicate: m => m.Id == id);
            if (data != null)
            {
                data.IsActive = !data.IsActive;
                unitOfWork.GetRepository<Resource>().Update(data);
            }
            return true;
        }
        public int UpdateMultiple(List<int> ids)
        {
            int count = 0;
            foreach (var item in ids)
            {
                var data = unitOfWork.GetRepository<Resource>().GetFirstOrDefault(predicate: m => m.Id == item);
                if (data != null)
                {
                    data.IsActive = !data.IsActive;
                    unitOfWork.GetRepository<Resource>().Update(data);
                    count++;
                }
            }

            unitOfWork.SaveChanges();
            return count++; ;
        }
        #endregion

        #region Edit
        public bool EditUnique(Resource resource)
        {
            var data = unitOfWork.GetRepository<Resource>().GetFirstOrDefault(predicate: m => m.Id == resource.Id);
            if (data != null)
            {
                data.Name = resource.Name;
                data.TypesRsc = resource.TypesRsc;
                data.Description = resource.Description;
                data.IsActive = resource.IsActive;
                data.DateCreate = DateTime.Now;
                unitOfWork.GetRepository<Resource>().Update(data);
                unitOfWork.SaveChanges();
            }
            return true;
        }
        public int EditMultiple(List<Resource> resource)
        {
            int count = 0;
            foreach (var item in resource)
            {
                var data = unitOfWork.GetRepository<Resource>().GetFirstOrDefault(predicate: m => m.Id == item.Id);
                if (data != null)
                {
                    data.Name = item.Name;
                    data.TypesRsc = item.TypesRsc;
                    data.Description = item.Description;
                    data.IsActive = item.IsActive;
                    data.DateCreate = DateTime.Now;
                    unitOfWork.GetRepository<Resource>().Update(data);
                    count++;
                }
            }

            unitOfWork.SaveChanges();
            return count++; ;
        }
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
    }
}
