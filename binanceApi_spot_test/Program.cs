using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBinanceApiProject.Services;

var builder = WebApplication.CreateBuilder(args);

// 加入 BinanceService 到 DI 容器
builder.Services.AddScoped<BinanceService>();

// 註冊 Controllers
builder.Services.AddControllers();

// 加入 Swagger，用於API測試和文件生成 (可選)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 如果開發環境，使用Swagger (可選)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 配置中間件
app.UseHttpsRedirection();
app.UseAuthorization();

// 設置路由
app.MapControllers();

// 啟動應用
app.Run();
