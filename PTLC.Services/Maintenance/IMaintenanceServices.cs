using System;
using System.Collections.Generic;
using System.Text;
using PTLC.Model.Maintenance;
namespace PTLC.Services.Maintenance
{
    public interface IMaintenanceServices
    {

        #region Vehicle Types
        public IEnumerable<VehicleTypeModel> GetVehicleTypes();
        public VehicleTypeModel GetVehicleType(int id);
        void CreateVehicleType(VehicleTypeModel model);
        void UpdateVehicleType(VehicleTypeModel model);
        void RemoveVehicleType(int id);
        #endregion

        #region Rate Matrix
        public IEnumerable<RateMatrixModel> GetRateMatrixes();
        public RateMatrixModel GetRateMatrix(int id);
        void CreateRateMatrix(RateMatrixModel model);
        void UpdateRateMatrix(RateMatrixModel model);
        void RemoveRateMatrix(int id);
        #endregion

        #region Business Class
        public IEnumerable<BusinessClassModel> GetBusClasses();
        public BusinessClassModel GetBusClass(int id);
        void CreateBusClass(BusinessClassModel model);
        void UpdateBusClass(BusinessClassModel model);
        void RemoveBusClass(int id);
        #endregion

    }
}
