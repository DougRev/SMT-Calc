using CalcData;
using CalcModels.Franchisee;
using CalcServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Smash_API.Controllers
{
    [Authorize]
    public class FranchiseeController : ApiController
    {
        private FranchiseeServices CreateFranchiseeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var franchiseeService = new FranchiseeServices(userId);
            return franchiseeService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            FranchiseeServices franchiseeService = CreateFranchiseeService();
            var franchisee = franchiseeService.GetFranchisees();
            return Ok(franchisee);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            FranchiseeServices franchiseeService = CreateFranchiseeService();
            var franchisee = franchiseeService.GetFranchiseeById(id);
            return Ok(franchisee);
        }
        [HttpPost]
        public IHttpActionResult CreateFrancshisee(AddFranchisee franchisee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateFranchiseeService();

            if (!service.CreateFranchisee(franchisee))
                return InternalServerError();

            return Ok("Franchisee Added");
        }

        [HttpPut]
        public IHttpActionResult UpdateFranchisee(FranchiseeEdit franchisee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateFranchiseeService();

            if (!service.UpdateFranchisee(franchisee))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFranchisee(int id)
        {
            var service = CreateFranchiseeService();

            if (!service.DeleteFranchisee(id))
                return InternalServerError();

            return Ok("Franchisee Deleted");
        }

    }
}
