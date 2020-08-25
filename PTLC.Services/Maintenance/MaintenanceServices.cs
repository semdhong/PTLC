using PTLC.Data;
using PTLC.Model.Maintenance;
using PTLC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PTLC.Services.Maintenance
{
    public class MaintenanceServices : IMaintenanceServices
    {
        private readonly IRepository<VehicleType> _repoVT;
        private readonly IRepository<RateMatrix> _repoRM;
        private readonly IRepository<BusinessClass> _repoBC;

        public MaintenanceServices(IRepository<VehicleType> repoVT, IRepository<RateMatrix> repoRM, IRepository<BusinessClass> repoBC)
        {
            _repoBC = repoBC;
            _repoRM = repoRM;
            _repoVT = repoVT;
        }
        #region Vehicle Types
        public VehicleTypeModel GetVehicleType(int id)
        {
            return _repoVT.GetAll().Where(x => x.Id == id).Select(x => new VehicleTypeModel
            {
                 Id =x.Id,
                  Capacity =x.Capacity,
                   VehicleName =x.VehicleName
            }).FirstOrDefault();
        }

        public IEnumerable<VehicleTypeModel> GetVehicleTypes()
        {
            return _repoVT.GetAll().Select(x => new VehicleTypeModel
            {
                Id = x.Id,
                Capacity = x.Capacity,
                VehicleName = x.VehicleName,
                
            }).ToList();
        }
        public void CreateVehicleType(VehicleTypeModel model)
        {
            _repoVT.AddAsync(new VehicleType
            {
                Capacity = model.Capacity,
                VehicleName = model.VehicleName
            });
        }

        public void RemoveVehicleType(int id)
        {
            var rdata = _repoVT.GetAll().FirstOrDefault(x => x.Id == id);
            _repoVT.DeleteAsync(rdata);
        }

        public void UpdateVehicleType(VehicleTypeModel model)
        {
            _repoVT.UpdateAsync(new VehicleType
            {
                Id = model.Id,
                Capacity = model.Capacity,
                VehicleName = model.VehicleName
            });
        }
        #endregion

        #region Business Class
        public IEnumerable<BusinessClassModel> GetBusClasses()
        {
            return _repoBC.GetAll().Select(x => new BusinessClassModel
            {
                Id = x.Id,
                ClassName = x.ClassName
            }).ToList();
        }
        public BusinessClassModel GetBusClass(int id)
        {
            return _repoBC.GetAll().Select(x => new BusinessClassModel
            {
                Id = x.Id,
                ClassName = x.ClassName
            }).FirstOrDefault(x=>x.Id==id);
        }
        public void CreateBusClass(BusinessClassModel model)
        {
            _repoBC.AddAsync(new BusinessClass
            {
                ClassName = model.ClassName
            });
        }

        public void UpdateBusClass(BusinessClassModel model)
        {
            _repoBC.UpdateAsync(new BusinessClass
            {
                Id =model.Id,
                ClassName = model.ClassName
            });
        }

        public void RemoveBusClass(int id)
        {
            var rdata = _repoBC.GetAll().FirstOrDefault(x => x.Id == id);

            _repoBC.DeleteAsync(rdata);
        }




        #endregion

        #region Rate Matrix
        public RateMatrixModel GetRateMatrix(int id)
        {
            return _repoRM.GetAll().Select(x => new RateMatrixModel
            {
                VehicleTypeId = x.VehicleTypeId,
                BaseRate = x.BaseRate,
                KmRate = x.KmRate,
                CreatedBy = x.CreatedBy,
                UpdatedBy = x.UpdatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                 DropRate =x.DropRate,
                  ExcessHour =x.ExcessHour,
                   HundredKm =x.HundredKm,
                    HundredKmSucceed =x.HundredKmSucceed,
                     Vatable =x.Vatable

            }).FirstOrDefault(x => x.VehicleTypeId == id);
        }
      

        public void CreateRateMatrix(RateMatrixModel model)
        {
            _repoRM.AddAsync( new RateMatrix
            {
                VehicleTypeId = model.VehicleTypeId,
                BaseRate = model.BaseRate,
                KmRate = model.KmRate,
                CreatedBy = model.CreatedBy,
                UpdatedBy = model.UpdatedBy,
                CreatedDate = DateTime.Now,
                UpdatedDate = model.UpdatedDate,
                DropRate = model.DropRate,
                ExcessHour = model.ExcessHour,
                HundredKm = model.HundredKm,
                HundredKmSucceed = model.HundredKmSucceed,
                Vatable = model.Vatable

            });
        }


       
      

        public IEnumerable<RateMatrixModel> GetRateMatrixes()
        {
            return _repoRM.GetAll().Select(x => new RateMatrixModel
            {
                VehicleTypeId = x.VehicleTypeId,
                BaseRate = x.BaseRate,
                KmRate = x.KmRate,
                CreatedBy = x.CreatedBy,
                UpdatedBy = x.UpdatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                DropRate = x.DropRate,
                ExcessHour = x.ExcessHour,
                HundredKm = x.HundredKm,
                HundredKmSucceed = x.HundredKmSucceed,
                Vatable = x.Vatable
            }).ToList();
        }

        

       

        public void RemoveRateMatrix(int id)
        {
            var rdata = _repoRM.GetAll().FirstOrDefault(x => x.VehicleTypeId == id);
            _repoRM.DeleteAsync(rdata);
        }

        

        public void UpdateRateMatrix(RateMatrixModel model)
        {
            _repoRM.UpdateAsync(new RateMatrix
            {
                VehicleTypeId = model.VehicleTypeId,
                BaseRate = model.BaseRate,
                KmRate = model.KmRate,
                CreatedBy = model.CreatedBy,
                UpdatedBy = model.UpdatedBy,
                CreatedDate = model.CreatedDate,
                UpdatedDate = DateTime.Now,
                DropRate = model.DropRate,
                ExcessHour = model.ExcessHour,
                HundredKm = model.HundredKm,
                HundredKmSucceed = model.HundredKmSucceed,
                Vatable = model.Vatable

            });
        }

        #endregion
    }
}
