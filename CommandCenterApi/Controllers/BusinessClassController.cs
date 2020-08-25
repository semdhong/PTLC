using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PTLC.Model.Maintenance;
using PTLC.Services.Maintenance;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommandCenterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessClassController : ControllerBase
    {
        private readonly IMaintenanceServices _service;
        // GET: api/<VehiclesController>
        public BusinessClassController(IMaintenanceServices service)
        {
            _service = service;
        }
        [HttpGet]
        public IEnumerable<BusinessClassModel> Get()
        {
            return _service.GetBusClasses();
        }

        // GET api/<VehiclesController>/5
        [HttpGet("{id}")]
        public BusinessClassModel Get(int id)
        {
            return _service.GetBusClass(id);
        }

        // POST api/<VehiclesController>
        [HttpPost]
        public void Post(BusinessClassModel model)
        {
            _service.CreateBusClass(model);
        }

        // PUT api/<VehiclesController>/5
        [HttpPut]
        public void Put(BusinessClassModel model)
        {
            _service.UpdateBusClass(model);
        }

        // DELETE api/<VehiclesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
