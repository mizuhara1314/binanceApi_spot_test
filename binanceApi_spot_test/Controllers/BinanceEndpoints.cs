using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyBinanceApiProject.Services;
using MyBinanceApiProject.Models;


namespace MyBinanceApiProject.Controllers
{
    [ApiController]
    [Route("api/binance")]
    public class BinanceEndpoints : ControllerBase
    {
        private readonly BinanceService _binanceService;

        public BinanceEndpoints(BinanceService binanceService)
        {
            _binanceService = binanceService;
        }

        [HttpGet("price/{symbol}")]
        public async Task<IActionResult> GetPrice(string symbol)
        {
            var result = await _binanceService.GetTickerPrice(symbol);
            return Ok(result);
        }

        [HttpPost("order")]
        public async Task<IActionResult> PlaceOrder([FromBody] NewOrderRequest order)
        {
            var result = await _binanceService.PlaceOrder(order);
            return Ok(result);
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetOrderStatus(long orderId, string symbol)
        {
            var result = await _binanceService.GetOrderStatus(orderId, symbol);
            return Ok(result);
        }

        [HttpGet("trades/{symbol}")]
        public async Task<IActionResult> GetTradeHistory(string symbol)
        {
            var result = await _binanceService.GetTradeHistory(symbol);
            return Ok(result);
        }



    }
}
