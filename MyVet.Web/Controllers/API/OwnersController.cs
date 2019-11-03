using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyVet.Common.Models;
using MyVet.Web.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController: ControllerBase
    {
        private readonly DataContext _dataContext;

        public OwnersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        [Route("GetOwnerByEmail")]
        public async Task<IActionResult> GetOwner(EmailRequest emailRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            var owner = await _dataContext.Owners
                .Include(o => o.User)
                .Include(o => o.Pets)
                .Include(o => o.Agendas)
                .FirstOrDefaultAsync(o => o.User.Email == emailRequest.Email);
            
            if (owner == null)
            {
                return NotFound();
            }


            return Ok(owner);

        }//final GetOwner


    }//final class
}//final namespace
