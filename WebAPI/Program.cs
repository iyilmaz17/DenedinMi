using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;

using DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });
builder.Services.AddControllers();

builder.Services.AddSingleton<IProductDal, EfProductDal>();
builder.Services.AddSingleton<IProductService, ProductManager>();

builder.Services.AddSingleton<ICategoryDal, EfCategoryDal>();
builder.Services.AddSingleton<ICategoryService, CategoryManager>();

builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddSingleton<IUserDal, EfUserDal>();

builder.Services.AddSingleton<ICommentDal, EfCommentDal>();
builder.Services.AddSingleton<ICommentService, CommentManager>();

builder.Services.AddSingleton<IImageDal, EfImageDal>();
builder.Services.AddSingleton<IImageService, ImageManager>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
