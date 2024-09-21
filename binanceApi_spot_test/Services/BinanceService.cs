using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MyBinanceApiProject.Models;
using Newtonsoft.Json;

namespace MyBinanceApiProject.Services
{
    public class BinanceService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _apiSecret;

        public BinanceService(IConfiguration config)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(config["BinanceApi:BaseUrl"]) };
            _apiKey = config["BinanceApi:ApiKey"];
            _apiSecret = config["BinanceApi:ApiSecret"];
        }
        //生成signature，有關帳戶資訊的請求需要
        private string GenerateSignature(string queryString)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_apiSecret)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(queryString));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
        // 獲取最新價格
        public async Task<string> GetTickerPrice(string symbol)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/v3/ticker/price?symbol={symbol.ToUpper()}");
            request.Headers.Add("X-MBX-APIKEY", _apiKey);
            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }

        // 下單
        public async Task<string> PlaceOrder(NewOrderRequest order)
        {
            // 生成时间戳
            order.timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            // 创建查询字符串并生成签名
            var queryString = $"symbol={order.symbol}&side={order.side}&type={order.type}&quantity={order.quantity}&price={order.price}&timestamp={order.timestamp}&timeInForce={order.timeInForce}";
            var signature = GenerateSignature(queryString);

            // 构建请求 URL
            var requestUrl = $"/api/v3/order?{queryString}&signature={signature}";

            // 创建请求
            var request = new HttpRequestMessage(HttpMethod.Post, requestUrl)
            {
                Content = new StringContent("", Encoding.UTF8, "application/json") // 因为 signature 已经在 URL 中
            };

            request.Headers.Add("X-MBX-APIKEY", _apiKey);

            // 发送请求并返回结果
            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }



        // 查詢訂單狀態
        public async Task<string> GetOrderStatus(long orderId, string symbol)
        {
            // 生成时间戳
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            // 创建查询字符串并生成签名
            var queryString = $"symbol={symbol.ToUpper()}&orderId={orderId}&timestamp={timestamp}";
            var signature = GenerateSignature(queryString);

            // 构建请求 URL
            var requestUrl = $"/api/v3/order?{queryString}&signature={signature}";

            // 创建请求
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.Headers.Add("X-MBX-APIKEY", _apiKey);

            // 发送请求并返回结果
            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }

        // 查詢帳戶交易歷史
        public async Task<string> GetTradeHistory(string symbol)
        {
            // 获取当前时间戳
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            // 创建查询字符串并生成签名
            var queryString = $"symbol={symbol.ToUpper()}&timestamp={timestamp}";
            var signature = GenerateSignature(queryString);

            // 构建完整的请求 URL
            var requestUrl = $"/api/v3/myTrades?{queryString}&signature={signature}";

            // 创建请求
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.Headers.Add("X-MBX-APIKEY", _apiKey);

            // 发送请求并返回结果
            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }


    }
}
