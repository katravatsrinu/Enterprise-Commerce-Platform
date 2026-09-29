using Discount.Core.Repositories;
using Discount.Infrastructure.Data;
using Discount.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Discount.Application.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DiscountContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DiscountConnection")));

builder.Services.AddScoped<ICouponRepository, CouponRepository>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetCouponHandler).Assembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();