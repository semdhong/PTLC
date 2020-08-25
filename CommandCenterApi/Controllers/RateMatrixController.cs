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
    public class RateMatrixController : ControllerBase
    {
        private readonly IMaintenanceServices _service;
        // GET: api/<VehiclesController>
        public RateMatrixController(IMaintenanceServices service)
        {
            _service = service;
        }
        [HttpGet]
        public IEnumerable<RateMatrixModel> Get()
        {
            return _service.GetRateMatrixes();
        }

        // GET api/<VehiclesController>/5
        [HttpGet("{id}")]
        public RateMatrixModel Get(int id)
        {
            return _service.GetRateMatrix(id);
        }

        // POST api/<VehiclesController>
        [HttpPost]
        public void Post(RateMatrixModel model)
        {
            _service.CreateRateMatrix(model);
        }

        // PUT api/<VehiclesController>/5
        [HttpPut]
        public void Put(RateMatrixModel model)
        {
            _service.UpdateRateMatrix(model);
        }

        // DELETE api/<VehiclesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
