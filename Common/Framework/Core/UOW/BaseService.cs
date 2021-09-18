using AutoMapper;
using Framework.Core.Model;
using Framework.Core.Repo;
using Framework.Core.UOW;
using Framework.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Framework.Core.BaseModel
{
    public abstract class BaseService<T, TVM> : IBaseService<T, TVM> where T : class where TVM : IVM
    {
        protected readonly IRepository<T> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        
        public BaseService(IRepository<T> repository, IUnitOfWork unitOfWork,
             IMapper mapper = null)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public virtual IVM GetById(int id)
        {
            return MapEntityToModel(_repository.GetById(id));
        }

        public T GetEntityById(int id)
        {
            return _repository.GetById(id);
        }
        public virtual IList<TVM> GetPagedResult()
        {
            var pi = typeof(T).GetProperty("id");
            return _mapper.Map<IList<TVM>>( _repository.Table.ToList());
        }

        public IVM GetSingle(Expression<Func<T, bool>> expression)
        {
            return MapEntityToModel(_repository.Single(expression));
        }

        public T GetEntity(Expression<Func<T, bool>> expression)
        {
            return _repository.Single(expression);
        }
        public virtual T Insert(TVM model)
        {
            ValidateInsert(model);
            T entity = MapModelToEntity(model);
            if (entity == null || _unitOfWork.SaveResult.Errors.Count > 0)
                return null;

            _repository.Insert(entity);
            return entity;
        }

        public virtual TVM InsertV2(TVM model)
        {
            ValidateInsert(model);
            T entity = MapModelToEntity(model);
            if (entity == null || _unitOfWork.SaveResult.Errors.Count > 0)
                return null;

            _repository.Insert(entity);
            return _mapper.Map<TVM>( entity);
        }

        public virtual void InsertAll(IList<TVM> model)
        {
            foreach (var item in model)
            {
                ValidateInsert(item);
                T entity = MapModelToEntity(item);
                if (entity == null || _unitOfWork.SaveResult.Errors.Count > 0)
                    return;
                _repository.Insert(entity);
            }
        }

        public virtual void Update(TVM model)
        {
            ValidateUpdate(model);
            T entity = MapModelToEntity(model);
            if (entity == null || _unitOfWork.SaveResult.Errors.Count > 0)
                return;
            _repository.Update(entity);
        }
        public virtual void Delete(TVM model)
        {
            //T entity = ValidateDelete(model);
            //if (_unitOfWork.SaveResult.Errors.Count > 0 || entity == null)
            //    return;

            //_repository.Delete(entity);

            var entity = ValidateDelete(model);

            if (_unitOfWork.SaveResult.Errors.Count > 0 || entity == null)
                return;
            //entity.IsDeleted = true;
            _repository.Update(entity);
        }
        public virtual T MapModelToEntity(TVM model) {
           if(model.Id == 0)
               return  _mapper.Map<T>(model);
            var entity = _repository.GetById(model.Id);
            return _mapper.Map(model, entity);
        }
        public virtual TVM MapEntityToModel(T entity)
        {
            return _mapper.Map<TVM>(entity);
        }
        protected virtual Func<T, IVM> FuncToVM()
        {
            return (a)=> MapEntityToModel(a);
        }

        public virtual IList<SelectListItem> GetRequiredCreateModel()
        {
            return null;
        }
        public virtual RequiredUpdateVM<TVM> GetRequiredUpdateModel(int id)
        {
            return null;
        }

        protected virtual T ValidateDelete(TVM model)
        {
            var match = _repository.GetById(model.Id);
            if (match == null)
                AddError(CommonErrors.NOT_FOUND);
            return match;
        }
        protected virtual void ValidateInsert(TVM model)
        {
            //var exist = _repository.Single(s => s.Id == model.Id); 
            //if (exist != null)
            //    AddError(CommonErrors.ALREADY_EXIST);
        }
        protected virtual void ValidateUpdate(TVM model)
        {
            var match = _repository.GetById(model.Id);
            if (match == null)
                AddError(CommonErrors.NOT_FOUND);
        }
        protected void AddError(int code, string error)
        {
            _unitOfWork.AddError(code, error);
        }
        protected void AddError(Error error)
        {
            _unitOfWork.AddError(error);
        }

        protected bool CheckNullableEntity(T entity) // entity or model
        {
            if (entity == null)
            {
                AddError(500, "Entity is null");
                return true;
            }
            return false;
        }

        protected bool CheckNullableModel(TVM entity) // entity or model
        {
            if (entity == null)
            {
                AddError(500, "Model is null");
                return true;
            }
            return false;
        }

        public IList<SelectListItem> GetCreateItems()
        {
            return GetRequiredCreateModel();
        }

        public RequiredUpdateVM<TVM> GetUpdateItems(int id)
        {
            return GetRequiredUpdateModel(id);
        }

        public ICollection<T> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return  await _repository.GetAll().ToListAsync();
        }
        protected IList<T> MapModelListToEntities(IList<TVM> model)
        {
            if (model == null || model.Count == 0)
                return null;

            IList<T> entities = new List<T>();
            foreach (var item in model)
            {
                entities.Add(MapModelToEntity(item));
            }
            return entities;
        }
        protected IList<TVM> MapentityListToModels(IList<T> entity)
        {
            if (entity == null || entity.Count == 0)
                return null;

            IList<TVM> entitiesVm = new List<TVM>();
            foreach (var item in entity)
            {
                entitiesVm.Add(MapEntityToModel(item));
            }
            return entitiesVm;
        }
    }
}
