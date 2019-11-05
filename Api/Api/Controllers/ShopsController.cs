using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        UnitOfWork unitOfWork;
        public ShopsController()
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: api/Shops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shop>>> GetShops()
        {
            return await unitOfWork.Shops.GetAll();
        }

        // GET: api/Shops/5
        [HttpGet("{id}")]
        public ActionResult<Shop> GetShop(int id)
        {
            var shop = unitOfWork.Shops.Get(id);
            if (shop == null)
            {
                return NotFound();
            }

            return shop;
        }

        // PUT: api/Shops/5
        [HttpPut("{id}")]
        public  ActionResult<Shop> PutShop(int id, Shop shop)
        {
            if (id != shop.Id)
            {
                return BadRequest();
            }
            unitOfWork.Shops.Update(shop);
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

        // POST: api/Shops
        [HttpPost]
        public  ActionResult<Shop> PostShop(Shop shop)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Shops.Create(shop);
                unitOfWork.Save();
                return CreatedAtAction("GetShop", new { id = shop.Id }, shop);
            }
            return BadRequest();
        }

        // DELETE: api/Shops/5
        [HttpDelete("{id}")]
        public  ActionResult<Shop> DeleteShop(int id)
        {
            var shop = unitOfWork.Shops.Get(id).Value;
            if (shop == null)
            {
                return NotFound();
            }

            unitOfWork.Shops.Delete(id);
            unitOfWork.Save();

            return shop;
        }
    }
}
