using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Dtos.Stock;
using TestApi.Models;

namespace TestApi.Mappers;

public static class StockMappers
{
    public static StockDto ToStockDto(this Stock stockModel)
    {
        return new StockDto
        {
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            Purchase = stockModel.Purchase,
            LastDiv = stockModel.LastDiv,
            Industry = stockModel.Industry,
            MarketCap = stockModel.MarketCap,
            Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList()

        };
    }
    public static Stock ToStockFromStockRequestDto(this StockRequestDto stockDto)
    {
        return new Stock
        {
            Symbol = stockDto.Symbol,
            CompanyName = stockDto.CompanyName,
            Purchase = stockDto.Purchase,
            LastDiv = stockDto.LastDiv,
            Industry = stockDto.Industry,
            MarketCap = stockDto.MarketCap,

        };
    }
}
