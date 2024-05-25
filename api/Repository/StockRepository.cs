using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.DTOs.Stock;

namespace api.Repository
{
   public class StockRepository : IStockRepository{
        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context){
            _context = context;
        }

        public async Task<List<Stock>> getAllAsync(){
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id){
            var stockModel = await _context.Stocks.FindAsync(id);
            return stockModel;
        }
        
        public async Task<Stock> CreateAsync(Stock stockModel){
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            
            return stockModel;

        }
        
        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateDto){
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if(stockModel == null){
                return null;
            }

            stockModel.Symbol = updateDto.Symbol;
            stockModel.CompanyName = updateDto.CompanyName;
            stockModel.Purchase = updateDto.Purchase;
            stockModel.LastDiv = updateDto.LastDiv;
            stockModel.Industry = updateDto.Industry;
            stockModel.MarketCap = updateDto.MarketCap;

            await _context.SaveChangesAsync();
            return stockModel;
        }
        
        public async Task<Stock?> DeleteAsync (int id){
            var stockModel = await _context.Stocks.FirstOrDefaultAsync( x => x.Id == id );

            if(stockModel == null){
                return null;
            }

            _context.Stocks.Remove(stockModel);

            await _context.SaveChangesAsync();

            return stockModel;
        }
    }
}