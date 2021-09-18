
using Framework.Core;
using Framework.Core.Model;
using Framework.Core.UOW;
using Framework.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BaseAPIController<Service, Entity, VM> : CommonController where Service : IBaseService<Entity, VM> where Entity : class where VM : IVM, new()
    {
        internal readonly IUnitOfWork _unitOfWork;
        protected readonly Service _service;

        public BaseAPIController(IUnitOfWork unitOfWork, Service service)
        {
            _unitOfWork = unitOfWork;
            _service = service;
        }


        [HttpGet]
        public virtual IActionResult Get([FromQuery]QueryModel queryModel)
        {
           
            if (queryModel == null)
                queryModel = new QueryModel();
            var usersPage = _service.GetPagedResult();
            return ResCreateOk(usersPage);
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            var single = _service.GetById(id);
            if (single == null) return ResCreateNotFound();
            return ResCreateOk(single);
        }

        [HttpPost]
      
        public virtual async Task<IActionResult> Post(VM vm)
        {
            var entity = _service.Insert(vm);
            
            return await GetCreatedSaveResult(entity);
        }


        [HttpPost]
        [Route("v2/create")]

        public virtual async Task<IActionResult> PostVersion2(VM vm)
        {
            var entity = _service.Insert(vm);

            return await GetCreatedSaveResultVersion2(entity);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(long id, VM vm)
        {
            vm.Id = id;
            _service.Update(vm);
            return await GetSaveResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _service.Delete(new VM { Id = id });
            return await GetSaveResult();
        }

        [HttpGet]
        [Route("Create")]
        public virtual IActionResult Create()
        {
            return Ok(_service.GetCreateItems());
        }

        [HttpGet]
        [Route("Update/{id}")]
        public IActionResult Update(int id)
        {
            return Ok(_service.GetUpdateItems(id));
        }

        [NonAction]
        protected async Task<IActionResult> GetCreatedSaveResult(Entity entity)
        {
            if (!CheckExistError())
                await _unitOfWork.Save();

            return _unitOfWork.SaveResult.Affected > 0 ? CreatedAtAction(nameof(Get), new { id = 1 }, 1) : ResCreateServerError(_unitOfWork.SaveResult);
        }


        [NonAction]
        protected async Task<IActionResult> GetCreatedSaveResultVersion2(Entity entity)
        {
            if (!CheckExistError())
                await _unitOfWork.Save();

            return _unitOfWork.SaveResult.Affected > 0 ? Ok(_service.MapEntityToModel( entity)) : ResCreateServerError(_unitOfWork.SaveResult);
        }

        [NonAction]
        protected async Task<IActionResult> GetSaveResult()
        {
            if (!CheckExistError())
                await _unitOfWork.Save();

            return _unitOfWork.SaveResult.Affected > 0 ? ResCreateOk(_unitOfWork.SaveResult) : ResCreateServerError(_unitOfWork.SaveResult);
        }


        [NonAction]
        protected bool CheckExistError()
        {
            return _unitOfWork.SaveResult.Errors.Count != 0;
        }


    }
}