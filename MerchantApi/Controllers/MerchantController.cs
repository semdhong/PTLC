using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PTLC.Model.Merchant;
using PTLC.Repository;
using PTLC.Services.Merchants;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MerchantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IMerchantService _service;
        public MerchantController(IMerchantService service)
        {
            _service = service;
        }
        // GET: api/<MerchantController>
        [HttpGet]
        public IEnumerable<MerchantModel> Get()
        {
            return _service.GetMerchants();
        }

        // GET api/<MerchantController>/5
        [HttpGet("{id}")]
        public MerchantModel Get(Guid id)
        {
            return _service.GetMerchant(id);
        }

        // POST api/<MerchantController>
        [HttpPost]
        public void Post(MerchantModel model)
        {
            _service.CreateMerchant(model);
        }

        // PUT api/<MerchantController>/5
        [HttpPut]
        public void Put(MerchantModel model)
        {
            _service.UpdateMerchant(model);
        }

        // DELETE api/<MerchantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
