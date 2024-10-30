
using Application;
using Domain.Interfaces;
using Infrastructure.Repositories;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<CreateProductCommandHandler>();
            builder.Services.AddScoped<GetProductByIdQueryHandler>();
            builder.Services.AddScoped<GetAllProductsQueryHandler>(); 
            builder.Services.AddScoped<UpdateProductCommandHandler>();
            builder.Services.AddScoped<DeleteProductCommandHandler>(); 
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
