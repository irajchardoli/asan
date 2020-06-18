using ASAN.Services.Contracts;
using ASAN.Services.ServiceBase;

namespace ASAN.Services
{
    public class OwnerService : CrudBase<ASAN.Entities.Owner>, IOwnerService
    {
        #region Constructor

        public OwnerService(Microsoft.Extensions.Logging.ILogger<ReadBase<ASAN.Entities.Owner>> logger,
              DataLayer.Context.IUnitOfWork uow) : base(logger, uow)
        {            
        }

        #endregion Constructor   
    }
}