using DataAccess.ActivityLogRepository;
using DataAccess.ColorRepository;
using DataAccess.CustomerRepository;
using DataAccess.CustomerTypeRepository;
using DataAccess.ErrorLogRepository;
using DataAccess.JobRepository;
using DataAccess.JobStatusRepository;
using DataAccess.OwnerRepository;
using DataAccess.RoleRepository;
using DataAccess.StageRepository;
using DataAccess.TamamAddressRepository;
using DataAccess.TamamClaimRepository;
using DataAccess.TamamUserRepository;
using DataAccess.TamamVehicleRepository;
using DataAccess.UserRepository;
using DataAccess.VehicleMakeRepository;
using DataAccess.VehicleModelRepository;
using DataAccess.WorkshopRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        Task<int> Complete();
        void Dispose();
        ICustomerRepository CustomerRepository { get; }
        IWorkshopRepository WorkshopRepository { get; }
        IUserRepository UserRepository { get; }
        IColorRepository ColorRepository { get; }
        IJobStatusRepository JobStatusRepository { get; }
        IRoleRepository RoleRepository { get; }
        IStageRepository StageRepository { get; }
        IVehicleMakeRepository VehicleMakeRepository { get; }
        IVehicleModelRepository VehicleModelRepository { get; }
        IJobRepository JobRepository { get; }
        ICustomerTypeRepository CustomerTypeRepository { get; }
        IActivityLogRepository ActivityLogRepository { get; }
        IErrorLogRepository ErrorLogRepository { get; }
        IOwnerRepository OwnerRepository { get; }

        ITamamUserRepository tamamUserRepository { get; }
        ITamamAddressRepository tamamAddressRepository { get; }
        ITamamVehicleRepository tamamVehicleRepository { get; }
        ITamamClaimRepository tamamClaimRepository { get; }
    }
}
