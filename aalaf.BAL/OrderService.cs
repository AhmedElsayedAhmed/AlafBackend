using aalaf.BAL.Dtos;
using aalaf.BAL.Interfaces;
using AutoMapper;
using Framework.Core.BaseModel;
using Framework.Core.Repo;
using Framework.Core.UOW;
using Persistence;

namespace aalaf.BAL
{
    public class OrderService : BaseService<Order, OrderDto>, IOrderService
    {
       
        public OrderService(IRepository<Order> repository, IUnitOfWork unitOfWork,
            aalafContext aalaf,
          IMapper mapper
            )
            : base(repository, unitOfWork, mapper)
        {


        }

       
    }
}
