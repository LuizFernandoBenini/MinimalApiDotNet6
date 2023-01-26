using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MinimalApiStudy.Data;
using MinimalApiStudy.Dtos;
using MinimalApiStudy.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConnectionBuilder = new SqlConnectionStringBuilder();

sqlConnectionBuilder.ConnectionString = builder.Configuration.GetConnectionString("SQlDbConnection");
sqlConnectionBuilder.UserID = builder.Configuration["UserId"];
sqlConnectionBuilder.Password = builder.Configuration["Password"];

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(sqlConnectionBuilder.ConnectionString));
builder.Services.AddScoped<ICommandRepository, CommandRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/v1/commands", async (ICommandRepository repo, IMapper mapper) =>{
    var commands = await repo.GetAllCommands();
    return Results.Ok(mapper.Map<IEnumerable<CommandReadDto>>(commands));
});

app.MapGet("api/v1/commands/{id}", async (ICommandRepository repo, IMapper mapper, int id) =>{
    var command = await repo.GetCommandById(id);
    if (command != null)
        return Results.Ok(mapper.Map<CommandReadDto>(command));

    return Results.NotFound();
});

app.MapPost("api/v1/commands", async (ICommandRepository repo, IMapper mapper, CommandCreateDto cmdCreateDto) =>{
    var commandModel = mapper.Map<Command>(cmdCreateDto);
    await repo.CreateCommand(commandModel);
    await repo.SaveChangesAsync();
    var cmdReadDto = mapper.Map<CommandReadDto>(commandModel);

    return Results.Created($"api/v1/commands/{cmdReadDto.Id}", cmdReadDto);
});

app.MapPut("api/v1/commands/{id}", async (ICommandRepository repo, IMapper mapper, int id, CommandUpdateDto cmdUpdateDto) =>{
    var command = await repo.GetCommandById(id);
    if (command == null)
        return Results.NotFound();

    mapper.Map(cmdUpdateDto, command);

    await repo.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("api/v1/commands/{id}", async (ICommandRepository repo, IMapper mapper, int id) => {
    var command = await repo.GetCommandById(id);
    if (command == null)
        return Results.NotFound();

    repo.DeleteCommand(command);

    await repo.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();
