using School.API.Context;
using School.API.Helper.Student.Strategy.Strategies;
using School.API.Helper.Student.Strategy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews(opt => opt.SuppressAsyncSuffixInActionNames = false);
//builder.Services.AddMvc(opt => opt.SuppressAsyncSuffixInActionNames = false);
//builder.Services.AddMvcCore(opt => opt.SuppressAsyncSuffixInActionNames = false);

builder.Services.AddControllers();
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SchoolContext>();
builder.Services.AddScoped<IValidateStudentStrategy, MinNameLengthStrategy>();
builder.Services.AddScoped<IValidateStudentStrategy, MaxNameLengthStrategy>();
builder.Services.AddScoped<IValidateStudentStrategy, IsLegalAgeStrategy>();
builder.Services.AddScoped<IValidateStudentFactoryStrategy, ValidateStudentFactoryStrategy>();
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
