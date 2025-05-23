using Microsoft.EntityFrameworkCore;
using Bipooh.Models;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Reflection;
using Microsoft.Extensions.Options;
using Bipooh.DataAccessLayer;

namespace Bipooh
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

            //builder.Services.AddOpenApi();
            //Adds the database context to the DI container
            //SQL Server DB
            //builder.Services.AddDbContext<CatalogueContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration["ConnectionString"],
            //    sqlServerOptionsAction: sqlOptions =>
            //    {
            //        sqlOptions.MigrationsAssembly(
            //            typeof(Program).GetTypeInfo().Assembly.GetName().Name);

            //        //Configuring Connection Resiliency: 
            //        sqlOptions.
            //            EnableRetryOnFailure(maxRetryCount: 5,
            //            maxRetryDelay: TimeSpan.FromSeconds(30),
            //            errorNumbersToAdd: null);
            //    });
            //    // Changing default behavior when client evaluation occurs to throw. 
            //    // Default in EFCore would be to log warning when client evaluation is done. 
            //    options.ConfigureWarnings(warnings => warnings.Throw(
            //    RelationalEventId.QueryClientEvaluationWarning));
            //});
            //builder.Services.AddDbContext<CatalogueContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration["ConnectionString"],
            //    sqlServerOptionsAction: sqlOptions =>
            //    {
            //        sqlOptions.MigrationsAssembly(
            //            typeof(Program).GetTypeInfo().Assembly.GetName().Name);

            //        //Configuring Connection Resiliency: 
            //        sqlOptions.
            //            EnableRetryOnFailure(maxRetryCount: 5,
            //            maxRetryDelay: TimeSpan.FromSeconds(30),
            //            errorNumbersToAdd: null);
            //    });
            //    // Changing default behavior when client evaluation occurs to throw. 
            //    // Default in EFCore would be to log warning when client evaluation is done. 
            //    options.ConfigureWarnings(warnings => warnings.Throw(
            //    RelationalEventId.QueryClientEvaluationWarning));
            //});
            builder.Services.AddDbContext<CatalogueContext>(opt =>
                //Specifies that the database context will use an in -memory database
                opt.UseInMemoryDatabase("CatalogueList"));
            builder.Services.AddDbContext<StudentContext>(opt =>
                opt.UseInMemoryDatabase("StudentList"));
            builder.Services.AddDbContext<SubjectContext>(opt =>
                opt.UseInMemoryDatabase("SubjectList"));

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

            ///////////////////////////////
            ///
            app.MapGet("/studentitems", async (StudentContext dbStudent) =>
                    await dbStudent.StudentItems.ToListAsync());

            //app.MapGet("/Catalogueitems/complete", async (CatalogueContext db) =>
            //        await db.CataloguesItems.Where(t => t.IsComplete).ToListAsync());

            app.MapGet("/studentitems/{id}", async (long id, StudentContext dbStudent) =>
                    await dbStudent.StudentItems.FindAsync(id)
                        is Student student
                            ? Results.Ok(student)
                            : Results.NotFound());
            app.MapGet("/studentitems/{name}", async (string name, StudentContext dbStudent) =>
                    await dbStudent.StudentItems.FindAsync(name)
                        is Student student
                            ? Results.Ok(student)
                            : Results.NotFound());

            app.MapPost("/studentitems", async (Student student, StudentContext dbStudent) =>
            {
                dbStudent.StudentItems.Add(student);
                await dbStudent.SaveChangesAsync();

                return Results.Created($"/studentitems/{student.Id}", student);
            });

            app.MapPut("/studentitems/{id}", async (long id, Student inputStudent, StudentContext dbStudent) =>
            {
                var student = await dbStudent.StudentItems.FindAsync(id);

                if (student is null) return Results.NotFound();

                student.FirstName = inputStudent.FirstName;
                student.LastName = inputStudent.LastName;

                await dbStudent.SaveChangesAsync();

                return Results.NoContent();
            });

            app.MapDelete("/studentitems/{id}", async (long id, StudentContext dbStudent) =>
            {
                if (await dbStudent.StudentItems.FindAsync(id) is Student student)
                {
                    dbStudent.StudentItems.Remove(student);
                    await dbStudent.SaveChangesAsync();
                    return Results.NoContent();
                }

                return Results.NotFound();
            });

            //CatalogueS
            app.MapGet("/Catalogueitems", async (CatalogueContext db) =>
                    await db.CatalogueItems.ToListAsync());

            //app.MapGet("/Catalogueitems/complete", async (CatalogueContext db) =>
            //        await db.CatalogueItems.Where(t => t.IsComplete).ToListAsync());

            app.MapGet("/Catalogueitems/{id}", async (long id, CatalogueContext db) =>
                    await db.CatalogueItems.FindAsync(id)
                        is Catalogue Catalogue
            ? Results.Ok(Catalogue)
                            : Results.NotFound());

            app.MapPost("/Catalogueitems", async (Catalogue Catalogue, CatalogueContext db) =>
            {
                db.CatalogueItems.Add(Catalogue);
                await db.SaveChangesAsync();

                return Results.Created($"/Catalogueitems/{Catalogue.Id}", Catalogue);
            });

            app.Run();
        }
    }
}

