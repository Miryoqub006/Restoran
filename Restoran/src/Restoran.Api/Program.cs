using Microsoft.EntityFrameworkCore;
using Restaurant.Api.Data;
using Restaurant.Api.Repositories;
using Restaurant.Api.Services;
using Serilog;

namespace Restaurant.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Bootstrap logger: DI qurilishidan oldin, ilovaning eng boshidagi
            // xatolarni ham ushlab qolish uchun vaqtinchalik logger.
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateBootstrapLogger();

            try
            {
                Log.Information("Restaurant API ishga tushmoqda...");

                var builder = WebApplication.CreateBuilder(args);

                // Serilog'ni to'liq sozlamasini appsettings.json dagi "Serilog" seksiyasidan o'qiymiz.
                builder.Host.UseSerilog((context, services, configuration) => configuration
                    .ReadFrom.Configuration(context.Configuration)
                    .ReadFrom.Services(services)
                    .Enrich.FromLogContext());

                builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

                builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
                builder.Services.AddScoped<IFoodRepository, FoodRepository>();
                builder.Services.AddScoped<ICategoryService, CategoryService>();
                builder.Services.AddScoped<IFoodService, FoodService>();

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                var app = builder.Build();

                // Har bir HTTP so'rovni bitta ixcham satrda log qiladi.
                app.UseSerilogRequestLogging();

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
            catch (Exception ex)
            {
                Log.Fatal(ex, "Restaurant API kutilmaganda to'xtab qoldi");
            }
            finally
            {
                // Bufferdagi loglarni faylga yozib, loggerni to'g'ri yopamiz.
                Log.CloseAndFlush();
            }
        }
    }
}
