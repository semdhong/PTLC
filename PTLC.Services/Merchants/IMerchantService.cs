using PTLC.Model.Merchant;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTLC.Services.Merchants
{
    public interface IMerchantService
    {
        public IEnumerable<MerchantModel> GetMerchants();
        public MerchantModel GetMerchant(Guid id);
        void CreateMerchant(MerchantModel model);
        void UpdateMerchant(MerchantModel model);
        void RemoveMerchant(Guid id);
    }
}
