﻿using Account.Domain.Entitys;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Enum;
using Account.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            // nếu truy cập theo search
            if (searchOrderPageInput.ValuesSearch != null && searchOrderPageInput.ValuesSearch.Length > 0)
            {   // search tổng
                var join = "";
                var query = @$"";
                if (searchOrderPageInput.PropertySearch.Any(m => m.ToUpper().Equals("ALL")))
                {
                    return await unitOfWork.GetRepository<Resource>()
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
                        join = "JOIN [UserLogin] on [UserLogin].[id] = [Resource].[create_by]";
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
                if (searchOrderPageInput.Property == null || searchOrderPageInput.Property.ToUpper().Equals("ALL"))
                {
                    query += $@"ORDER BY id 
                                         OFFSET {0} 
                                         ROWS FETCH NEXT {20} 
                                         ROWS ONLY  ";
                }
                else
                {
                    query += $@"ORDER BY {searchOrderPageInput.Property} {searchOrderPageInput.OrderBy} 
                                         OFFSET {searchOrderPageInput.PageIndex * searchOrderPageInput.PageSize} 
                                         ROWS FETCH NEXT {searchOrderPageInput.PageSize} 
                                         ROWS ONLY  ";
                }

                query = $@" SELECT DISTINCT [Resource].* 
                                FROM [Resource]
                                {join} 
                                {query}";

                var datae = unitOfWork.GetRepository<Resource>().FromSql(query);
                var totalData = unitOfWork.GetRepository<Resource>().Count();

                return datae.MapToPagedList(pageIndex: searchOrderPageInput.PageIndex,
                                           pageSize: searchOrderPageInput.PageSize,
                                           totalCount: totalData,
                                           indexFrom: 0);
            }
            else
            {
                return await unitOfWork.GetRepository<Resource>()
                               .GetPagedListAsync(pageIndex: searchOrderPageInput.PageIndex,
                                                  pageSize: searchOrderPageInput.PageSize);
            }
        }
        public IPagedList<Resource> GetAllListPage(PagedListInput pagedListInput)
        {
            return unitOfWork.GetRepository<Resource>()
                           .GetPagedList(pageIndex: pagedListInput.PageIndex,
                                          pageSize: pagedListInput.PageSize);
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
