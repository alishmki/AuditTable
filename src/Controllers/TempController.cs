using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AuditTable.Controllers
{    
    [Route("api")]
    public class TempController : ControllerBase
    {
        [HttpPost]       
        public async Task<IActionResult> Add()
        {
            var context = new SampleContext();
            context.Customers.Add(new Customer { FirstName = "ali", LastNamee = "alavi",Contacts=new List<Contact> 
            {
                new Contact{ Name="c1" },
                new Contact{ Name="c2" }
            } });
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPatch]
        [Route("{name}")]
        public async Task<IActionResult> Edit(string name)
        {
            var context = new SampleContext();
            var entity = context.Customers.First();
            entity.FirstName = name;
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch]
        [Route("{id}/{name}")]
        public async Task<IActionResult> Edit(int id,string name)
        {
            var en = new Customer() { Id = id, FirstName = name };
            var context = new SampleContext();
            context.Entry(en).Property(x => x.FirstName).IsModified = true;
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var context = new SampleContext();
            var entity = context.Customers.First();
            context.Customers.Remove(entity);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
