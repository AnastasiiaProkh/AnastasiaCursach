using AnastasiaDBCursach.Context;
using AnastasiaDBCursach.Services.EventType;
using AnastasiaDBCursach.Services.PositionService;
using AnastasiaDBCursach.Services.StaffService;
using AnastasiaDBCursach.Services.TicketType;
using AnastasiaDBCursach.Services;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
                      policy =>
                      {
                          policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ПрохорчукКасаКонцертноРозважальнихЗаходівContext>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<ITicketTypeService, TicketTypeService>();
builder.Services.AddScoped<IEventTypeService, EventTypeService>();
builder.Services.AddScoped<IAddvertisinAgenciesService, AddvertisinAgenciesService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IInvitationService, InvitationService>();
builder.Services.AddScoped<IRefundService, RefundService>();
builder.Services.AddScoped<IRegularCustomerService, RegularCustomerService>();
builder.Services.AddScoped<IRescheduledEventsServices, RescheduledEventsService>();
builder.Services.AddScoped<ISponsorsService, SponsorService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IGiftTicketService, GiftTicketService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
