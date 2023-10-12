using DataAccess.ActivityLogRepository;
using DataAccess.ColorRepository;
using DataAccess.Context;
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
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            CustomerRepository = new CustomerRepository(_context);
            WorkshopRepository = new WorkshopRepository(_context);
            UserRepository = new UserRepository(_context);
            ColorRepository = new ColorRepository (_context);
            JobStatusRepository = new JobStatusRepository (_context);
            RoleRepository = new RoleRepository (_context);
            StageRepository = new StageRepository (_context);
            VehicleMakeRepository = new VehicleMakeRepository (_context);
            VehicleModelRepository = new VehicleModelRepository(_context);
            JobRepository = new JobRepository(_context);
            CustomerTypeRepository = new CustomerTypeRepository(_context);
            ActivityLogRepository = new ActivityLogRepository(_context);
            ErrorLogRepository = new ErrorLogRepository(_context);
            OwnerRepository = new OwnerRepository(_context);

            tamamUserRepository = new TamamUserRepository(_context);
            tamamClaimRepository = new TamamClaimRepository(_context);
            tamamAddressRepository = new TamamAddressRepository(_context);
            tamamVehicleRepository = new TamamVehicleRepository(_context);
        }
        public ICustomerRepository CustomerRepository { get; private set; }
        public IWorkshopRepository WorkshopRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public IColorRepository ColorRepository { get; private set; }
        public IJobStatusRepository JobStatusRepository { get; private set; }
        public IRoleRepository RoleRepository { get; private set; }
        public IStageRepository StageRepository { get; private set; }
        public IVehicleMakeRepository VehicleMakeRepository { get; private set; }
        public IVehicleModelRepository VehicleModelRepository { get; private set; }
        public IJobRepository JobRepository { get; private set; }
        public ICustomerTypeRepository CustomerTypeRepository { get; private set; }
        public IActivityLogRepository ActivityLogRepository { get; private set; }
        public IErrorLogRepository ErrorLogRepository { get; private set; }
        public IOwnerRepository OwnerRepository { get; private set; }

        public ITamamUserRepository tamamUserRepository { get; private set; }
        public ITamamAddressRepository tamamAddressRepository { get; private set; }
        public ITamamVehicleRepository tamamVehicleRepository { get; private set; }
        public ITamamClaimRepository tamamClaimRepository { get; private set; }
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
