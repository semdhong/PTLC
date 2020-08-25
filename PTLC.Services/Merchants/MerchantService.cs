using PTLC.Data;
using PTLC.Model.Merchant;
using PTLC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PTLC.Services.Merchants
{
    public class MerchantService : IMerchantService
    {
        private readonly IRepository<Merchant> _repoMer;
        public MerchantService(IRepository<Merchant> repoMer)
        {
            _repoMer = repoMer;
        }
        public void CreateMerchant(MerchantModel model)
        {
            _repoMer.AddAsync(new Merchant
            {
                CustomerName = model.CustomerName,
                Address = model.Address,
                BusinessClass = model.BusinessClassId,
                ContactPerson = model.ContactPerson,
                TelNo = model.TelNo,
                MobileNo = model.MobileNo,
                Birthdate = model.Birthdate,
                QrCode = model.QrCode,
                CreatedBy = model.CreatedBy,
                CreatedDate = DateTime.Now,
                UserId = model.UserId,
                Email = model.Email,
                BusinessName =model.BusinessName
            });
        }

        public MerchantModel GetMerchant(Guid id)
        {
            return _repoMer.GetAll().Select(x => new MerchantModel
            {
                Id = x.Id,
                CustomerName = x.CustomerName,
                Address = x.Address,
                BusinessClassId = x.BusinessClass,
                ContactPerson = x.ContactPerson,
                TelNo = x.TelNo,
                MobileNo = x.MobileNo,
                Birthdate = x.Birthdate,
                QrCode = x.QrCode,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UserId = x.UserId,
                Email = x.Email,
                BusinessName = x.BusinessName,
                UpdateDate = x.UpdatedDate,
                UpdatedBy = x.UpdatedBy,
            }).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<MerchantModel> GetMerchants()
        {
            return _repoMer.GetAll().Select(x => new MerchantModel
            {
                Id = x.Id,
                CustomerName = x.CustomerName,
                Address = x.Address,
                BusinessClassId = x.BusinessClass,
                ContactPerson = x.ContactPerson,
                TelNo = x.TelNo,
                MobileNo = x.MobileNo,
                Birthdate = x.Birthdate,
                QrCode = x.QrCode,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UserId = x.UserId,
                Email = x.Email,
                BusinessName = x.BusinessName,
                UpdateDate = x.UpdatedDate,
                UpdatedBy = x.UpdatedBy,
               
            }).ToList();
        }

        public void RemoveMerchant(Guid id)
        {
            var rdata = _repoMer.GetAll().FirstOrDefault(x => x.Id == id);
            _repoMer.DeleteAsync(rdata);
        }

        public void UpdateMerchant(MerchantModel model)
        {
            _repoMer.UpdateAsync(new Merchant
            {
                Id =model.Id,
                CustomerName = model.CustomerName,
                Address = model.Address,
                BusinessClass = model.BusinessClassId,
                ContactPerson = model.ContactPerson,
                TelNo = model.TelNo,
                MobileNo = model.MobileNo,
                Birthdate = model.Birthdate,
                QrCode = model.QrCode,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
                UserId = model.UserId,
                Email = model.Email,
                BusinessName = model.BusinessName,
                UpdatedDate =DateTime.Now,
                 UpdatedBy = model.UpdatedBy
            });
        }
    }
}
