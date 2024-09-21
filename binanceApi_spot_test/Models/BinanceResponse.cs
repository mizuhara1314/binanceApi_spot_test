using System;

namespace MyBinanceApiProject.Models
{
    // 最新价格的回应
    public class TickerPriceResponse
    {
        public string symbol { get; set; }
        public string price { get; set; }
    }

    // 下单请求的模型
    public class NewOrderRequest
    {
        public string symbol { get; set; }
        public string side { get; set; } // "BUY" or "SELL"
        public string type { get; set; } // "LIMIT" or "MARKET"
        public decimal quantity { get; set; }
        public decimal? price { get; set; }
        public long timestamp { get; set; } // 可以在 PlaceOrder 中生成
        public string timeInForce { get; set; } // "GTC", "IOC", etc.
    }

    // 订单状态的回应
    public class OrderStatusResponse
    {
        public string symbol { get; set; }
        public long orderId { get; set; }
        public string status { get; set; } // "FILLED", "CANCELED", etc.
    }
    // 交易历史的回应
    public class TradeHistoryResponse
    {
        public string symbol { get; set; } // 交易对，例如 "BNBBTC"
        public long id { get; set; } // 交易的唯一标识符
        public long orderId { get; set; } // 下单时的订单 ID
        public decimal price { get; set; } // 成交价格
        public decimal qty { get; set; } // 成交数量
        public decimal quoteQty { get; set; } // 成交金额
        public DateTime time { get; set; } // 交易时间
        public bool isBuyer { get; set; } // 是否是买方
    }


}
