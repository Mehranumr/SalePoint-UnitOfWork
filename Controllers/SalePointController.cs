using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using salepoint.APICommand;
using salepoint.DAL;
using salepoint.RequestDTO;

namespace salepoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalePointController : ControllerBase
    {
         private readonly IUnitOfWork unitOfWork;

         public SalePointController(IUnitOfWork unitOfWork)
         {
            this.unitOfWork=unitOfWork;
         }

        [HttpPost]
        [HttpPost("secure")]
        public IActionResult Post(APIRequest request)
        {
            if(request.methodId == "0")
            {
                var data = JsonSerializer.Deserialize<AddBrandRequestDTO>(request.data.GetRawText());

                Brand b = new Brand();
                b.BrandName = data.BrandName;

                unitOfWork.BrandRepository.Insert(b);
                unitOfWork.Save();

                 return Ok("Addded");
            }
            else if(request.methodId == "1")
            {
                var data = JsonSerializer.Deserialize<GetBrandRequestDTO>(request.data.GetRawText());
                var brands = unitOfWork.BrandRepository.GetByID(data.ID);

                return Ok(brands.BrandName);
            }

             return NotFound("Invalid Request");
        }
    }
}
