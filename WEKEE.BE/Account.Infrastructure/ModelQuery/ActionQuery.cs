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
using Action = Account.Domain.Entitys.Action;

namespace Account.Infrastructure.ModelQuery
{
    public class ActionQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                          new UnitOfWork<AuthorizationContext>(new AuthorizationContext());


        #region Hiển thị
        public async Task<IList<Action>> GetAllActive()
                     => await unitOfWork.GetRepository<Action>()
                                        .GetAllAsync(m => m.IsActive == true);
        public async Task<IPagedList<Action>> GetAllListPageAsync(PagedListInput pagedListInput)
                     => await unitOfWork.GetRepository<Action>()
                                        .GetPagedListAsync(pageIndex: pagedListInput.PageIndex,
                                                           pageSize: pagedListInput.PageSize);
        public IPagedList<Action> GetAllListPage(PagedListInput pagedListInput)
               => unitOfWork.GetRepository<Action>()
                            .GetPagedList(pageIndex: pagedListInput.PageIndex,
                                           pageSize: pagedListInput.PageSize);
        #endregion

        #region sắp xếp

        #region Sắp Xếp theo tên
        public IPagedList<Action> GetNameOrderByAsc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Action>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderBy(m => m.Name));

        public IPagedList<Action> GetNameOrderByDesc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Action>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderByDescending(m => m.Name));

        public async Task<IPagedList<Action>> GetNameOrderByAscAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Action>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderBy(m => m.Name));

        public async Task<IPagedList<Action>> GetNameOrderByDescAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Action>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderByDescending(m => m.Name));
        #endregion

        #region Sắp Xếp theo datetime
        public IPagedList<Action> GetCreatedAtOrderByAsc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Action>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderBy(m => m.CreatedAt));

        public IPagedList<Action> GetCreatedAtOrderByDesc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Action>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderByDescending(m => m.CreatedAt));

        public async Task<IPagedList<Action>> GetCreatedAtOrderByAscAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Action>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderBy(m => m.CreatedAt));

        public async Task<IPagedList<Action>> GetCreatedAtOrderByDescAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Action>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderByDescending(m => m.CreatedAt));
        #endregion

        #endregion

        #region tìm kiếm
        public Action GetById(int? id)
        => unitOfWork.GetRepository<Action>().GetFirstOrDefault(predicate: m => m.Id == (int)id);

        public async Task<Action> GetAllIdAsync(int id)
                     => await unitOfWork.GetRepository<Action>().GetFirstOrDefaultAsync(predicate: m => m.Id == id);

        public IList<Action> GetAllActive(bool active)
        => unitOfWork.GetRepository<Action>().GetAll(m => m.IsActive == active).ToList();

        public async Task<IList<Action>> GetAllActiveAsync(bool active)
                     => await unitOfWork.GetRepository<Action>().GetAllAsync(m => m.IsActive == active);

        public IList<Action> GetAllNameExact(string name)
               => unitOfWork.GetRepository<Action>().GetAll(m => m.Name == name).ToList();

        public async Task<IList<Action>> GetAllNameExactAsync(string name)
                     => await unitOfWork.GetRepository<Action>().GetAllAsync(m => m.Name == name);
        public async Task<IList<Action>> GetDataByListId(List<int> ids)
                     => await unitOfWork.GetRepository<Action>()
                                        .GetAllAsync(m => ids.Contains(m.Id));
        #endregion

        #region sắp sếp tìm kiếm
        #endregion

        #region Đếm bản ghi
        public int CountId(int Id)
                   => unitOfWork.GetRepository<Action>().Count(m => m.Id == Id);
        public async Task<int> CountIdAsync(int Id)
                   => await unitOfWork.GetRepository<Action>().CountAsync(m => m.Id == Id);
        public int CountName(string name)
                   => unitOfWork.GetRepository<Action>().Count(m => m.Name.ToUpper() == name.ToUpper());

        public async Task<int> CountNameAsync(string name)
                     => await unitOfWork.GetRepository<Action>().CountAsync(m => m.Name.ToUpper() == name.ToUpper());

        public int CountNameExact(string name)
                  => unitOfWork.GetRepository<Action>().Count(m => m.Name == name);

        public async Task<int> CountNameExactAsync(string name)
                     => await unitOfWork.GetRepository<Action>().CountAsync(m => m.Name == name);

        public int CountAtomic(int atomic)
                 => unitOfWork.GetRepository<Action>().Count(m => m.AtomicId == atomic);

        public async Task<int> CountAtomicAsync(int atomic)
                     => await unitOfWork.GetRepository<Action>().CountAsync(m => m.AtomicId == atomic);
        #endregion

        #region Tạo mới - Create
        public int Insert(Action action)
        {
            unitOfWork.GetRepository<Action>()
                      .Insert(action);
            return unitOfWork.SaveChanges();
        }
        public int Insert(List<Action> actions)
        {
            unitOfWork.GetRepository<Action>()
                      .Insert(actions);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(Action action)
        {
            await unitOfWork.GetRepository<Action>()
                            .InsertAsync(action);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(List<Action> actions)
        {
            await unitOfWork.GetRepository<Action>()
                            .InsertAsync(actions);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Cập nhật - Update
        public int Update(Action action)
        {
            unitOfWork.GetRepository<Action>()
                      .Update(action);
            return unitOfWork.SaveChanges();
        }
        public int Update(List<Action> actions)
        {
            unitOfWork.GetRepository<Action>()
                      .Update(actions);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> UpdateAsync(Action action)
        {
            unitOfWork.GetRepository<Action>()
                      .Update(action);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(List<Action> actions)
        {
            unitOfWork.GetRepository<Action>()
                      .Update(actions);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Xóa - Delete
        public int Delete(Action action)
        {
            unitOfWork.GetRepository<Action>()
                      .Delete(action);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<Action> actions)
        {
            unitOfWork.GetRepository<Action>()
                      .Delete(actions);
            return unitOfWork.SaveChanges();
        }
        public int Delete(int action)
        {
            unitOfWork.GetRepository<Action>()
                      .Delete(action);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<int> actions)
        {
            unitOfWork.GetRepository<Action>()
                      .Delete(actions);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> DeleteAsync(Action action)
        {
            unitOfWork.GetRepository<Action>()
                      .Delete(action);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(List<Action> actions)
        {
            unitOfWork.GetRepository<Action>()
                      .Delete(actions);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(int action)
        {
            unitOfWork.GetRepository<Action>()
                      .Delete(action);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(List<int> actions)
        {
            unitOfWork.GetRepository<Action>()
                      .Delete(actions);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion

    }
}
