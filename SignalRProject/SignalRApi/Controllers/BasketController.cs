using BusinessLogic.Abstract;
using DataAccess.Concrete;
using Dto.BasketDto;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("BasketListByTableWithCarName")]
        public IActionResult BasketListByTableWithCarName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x => x.Car).Include(d=>d.Car.Brands).Where(y => y.TableNumberId == id).Select(z => new ResultBasketDto
            {
                TableNumberId=z.TableNumberId,
                BasketID=z.BasketID,
                CarId=z.CarId,
                Count=z.Count,
                Price=z.Price,
                CarName = z.Car.Brands.BrandName +" "+z.Car.Model,
                TotalPrice = z.TotalPrice
            }).ToList();
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();
            _basketService.TInsert(new Basket()
            {
                CarId=createBasketDto.CarId,
                Count=1,
                TableNumberId=1,
                Price=context.Cars.Where(x=>x.CarID==createBasketDto.CarId).Select(y=>y.Price).FirstOrDefault(),
                TotalPrice=0
            });
            return Ok();
        }




        [HttpDelete("{id:int}")]
        public IActionResult DeleteBasket(int id)
        {
            var value=_basketService.TGetById(id);  
            _basketService.TDelete(value);
            return Ok("Sepetteki Seçilen Ürün Silindi!");
        }
    }
}
