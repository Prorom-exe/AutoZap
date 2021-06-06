using Microsoft.AspNetCore.Mvc;
using MobilePhoneBD.Data;
using MobilePhoneBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhoneBD.Controllers.ApiControllers
{   [Route("api/[controller]")]
    [ApiController]
    public class ApiController:ControllerBase
    {
        ApplicationDbContext db;

        public ApiController(ApplicationDbContext db)
        {
            this.db = db;
        }
        [Route("GetMan")]
        [HttpGet]
        public async Task<IActionResult> GetMan(int catId)
        {
            var result = db.Мanufacturers.Where(x => x.AutoId == catId).AsQueryable();
            return Ok(result);
        }

       
    }
}
