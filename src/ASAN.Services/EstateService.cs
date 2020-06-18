using ASAN.Services.Contracts;
using ASAN.Services.ServiceBase;

namespace ASAN.Services
{
    public class EstateService : CrudBase<ASAN.Entities.Estate>, IEstateService
    {
        #region Constructor

        public EstateService(Microsoft.Extensions.Logging.ILogger<ReadBase<ASAN.Entities.Estate>> logger,
              DataLayer.Context.IUnitOfWork uow) : base(logger, uow)
        {
        }

        #endregion Constructor   
    }
}