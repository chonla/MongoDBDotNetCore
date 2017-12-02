using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MongoDBDotNetCore.Controllers {
    [Route ("api/[controller]")]
    public class CustomersController : Controller {

        private CustomerLinQService cs;

        public CustomersController () {
            this.cs = new CustomerLinQService ();
        }

        // GET api/customers
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get () {
            return await this.cs.All ();
        }

        // GET api/customers/xxxxxxxxx
        [HttpGet ("{id}")]
        public async Task<Customer> Get (string id) {
            return await this.cs.Get (id);
        }

        // POST api/customers
        [HttpPost]
        public async Task Post ([FromBody] Customer value) {
            await this.cs.Add (value);
        }

        // PUT api/customers/5
        [HttpPut ("{id}")]
        public async Task Put (string id, [FromBody] Customer value) {
            await this.cs.Update(id, value);
        }

        // DELETE api/customers/5
        [HttpDelete ("{id}")]
        public async Task Delete (string id) {
            await this.cs.Remove(id);
        }
    }
}