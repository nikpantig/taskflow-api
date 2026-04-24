using FluentValidation;
using TaskFlow.API.Middlewares;
using TaskFlow.API.Repositories.Implementations;
using TaskFlow.API.Repositories.Interfaces;
using TaskFlow.API.Services.Implementations;
using TaskFlow.API.Services.Interfaces;
using TaskFlow.API.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateTaskItemDtoValidator>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();