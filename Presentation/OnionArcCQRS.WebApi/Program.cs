using MediatR;
using OnionArcCQRS.Application.Features.CQRS.Handlers.AboutHandlers;
using OnionArcCQRS.Application.Features.CQRS.Handlers.BannerHandlers;
using OnionArcCQRS.Application.Features.CQRS.Handlers.BrandHandlers;
using OnionArcCQRS.Application.Features.CQRS.Handlers.CarHandlers;
using OnionArcCQRS.Application.Features.CQRS.Handlers.CategoryHandlers;
using OnionArcCQRS.Application.Features.CQRS.Handlers.ContactHandlers;
using OnionArcCQRS.Application.Features.RepositoryPattern;
using OnionArcCQRS.Application.Interfaces;
using OnionArcCQRS.Application.Interfaces.BlogInterfaces;
using OnionArcCQRS.Application.Interfaces.CarInterfaces;
using OnionArcCQRS.Application.Interfaces.CarPricingInterfaces;
using OnionArcCQRS.Application.Interfaces.RentACarInterfaces;
using OnionArcCQRS.Application.Interfaces.StatisticsInterfaces;
using OnionArcCQRS.Application.Interfaces.TagCloudInterfaces;
using OnionArcCQRS.Application.Services;
using OnionArcCQRS.Domain.Entities;
using OnionArcCQRS.Persistence.Context;
using OnionArcCQRS.Persistence.Repositories;
using OnionArcCQRS.Persistence.Repositories.BlogRepositories;
using OnionArcCQRS.Persistence.Repositories.CarPricingRepositories;
using OnionArcCQRS.Persistence.Repositories.CarRepository;
using OnionArcCQRS.Persistence.Repositories.CommentRepositories;
using OnionArcCQRS.Persistence.Repositories.RentACarRepositories;
using OnionArcCQRS.Persistence.Repositories.StatisticsRepositories;
using OnionArcCQRS.Persistence.Repositories.TagCloudRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository),typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository),typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository),typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository),typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(IStatisticsRepository),typeof(StatisticsRepository));
builder.Services.AddScoped(typeof(IRentACarRepository),typeof(RentACarRepository));
 

builder.Services.AddControllers();
#region about
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
#endregion

#region banner
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();

#endregion

#region Brand
builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandGetByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
#endregion

#region Car
builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarWithBrandQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
#endregion

#region Category
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
#endregion

#region Contact
builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
#endregion

// mediatr için dependency injection iþlemi
builder.Services.AddApplicationService(builder.Configuration);




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
