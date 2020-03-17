using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SwaggerTutorial.Models;

namespace SwaggerTutorial.Controllers
{
    [Route("api/resolutions")]
    [ApiController]
    public class ResolutionsController : ControllerBase
    {
        public List<ResolutionModel> _resolutions { get; set; } = new List<ResolutionModel>
        {
            new ResolutionModel(){ DealerName = "Dennis's Dodge", Id = 1, UnitCount = 10 },
            new ResolutionModel(){ DealerName = "Andy's Audi", Id = 2, UnitCount = 5 },
            new ResolutionModel(){ DealerName = "Tino's Tesla", Id = 3, UnitCount = 2 }
        };

        /// <summary>
        /// Returns all resolutions
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetResolutions")]
        public IEnumerable<ResolutionModel> Get()
        {
            return _resolutions;
        }

        /// <summary>
        /// Return resolution by Id
        /// </summary>
        [HttpGet]
        public ResolutionModel GetResolutionById([FromQuery] int id)
        {
            return _resolutions.First(x=>x.Id == id);
        }

        /// <summary>
        /// Adds resolution
        /// </summary>
        /// <param name="resolutionModel"></param>
        [HttpPost]
        public void AddResolution([FromBody] ResolutionModel resolutionModel)
        {
            _resolutions.Add(new ResolutionModel { DealerName = resolutionModel.DealerName, Id = resolutionModel.Id, UnitCount = resolutionModel.UnitCount });
        }

        /// <summary>
        /// deletes resolution
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public void DeleteResolutionById([FromQuery] int id)
        {
            _resolutions.RemoveAll(x=>x.Id == id);
        }
    }
}