using ShowdownAI.Middleware.Services.Implementations;
using ShowdownAI.Middleware.Services.Interfaces;

namespace ShowdownAI.Middleware
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
            builder.Services.AddSingleton<IMoveDataLookup, MoveDataLookup>();
            builder.Services.AddSingleton<IMoveSelector, MoveSelector>();
            builder.Services.AddSingleton<IBattleTracker, BattleTracker>();
            builder.Services.AddSingleton<ITypeLookup, TypeLookup>();

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
