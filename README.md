# 1. 簡介：
測試幣安api的基礎功能，並設計後端代理interface接口可供前端使用，有最新價格，下單，查詢訂單狀態，查詢帳戶交易歷史

由於是純web_api所以用自帶的swagger_ui套件測試

**注意事項**
找到幣安Spotapi的testnet官方使用文檔或github使用文檔，找testnet的baseUrl，同時注意官方文檔

只能選api不能sapi的，同時選擇不需要ip認證(不需要暴露在外網環境)的api做測試

https://binance-docs.github.io/apidocs/spot/en/#test-new-order-using-sor-trade

# 2. 文件說明
**BinanceEndpoints:**  處理前端api請求的邏輯(controller)，需要寫signature加密函數確保有關帳戶請求的安全性和有效性

**BinanceService:**    與 Binance API 進行交互的邏輯

**BinanceResponse**    定義post，接收回傳資料這種需要大結構的model，其他就直接傳參數

**appsettings.json:**   環境變量設定檔，不多介紹，我把金鑰跟BaseUrl全放進去(實際上最好分開比較好)

**csproj:**          管理套件，要增加json反序列化套件，然後執行dotnet restore安裝更新

# 3. 成果：

**rest_api列表**

![image](https://github.com/user-attachments/assets/b5b94513-242c-41bc-827c-bc32f91b54ce)


**取得幣種最新價格(需要前端傳入symbol參數)**

![image](https://github.com/user-attachments/assets/2bb706c1-9b1e-4eb0-bba5-25c1f4bae7c7)


**新增訂單資訊(需要前端post json，並注意下單金額數量要合法)**

先參考目前價格
![image](https://github.com/user-attachments/assets/1f9f7ae5-b253-49dd-90fd-a98499c236f0)

然後構建合法下單請求(符合過濾器限制，要求參數等)

```json
{
    "symbol": "LTCBTC",
    "side": "BUY",
    "type": "LIMIT",
    "quantity": 0.1,
    "price": 0.001039,
    "timeInForce": "GTC"
}
```
![image](https://github.com/user-attachments/assets/41a6c7a2-a5ec-400a-95a2-ba75eee3d19e)


**查詢訂單資訊(訂單編號，幣種參數)**

![image](https://github.com/user-attachments/assets/f3492bb6-45c1-4719-9672-fdf512cf238c)

這部分好像不用signature，不過還是加了

**查詢帳戶歷史交易**




# 4. 收穫：
熟悉一下asp.net與其他後端框架語法差別，環境變數，套件管理，運行端口設置差異，順便了解如何串接api與設計rest_api，測試api時遇到的加密認證與過濾器限制問題





