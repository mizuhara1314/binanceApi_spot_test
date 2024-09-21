# 1. 簡介：
測試幣安api的基礎功能，並設計後端代理interface接口可供前端使用，有最新價格，下單，查詢訂單狀態，查詢帳戶交易歷史

由於是純web_api所以用自帶的swagger_ui套件測試

**注意事項**
找到幣安Spotapi的testnet官方使用文檔或github使用文檔，找testnet的baseUrl(https://testnet.binance.vision/api)，同時注意官方文檔

Can I use the /sapi endpoints on the Spot Test Network?
No, only the /api endpoints are available on the Spot Test Network:

同時選擇不需要ip認證(不需要暴露在外網環境)的api做測試

# 2. 文件說明
**BinanceEndpoints:**  處理前端api請求的邏輯(controller)，需要寫signature確保有關帳戶請求的安全性和有效性

**BinanceService:**    與 Binance API 進行交互的邏輯

**BinanceResponse**    定義post，接收回傳資料這種需要大結構的model，其他就直接傳參數

**appsettings.json:**   環境變量設定檔，不多介紹，我把金鑰跟BaseUrl全放進去(實際上最好分開比較好)

**csproj:**          管理套件，要增加json反序列化套件，然後執行dotnet restore安裝更新

# 2. 使用流程：

**rest_api列表**

![image](https://github.com/user-attachments/assets/6d0e6cdb-c62f-4bf2-8f85-96cb4eb68190)
**取得幣種最新價格(需要前端傳入symbol參數)**

![image](https://github.com/user-attachments/assets/e317b51b-cc33-44ba-9cf6-9ff7f8b8b7b2)

**新增訂單資訊(需要前端post json)**
```json
{
  "symbol": "BTCUSDT",
  "side": "BUY",
  "type": "LIMIT",
  "quantity": 0.01,
  "price": 25000
}
```
**查詢帳戶歷史交易**



# 3. 運行項目：

在 Flask 後端項目下運行後端代碼：

```bash
python app.py  
```
使後台在port 5003運行

在 VUE 前端項目下先安裝依賴(先刪除package-lock.json)：

```bash
npm install
```

然後運行前端：

```bash
npm run serve
```

然後在瀏覽器開啟localhost即可：
# 4. 收穫：
 個人帳戶需要signature，測試api時遇到過濾器限制





