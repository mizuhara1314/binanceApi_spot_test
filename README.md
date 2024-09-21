# 1. 簡介：
  具有圖像平滑，圖像增強以及邊緣檢測的圖像處理網站，基於vue+flask
# 2. 效果：
![image](https://github.com/user-attachments/assets/694b0503-640d-455a-ab05-8c70e6639219)

![image](https://github.com/user-attachments/assets/5ecb7f95-52df-4ae4-98cc-5cc58b975449)


![image](https://github.com/user-attachments/assets/bae6d998-12e2-4453-bcf4-d961238ce8f3)

![image](https://github.com/user-attachments/assets/336cb0b1-7274-45b2-b032-72d400aac688)



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
# 4. 缺點：
   cv2.imread讀取中文名稱的檔案會出錯，後續會持續改良





