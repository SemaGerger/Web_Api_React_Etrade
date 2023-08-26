using Mvc_Api_Etrade.Dal;
using Microsoft.EntityFrameworkCore;
using Mvc_Api_Etrade.DTO;
using Mvc_Api_Etrade.Repository.Abstract;
using Mvc_Api_Etrade.Repository.Concretes;
using Mvc_Api_Etrade.Response;
using Mvc_Api_Etrade.UoW;
using Mvc_Api_Etrade.Entity;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);




//Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Context
builder.Services.AddDbContext<PerContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connect")));

//Add Response
builder.Services.AddScoped<UserResponse>();
builder.Services.AddScoped<GeneralResponse>();

//Add DTO
builder.Services.AddScoped<LoginDTO>();
builder.Services.AddScoped<ProductsDTO>();
builder.Services.AddScoped<BasketDetailDTO>();
builder.Services.AddScoped<BasketMasterDTO>();

//Add Repos
builder.Services.AddScoped<IUserRepos, UserRepos>();
builder.Services.AddScoped<IProduct, ProductRepos>();
builder.Services.AddScoped<ICategory, CategoryRepos>();
builder.Services.AddScoped<ISupplier, SupplierRepos>();
builder.Services.AddScoped<IBasketMaster, BasketMasterRepos>();
builder.Services.AddScoped<IBasketDetail, BasketDetailRepos>();


//Add UoW
builder.Services.AddScoped<IUoW, UoW>();

//Add Entity
builder.Services.AddScoped<User>();
builder.Services.AddScoped<BasketMaster>();
builder.Services.AddScoped<BasketDetail>();
builder.Services.AddScoped<Category>();
builder.Services.AddScoped<Product>();
builder.Services.AddScoped<Supplier>();


var app = builder.Build();

    // Cors HTTP pipeline
    app.UseCors();





using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var uow = services.GetRequiredService<IUoW>();

    // Defoult'larý eklemek için:
    uow._userRepos.AddDefaultUser();
    uow._categoryRepos.AddDefaultCategory();
    uow._supplierRepos.AddDefaultSupplier();
    uow._productRepos.AddDefaultProducts();
    uow._basketMasterRepos.AddDefaultBasket();
    
    // Commit iþlemi gerçekleþtirilmeli
    //uow.Commit();
}








// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //Cors
    app.UseDeveloperExceptionPage();
    
    //Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
