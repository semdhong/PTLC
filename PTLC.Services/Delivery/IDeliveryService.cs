using PTLC.Model.Delivery;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTLC.Services.Delivery
{
    public interface IDeliveryService
    {
        #region Delivery Master
        public IEnumerable<DeliveryMasterModel> GetDeliveries();

        public DeliveryMasterModel GetDelivery(int id);

        int CreateDelivery(DeliveryMasterModel model);

        void UpdateDelivery(DeliveryMasterModel model);

        void RemoveDeliver(int id);
        #endregion

        #region Delivery Items
        public IEnumerable<DeliverItemsModel> GetItems(int masterId);

        public DeliverItemsModel GetItem(int id);

        void CreateItems(DeliverItemsModel model);

        void UpdateItems(DeliverItemsModel model);

        void RemoveItems(int id);
        #endregion

        #region Delivery Status
        public IEnumerable<DeliveryStatusModel> GetStatuses();

        public DeliveryStatusModel GetStatus(int id);

        void CreateStatus(DeliveryStatusModel model);
                  
        void UpdateStatus(DeliveryStatusModel model);
                 
        void RemoveStatus(int id);
        #endregion
    }
}
