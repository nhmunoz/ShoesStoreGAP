using ShoesStore.DAL;
using ShoesStore.Filters;
using ShoesStore.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace ShoesStore.Controllers.API
{
    [System.Web.Http.RoutePrefix("services/stores")]
    [BasicAuthenticationAttribute]
    public class StoresController : ApiController
    {
        private StoreContext db = new StoreContext();

        // GET: Stores
        [Route("")]
        public IHttpActionResult GetStores()
        {
            try
            {
                var stores = db.Stores.ToList<Store>();

                var jsonResponse = new
                {
                    stores = stores,
                    success = true,
                    total_elements = stores.Count
                };

                return Ok(jsonResponse);
            }
            catch (Exception)
            {
                var jsonResponse = new
                {
                    error_msg = "Server Error",
                    success = false,
                    error_code = 500
                };
                return BadRequest(jsonResponse.ToString());
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}