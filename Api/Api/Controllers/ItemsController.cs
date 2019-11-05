using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        UnitOfWork unitOfWork;
        public ItemsController()
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await unitOfWork.Items.GetAll();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(int id)
        {
            var item = unitOfWork.Items.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        public ActionResult<Item> PutItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            unitOfWork.Items.Update(item);
            try
            {
                unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Items
        [HttpPost]
        public ActionResult<Item> PostItem(Item item)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Items.Create(item);
                unitOfWork.Save();
                return CreatedAtAction("GetItem", new { id = item.Id }, item);
            }
            return BadRequest();
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public ActionResult<Item> DeleteItem(int id)
        {
            var item = unitOfWork.Items.Get(id).Value;
            if (item == null)
            {
                return NotFound();
            }

            unitOfWork.Items.Delete(id);
            unitOfWork.Save();

            return item;
        }
    }
}
