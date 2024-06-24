using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.Data;
using TestApi.Dtos.Stock;
using TestApi.Interfaces;
using TestApi.Mappers;

namespace TestApi.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IStockRepository _stockRepo;
    public StockController(ApplicationDbContext context, IStockRepository stockRepo)
    {
        _context = context;
        _stockRepo = stockRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var stocks = await _stockRepo.GetAllAsync();
        // var stocks = await _context.Stocks.ToListAsync();
        // Console.WriteLine(stocks);
        var stockDto = stocks.Select(s => s.ToStockDto());

        return Ok(stockDto);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var stock = await _stockRepo.GetByIdAsync(id);
        if (stock is null)
        {
            return NotFound();
        }
        return Ok(stock.ToStockDto());
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StockRequestDto stockDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var stockModel = stockDto.ToStockFromStockRequestDto();
        await _stockRepo.CreateAsync(stockModel);
        return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var stockModel = await _stockRepo.UpdateAsync(id, updateDto);
        if (stockModel is null)
        {
            return NotFound();
        }


        return Ok(stockModel.ToStockDto());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var stockModel = await _stockRepo.DeleteAsync(id);
        if (stockModel is null)
        {
            return NotFound();
        }

        return NotFound();
    }
}
