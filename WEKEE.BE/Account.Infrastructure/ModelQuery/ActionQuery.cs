using Account.Domain.Entitys;
using Account.Domain.ObjectValues;
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

        public async Task<IList<Action>> GetAllActive()
                     => await unitOfWork.GetRepository<Action>().GetAllAsync(m => m.IsActive == true);

        #region Hiển thị
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
        public IPagedList<Action> GetDateCreateOrderByAsc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Action>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderBy(m => m.DateCreate));

        public IPagedList<Action> GetDateCreateOrderByDesc(OrderByPageListInput orderByPageListInput)
               => unitOfWork.GetRepository<Action>()
                            .GetPagedList(pageIndex: orderByPageListInput.PageIndex,
                                           pageSize: orderByPageListInput.PageSize,
                                            orderBy: o => o.OrderByDescending(m => m.DateCreate));

        public async Task<IPagedList<Action>> GetDateCreateOrderByAscAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Action>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderBy(m => m.DateCreate));

        public async Task<IPagedList<Action>> GetDateCreateOrderByDescAsync(OrderByPageListInput orderByPageListInput)
                     => await unitOfWork.GetRepository<Action>()
                                        .GetPagedListAsync(pageIndex: orderByPageListInput.PageIndex,
                                                            pageSize: orderByPageListInput.PageSize,
                                                             orderBy: o => o.OrderByDescending(m => m.DateCreate));
        #endregion

        #endregion

        #region tìm kiếm
        public Action GetAllId(int id)
        => unitOfWork.GetRepository<Action>().GetFirstOrDefault(predicate: m => m.Id == id);

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

        #endregion

        #region sắp sếp tìm kiếm
        #endregion

        #region Tạo mới dữ liệu
        public void Insert(Action Action)
        {
            unitOfWork.GetRepository<Action>()
                           .Insert(Action);
            unitOfWork.SaveChanges();
        }
        public async Task InsertAsync(Action Action)
        {
            await unitOfWork.GetRepository<Action>()
                           .InsertAsync(Action);
            unitOfWork.SaveChanges();
        }
        #endregion

        #region Xóa bản ghi
        public bool RemoveUnique(int id)
        {
            unitOfWork.GetRepository<Action>().Delete(id);
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
                    if (unitOfWork.GetRepository<Action>().Exists(m => m.Id == item))
                    {
                        unitOfWork.GetRepository<Action>().Delete(item);
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
            var data = unitOfWork.GetRepository<Action>().GetFirstOrDefault(predicate: m => m.Id == id);
            if (data != null)
            {
                data.IsActive = !data.IsActive;
                unitOfWork.GetRepository<Action>().Update(data);
            }
            return true;
        }
        public int UpdateMultiple(List<int> ids)
        {
            int count = 0;
            foreach (var item in ids)
            {
                var data = unitOfWork.GetRepository<Action>().GetFirstOrDefault(predicate: m => m.Id == item);
                if (data != null)
                {
                    data.IsActive = !data.IsActive;
                    unitOfWork.GetRepository<Action>().Update(data);
                    count++;
                }
            }

            unitOfWork.SaveChanges();
            return count++; ;
        }
        #endregion

        #region Edit
        public bool EditUnique(Action action)
        {
            var data = unitOfWork.GetRepository<Action>().GetFirstOrDefault(predicate: m => m.Id == action.Id);
            if (data != null)
            {
                data.Name = action.Name;
                data.AtomicId = action.AtomicId;
                data.Description = action.Description;
                data.ActionBase = action.ActionBase;
                data.IsActive = action.IsActive;
                data.DateCreate = DateTime.Now;
                unitOfWork.GetRepository<Action>().Update(data);
                unitOfWork.SaveChanges();
            }
            return true;
        }
        public int EditMultiple(List<Action> action)
        {
            int count = 0;
            foreach (var item in action)
            {
                var data = unitOfWork.GetRepository<Action>().GetFirstOrDefault(predicate: m => m.Id == item.Id);
                if (data != null)
                {
                    data.Name = item.Name;
                    data.AtomicId = item.AtomicId;
                    data.Description = item.Description;
                    data.ActionBase = item.ActionBase;
                    data.IsActive = item.IsActive;
                    data.DateCreate = DateTime.Now;
                    unitOfWork.GetRepository<Action>().Update(data);
                    count++;
                }
            }

            unitOfWork.SaveChanges();
            return count++; ;
        }
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

    }
}
