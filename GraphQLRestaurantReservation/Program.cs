using Application.Interfaces;
using Application.Mutations;
using Application.Queries;
using Application.Schema;
using Application.Types;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Infrastructure.DatabaseContext;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IMenuRepository, MenuRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IReservationRepository, ReservationRepository>();

builder.Services.AddTransient<MenuType>();
builder.Services.AddTransient<CategoryType>();
builder.Services.AddTransient<ReservationType>();

builder.Services.AddTransient<MenuQuery>();
builder.Services.AddTransient<CategoryQuery>();
builder.Services.AddTransient<ReservationQuery>();
builder.Services.AddTransient<RootQuery>();

builder.Services.AddTransient<MenuMutation>();
builder.Services.AddTransient<CategoryMutation>();
builder.Services.AddTransient<ReservationMutation>();
builder.Services.AddTransient<RootMutation>();

builder.Services.AddTransient<CategoryInputType>();
builder.Services.AddTransient<MenuInputType>();
builder.Services.AddTransient<ReservationInputType>();

builder.Services.AddTransient<ISchema, RootSchema>();

builder.Services.AddGraphQL(b => b.AddAutoSchema<ISchema>().AddSystemTextJson());

builder.Services.AddDbContext<GraphQLDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("GraphqlConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseGraphiQl("/graphql");
app.UseGraphQL<ISchema>();

app.UseAuthorization();

app.MapControllers();

app.Run();
