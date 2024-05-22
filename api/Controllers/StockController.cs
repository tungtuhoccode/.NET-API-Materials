using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Mappers;
using api.Models;
using api.DTOs.Stock;
using Microsoft.AspNetCore.Mvc;



namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]

    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
    
        public StockController(ApplicationDBContext context){
            _context = context;
        }

        [HttpGet] 
        public IActionResult GetAll(){
            var stocks = _context.Stocks.ToList()
            .Select(s => s.ToStockDto()); //Select ( function() ) is the .Net version of .map()

            return Ok(stocks);
        }

        [HttpGet("{id}")] //this id will be transfer directly into the paramater int id below (which is amazing :))
        public IActionResult GetById([FromRoute] int id){
            var stock = _context.Stocks.Find(id);
            
            if(stock == null){
                return NotFound(); //This is one form of IActionResult
            }

            return Ok(stock.ToStockDto()); 
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockDto){ 
            var stockModel = stockDto.ToStockFromCreateDTO();
            _context.Stocks.Add(stockModel);
            _context.SaveChanges();
// return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto()); 
            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());
        } 

    }
}