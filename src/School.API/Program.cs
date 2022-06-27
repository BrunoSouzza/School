using School.API.Context;
using School.API.Helper.Student.Strategy.Strategies;
using School.API.Helper.Student.Strategy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SchoolContext>();
builder.Services.AddScoped<IValidateStudentStrategy, MinNameLengthStrategy>();
builder.Services.AddScoped<IValidateStudentStrategy, MaxNameLengthStrategy>();
builder.Services.AddScoped<IValidateStudentFactoryStrategy, ValidateStudentFactoryStrategy>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
