using PTLC.Data;
using PTLC.Model.Delivery;
using PTLC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PTLC.Services.Delivery
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IRepository<DeliveryMaster> _repoDM;
        private readonly IRepository<DeliveryItem> _repoDI;
        private readonly IRepository<DeliveryStatus> _repoDS;
        public DeliveryService(IRepository<DeliveryMaster> repoDM, IRepository<DeliveryItem> repoDI, IRepository<DeliveryStatus> repoDS)
        {
            _repoDI = repoDI;
            _repoDM = repoDM;
            _repoDS = repoDS;
        }
        public int CreateDelivery(DeliveryMasterModel model)
        {
            _repoDM.AddAsync(new DeliveryMaster
            {
             
                RefNo = model.RefNo,
                MerchantId = model.MerchantId,
                RiderId = model.RiderId,
                CreatedBy = model.CreatedBy,
                 CreatedDate = DateTime.Now,
                  TotalAmount = model.TotalAmount,
                  TotalPayable = model.TotalPayable,
                   TotalDeliveryFee = model.TotalDeliveryFee,
                   Origin = model.Origin
            });

           
            return model.Id;
        }

        public void CreateItems(DeliverItemsModel model)
        {
            _repoDI.AddAsync(new DeliveryItem
            {
                DeliveryMasterId = model.DeliveryMasterId,
                Description = model.Description,
                Address = model.Address,
                Amount = model.Amount,
                Recipient = model.Recipient,
                DeliveryFee = model.DeliveryFee,
                Distance = model.Distance,
                ScheduleDate = model.ScheduleDate,
                TotalPayable = model.TotalPayable,
                DeliveryStatus = model.DeliveryStatus
            });
        }

        public void CreateStatus(DeliveryStatusModel model)
        {
            _repoDS.AddAsync(new DeliveryStatus
            {
                StatusName = model.DeliveryStatus
            });
        }

        public IEnumerable<DeliveryMasterModel> GetDeliveries()
        {
            return _repoDM.GetAll().Select(x => new DeliveryMasterModel
            {
                RefNo = x.RefNo,
                MerchantId = x.MerchantId,
                RiderId = x.RiderId,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                TotalAmount = x.TotalAmount,
                TotalPayable = x.TotalPayable,
                TotalDeliveryFee = x.TotalDeliveryFee,
                Origin = x.Origin,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,
                TotalDelivered = x.TotalDelivered,
                Id = x.Id,
                Items = x.DeliveryItems.Select(d => new DeliverItemsModel
                {
                    ItemsId = d.ItemsId,
                    DeliveryMasterId = d.DeliveryMasterId,
                    Description = d.Description,
                    Address = d.Address,
                    Amount = d.Amount,
                    Recipient = d.Recipient,
                    DeliveryFee = d.DeliveryFee,
                    Distance = d.Distance,
                    ScheduleDate = d.ScheduleDate,
                    TotalPayable = d.TotalPayable,
                    DeliveryStatus = d.DeliveryStatus
                }).ToList(),


            });
        }

        public DeliveryMasterModel GetDelivery(int id)
        {
            return _repoDM.GetAll().Select(x => new DeliveryMasterModel
            {
                RefNo = x.RefNo,
                MerchantId = x.MerchantId,
                RiderId = x.RiderId,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                TotalAmount = x.TotalAmount,
                TotalPayable = x.TotalPayable,
                TotalDeliveryFee = x.TotalDeliveryFee,
                Origin = x.Origin,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,
                TotalDelivered = x.TotalDelivered,
                Id = x.Id,
                Items = x.DeliveryItems.Select(d => new DeliverItemsModel
                {
                    ItemsId = d.ItemsId,
                    DeliveryMasterId = d.DeliveryMasterId,
                    Description = d.Description,
                    Address = d.Address,
                    Amount = d.Amount,
                    Recipient = d.Recipient,
                    DeliveryFee = d.DeliveryFee,
                    Distance = d.Distance,
                    ScheduleDate = d.ScheduleDate,
                    TotalPayable = d.TotalPayable,
                    DeliveryStatus = d.DeliveryStatus
                }).ToList(),


            }).FirstOrDefault(x=>x.Id==id);
        }

        public DeliverItemsModel GetItem(int id)
        {
            return _repoDI.GetAll().Select(x => new DeliverItemsModel
            {
                ItemsId = x.ItemsId,
                DeliveryMasterId = x.DeliveryMasterId,
                Address = x.Address,
                Amount = x.Amount,
                DeliveryFee = x.DeliveryFee,
                DeliveryStatus = x.DeliveryStatus,
                Description = x.Description,
                Distance = x.Distance,
                Recipient = x.Recipient,
                ScheduleDate = x.ScheduleDate,
                TotalPayable = x.TotalPayable
            }).FirstOrDefault(x => x.ItemsId == id);
        }

        public IEnumerable<DeliverItemsModel> GetItems(int masterId)
        {
            return _repoDI.GetAll().Where(x => x.DeliveryMasterId == masterId).Select(x => new DeliverItemsModel
            {
                ItemsId = x.ItemsId,
                DeliveryMasterId = x.DeliveryMasterId,
                Address = x.Address,
                Amount = x.Amount,
                DeliveryFee = x.DeliveryFee,
                DeliveryStatus = x.DeliveryStatus,
                Description = x.Description,
                Distance = x.Distance,
                Recipient = x.Recipient,
                ScheduleDate = x.ScheduleDate,
                TotalPayable = x.TotalPayable
            }).ToList();
        }

        public DeliveryStatusModel GetStatus(int id)
        {
            return _repoDS.GetAll().Select(x => new DeliveryStatusModel
            {
                Id = x.Id,
                DeliveryStatus = x.StatusName
            }).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<DeliveryStatusModel> GetStatuses()
        {
            return _repoDS.GetAll().Select(x => new DeliveryStatusModel
            {
                Id = x.Id,
                DeliveryStatus = x.StatusName
            }).ToList();
        }

        public void RemoveDeliver(int id)
        {
            var rdata = _repoDM.GetAll().FirstOrDefault(x => x.Id == id);
            _repoDM.DeleteAsync(rdata);
        }

        public void RemoveItems(int id)
        {
            var rdata = _repoDI.GetAll().FirstOrDefault(x => x.ItemsId == id);
            _repoDI.DeleteAsync(rdata);
        }

        public void RemoveStatus(int id)
        {
            var rdata = _repoDS.GetAll().FirstOrDefault(x => x.Id == id);
            _repoDS.DeleteAsync(rdata);
        }

        public void UpdateDelivery(DeliveryMasterModel model)
        {
            _repoDM.UpdateAsync(new DeliveryMaster
            {
                 Id =model.Id,
                RefNo = model.RefNo,
                MerchantId = model.MerchantId,
                RiderId = model.RiderId,
                CreatedBy = model.CreatedBy,
                CreatedDate = DateTime.Now,
                TotalAmount = model.TotalAmount,
                TotalPayable = model.TotalPayable,
                TotalDeliveryFee = model.TotalDeliveryFee,
                Origin = model.Origin
            });
        }

        public void UpdateItems(DeliverItemsModel model)
        {
            _repoDI.UpdateAsync(new DeliveryItem
            {
                DeliveryMasterId = model.DeliveryMasterId,
                Description = model.Description,
                Address = model.Address,
                Amount = model.Amount,
                Recipient = model.Recipient,
                DeliveryFee = model.DeliveryFee,
                Distance = model.Distance,
                ScheduleDate = model.ScheduleDate,
                TotalPayable = model.TotalPayable,
                DeliveryStatus = model.DeliveryStatus
            });
        }

        public void UpdateStatus(DeliveryStatusModel model)
        {
            _repoDS.UpdateAsync(new DeliveryStatus
            {
                Id =model.Id,
                StatusName = model.DeliveryStatus
            });
        }
    }
}
