using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Mappers;
using api.Models;
using api.DTOs.Stock;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;



namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]

    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepo;
    
        public StockController(ApplicationDBContext context, IStockRepository stockRepo){
            _stockRepo = stockRepo;
            _context = context;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAll(){
            var stocks = await _stockRepo.getAllAsync();

            var stockDto = stocks.Select(s => s.ToStockDto()); //Select ( function() ) is the .Net version of .map()

            return Ok(stocks);
        }

        [HttpGet("{id}")] //this id will be transfer directly into the paramater int id below (which is amazing :))
        public async Task<IActionResult> GetById([FromRoute] int id){
            var stock = await _stockRepo.GetByIdAsync(id);
            
            if(stock == null){
                return NotFound(); //This is one form of IActionResult
            }

            return Ok(stock.ToStockDto()); 
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto){ 
            var stockModel = stockDto.ToStockFromCreateDTO();

            stockModel = await _stockRepo.CreateAsync(stockModel);

            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());
        } 


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto){
            var stockModel = await _stockRepo.UpdateAsync(id, updateDto);

            if(stockModel == null){
                return NotFound();
            }

            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var stockModel = await _stockRepo.DeleteAsync(id);
            
            if(stockModel == null){
                return NotFound();
            }

            return NoContent(); //No content is an indicator of a successful delete

        }


    }
}