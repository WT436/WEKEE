using Account.Domain.Shared.Entitys;
using Account.Domain.ObjectValues.Input;
using Account.Infrastructure.DBContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;
using UnitOfWork.Collections;

namespace Account.Infrastructure.ModelQuery
{
    public class AtomicQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                         new UnitOfWork<AuthorizationContext>(new AuthorizationContext());

        #region Hiển thị
        public async Task<IPagedList<Atomic>> GetAllListPageAsync(SearchOrderPageInput searchOrderPageInput)
        {
            // nếu truy cập theo search
            if (searchOrderPageInput.ValuesSearch != null && searchOrderPageInput.ValuesSearch.Length > 0)
            {   // search tổng
                var join = "";
                var query = @$"";
                if (searchOrderPageInput.PropertySearch.Any(m => m.ToUpper().Equals("ALL")))
                {
                    return await unitOfWork.GetRepository<Atomic>()
                              .GetPagedListAsync(pageIndex: searchOrderPageInput.PageIndex,
                                                 pageSize: searchOrderPageInput.PageSize);
                }
                else
                {
                    query += $@" WHERE ";

                    if (searchOrderPageInput.PropertySearch.Any(m => m.ToUpper().Trim() == ("ID".ToUpper())))
                    {
                        foreach (var data in searchOrderPageInput.ValuesSearch)
                        {
                            query += $@" 
                                      CAST([id] AS VARCHAR(MAX)) LIKE '%{data}%'		       OR
                                   ";
                        }
                    }
                    if (searchOrderPageInput.PropertySearch.Any(m => m.ToUpper().Trim() == ("NAME".ToUpper())))
                    {
                        foreach (var data in searchOrderPageInput.ValuesSearch)
                        {
                            query += $@" 
                                      CAST([name] AS VARCHAR(MAX)) LIKE '%{data}%'		       OR
                                   ";
                        }
                    }
                    if (searchOrderPageInput.PropertySearch.Any(m => m.ToUpper().Trim() == ("TypesRsc".ToUpper())))
                    {
                        foreach (var data in searchOrderPageInput.ValuesSearch)
                        {
                            query += $@" 
                                      CAST([types_rsc] AS VARCHAR(MAX)) LIKE '%{data}%'		       OR
                                   ";
                        }
                    }
                    if (searchOrderPageInput.PropertySearch.Any(m => m.ToUpper().Trim() == ("Description".ToUpper())))
                    {
                        foreach (var data in searchOrderPageInput.ValuesSearch)
                        {
                            query += $@" 
                                      CAST([description] AS VARCHAR(MAX)) LIKE '%{data}%'		       OR
                                   ";
                        }
                    }
                    if (searchOrderPageInput.PropertySearch.Any(m => m.ToUpper().Trim() == ("IsActive".ToUpper())))
                    {
                        foreach (var data in searchOrderPageInput.ValuesSearch)
                        {
                            query += $@" 
                                      CAST([is_active] AS VARCHAR(MAX)) LIKE '%{data}%'		       OR
                                   ";
                        }
                    }
                    if (searchOrderPageInput.PropertySearch.Any(m => m.ToUpper().Trim() == ("CreatedAt".ToUpper())))
                    {
                        foreach (var data in searchOrderPageInput.ValuesSearch)
                        {
                            query += $@" 
                                      CAST([created_at] AS VARCHAR(MAX)) LIKE '%{data}%'		       OR
                                   ";
                        }
                    }
                    if (searchOrderPageInput.PropertySearch.Any(m => m.ToUpper().Trim() == ("UpdatedAt".ToUpper())))
                    {
                        foreach (var data in searchOrderPageInput.ValuesSearch)
                        {
                            query += $@" 
                                      CAST([updated_at] AS VARCHAR(MAX)) LIKE '%{data}%'		       OR
                                   ";
                        }
                    }
                    if (searchOrderPageInput.PropertySearch.Any(m => m.ToUpper().Trim() == ("CreateBy".ToUpper())))
                    {
                        join = "JOIN [UserLogin] on [UserLogin].[id] = [Atomic].[create_by]";
                        foreach (var data in searchOrderPageInput.ValuesSearch)
                        {
                            query += $@" 
                                      CAST([UserLogin].[user_name] AS VARCHAR(MAX)) LIKE '%{data}%'		       OR
                                   ";
                        }
                    }
                    // cắt OR cuối câu lệnh
                    query = query.Substring(0, query.LastIndexOf("OR"));
                }

                // order by và phân trang
                if (searchOrderPageInput.PropertyOrder == null || searchOrderPageInput.PropertyOrder.ToUpper().Equals("ALL"))
                {
                    query += $@"ORDER BY id 
                                         OFFSET {0} 
                                         ROWS FETCH NEXT {20} 
                                         ROWS ONLY  ";
                }
                else
                {
                    query += $@"ORDER BY {searchOrderPageInput.PropertyOrder} {searchOrderPageInput.ValueOrderBy} 
                                         OFFSET {searchOrderPageInput.PageIndex * searchOrderPageInput.PageSize} 
                                         ROWS FETCH NEXT {searchOrderPageInput.PageSize} 
                                         ROWS ONLY  ";
                }

                query = $@" SELECT DISTINCT [Atomic].* 
                                FROM [Atomic]
                                {join} 
                                {query}";

                var datae = unitOfWork.GetRepository<Atomic>().FromSql(query);
                var totalData = unitOfWork.GetRepository<Atomic>().Count();

                return datae.MapToPagedList(pageIndex: searchOrderPageInput.PageIndex,
                                           pageSize: searchOrderPageInput.PageSize,
                                           totalCount: totalData,
                                           indexFrom: 0);
            }
            else
            {
                return await unitOfWork.GetRepository<Atomic>()
                               .GetPagedListAsync(pageIndex: searchOrderPageInput.PageIndex,
                                                  pageSize: searchOrderPageInput.PageSize);
            }
        }

