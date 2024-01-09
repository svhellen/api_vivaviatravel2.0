using api_vivaviatravel2.Context;
using Microsoft.EntityFrameworkCore;

namespace api_vivaviatravel2._0
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

            /*            string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

                        builder.Services.AddDbContext<ApiDbContext>(options =>
                                            options.UseMySql(mySqlConnection,
                                            ServerVersion.AutoDetect(mySqlConnection)));*/

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<ApiDbContext>(
                        options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQL_DataBase"))
                    );

            builder.Services.AddCors();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
