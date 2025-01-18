using cqrs_and_mediatr.Features.Products.Commands.Create;
using cqrs_and_mediatr.Features.Products.Commands.Delete;
using cqrs_and_mediatr.Features.Products.Commands.Update;
using cqrs_and_mediatr.Features.Products.Queries.Get;
using cqrs_and_mediatr.Features.Products.Queries.List;
using cqrs_and_mediatr.Persistance;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddMediatR(confg => confg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.MapGet("/products/{id:guid}", async (Guid id, ISender mediatr) =>
{
    var product = await mediatr.Send(new GetProductQuery(id));
    if (product == null) return Results.NotFound();
    return Results.Ok(product);
});

app.MapGet("/products", async (ISender mediatr) =>
{
    var products = await mediatr.Send(new ListProductsQuery());
    if (products == null) return Results.NoContent();
    return Results.Ok(products);
});

app.MapPost("/products", async (CreateProductCommand command, ISender mediatr) =>
{
    var id = await mediatr.Send(command);
    if(Guid.Empty == id) return Results.BadRequest();
    return Results.Ok(id);
});

app.MapPut("/products", async (UpdateProductCommand command, ISender mediatr) =>
{
    var product = await mediatr.Send(command);
    if (product == null) return Results.BadRequest();
    return Results.Ok(product);
});

app.MapDelete("/products,{id:guid}", async (Guid id, ISender mediatr) =>
{
    await mediatr.Send(new DeleteProductCommand(id));
    return Results.NoContent();
});
app.UseHttpsRedirection();
app.Run();
