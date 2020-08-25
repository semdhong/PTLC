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
    public class VehiclesController : ControllerBase
    {
        private readonly IMaintenanceServices _service;
        // GET: api/<VehiclesController>
        public VehiclesController(IMaintenanceServices service)
        {
            _service = service;
        }
        [HttpGet]
        public IEnumerable<VehicleTypeModel> Get()
        {
            return _service.GetVehicleTypes();
        }

        // GET api/<VehiclesController>/5
        [HttpGet("{id}")]
        public VehicleTypeModel Get(int id)
        {
            return _service.GetVehicleType(id);
        }

        // POST api/<VehiclesController>
        [HttpPost]
        public void Post(VehicleTypeModel model)
        {
            _service.CreateVehicleType(model);
        }

        // PUT api/<VehiclesController>/5
        [HttpPut]
        public void Put(VehicleTypeModel model)
        {
            _service.UpdateVehicleType(model);
        }

        // DELETE api/<VehiclesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