        public IPagedList<Atomic> GetAllListPage(PagedListInput pagedListInput)
        {
            return unitOfWork.GetRepository<Atomic>()
                           .GetPagedList(pageIndex: pagedListInput.PageIndex,
                                          pageSize: pagedListInput.PageSize);
        }
        #endregion

        #region tìm kiếm
        public IList<Atomic> GetAllLstById(List<int> ids)
        => unitOfWork.GetRepository<Atomic>()
                     .GetAll().Where(m => ids.Contains(m.Id)).ToList();
        public Atomic GetById(int id)
        => unitOfWork.GetRepository<Atomic>()
                     .GetFirstOrDefault(predicate: m => m.Id == id);
        public async Task<IList<Atomic>> GetAll()
        => await unitOfWork.GetRepository<Atomic>()
                           .GetAllAsync();
        #endregion

        #region Đếm bản ghi
        public int CountId(int id)
                   => unitOfWork.GetRepository<Atomic>().Count(m => m.Id == id);

        public int CountNameAndTypesExact(string name, string types)
                 => unitOfWork.GetRepository<Atomic>().Count(m => m.Name == name && m.TypesRsc == types);
        #endregion

        #region Tạo mới - Create
        public int Insert(Atomic atomic)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Insert(atomic);
            return unitOfWork.SaveChanges();
        }
        public int Insert(List<Atomic> atomics)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Insert(atomics);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(Atomic atomic)
        {
            await unitOfWork.GetRepository<Atomic>()
                            .InsertAsync(atomic);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(List<Atomic> atomics)
        {
            await unitOfWork.GetRepository<Atomic>()
                            .InsertAsync(atomics);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Cập nhật - Update
        public int Update(Atomic atomic)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Update(atomic);
            return unitOfWork.SaveChanges();
        }
        public int Update(List<Atomic> atomics)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Update(atomics);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> UpdateAsync(Atomic atomic)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Update(atomic);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(List<Atomic> atomics)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Update(atomics);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Xóa - Delete
        public int Delete(int id)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Delete();
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<int> ids)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Delete(GetAllLstById(ids));
            return unitOfWork.SaveChanges();
        }
        public int Delete(Atomic atomic)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Delete(atomic);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<Atomic> atomics)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Delete(atomics);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> DeleteAsync(Atomic atomic)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Delete(atomic);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(List<Atomic> atomics)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Delete(atomics);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion
    }
}