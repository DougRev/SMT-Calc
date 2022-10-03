using CalcModels.Franchise;
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
    public class FranchiseController : ApiController
    {
        private FranchiseServices CreateFranchiseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var franchiseService = new FranchiseServices(userId);
            return franchiseService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            FranchiseServices franchiseService = CreateFranchiseService();
            var franchise = franchiseService.GetFranchises();
            return Ok(franchise);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            FranchiseServices franchiseService = CreateFranchiseService();
            var franchise = franchiseService.GetFranchiseById(id);
            return Ok(franchise);
        }
        [HttpPost]
        public IHttpActionResult CreateFrancshise(AddFranchise franchise)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateFranchiseService();

            if (!service.CreateFranchise(franchise))
                return InternalServerError();

            return Ok("Franchise Added");
        }

        [HttpPut]
        public IHttpActionResult UpdateFranchise(EditFranchise franchise)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateFranchiseService();

            if (!service.UpdateFranchise(franchise))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFranchise(int id)
        {
            var service = CreateFranchiseService();

            if (!service.DeleteFranchise(id))
                return InternalServerError();

            return Ok("Franchise Deleted");
        }
    }
}
