using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestApi.Data;
using TestApi.Dtos.Stock;
using TestApi.Interfaces;
using TestApi.Models;

namespace TestApi.Repository;

public class StockRepository : IStockRepository
{
    private readonly ApplicationDbContext _context;
    public StockRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Stock> CreateAsync(Stock stockModel)
    {
        await _context.Stocks.AddAsync(stockModel);
        await _context.SaveChangesAsync();
        return stockModel;
    }

    public async Task<Stock?> DeleteAsync(int id)
    {
        var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
        if (stockModel is null)
        {
            return null;
        }
        _context.Stocks.Remove(stockModel);
        await _context.SaveChangesAsync();
        return stockModel;
    }

    public async Task<List<Stock>> GetAllAsync()
    {
        return await _context.Stocks.ToListAsync();
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        return await _context.Stocks.FindAsync(id);

    }

    public async Task<Stock> UpdateAsync(int id, UpdateStockRequestDto updateDto)
    {
        var existingStock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
        if (existingStock is null)
        {
            return null;
        }
        existingStock.Symbol = updateDto.Symbol;
        existingStock.CompanyName = updateDto.CompanyName;
        existingStock.Purchase = updateDto.Purchase;
        existingStock.LastDiv = updateDto.LastDiv;
        existingStock.Industry = updateDto.Industry;
        existingStock.MarketCap = updateDto.MarketCap;

        await _context.SaveChangesAsync();
        return existingStock;
    }
}
