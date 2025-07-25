
using Hangfire;
using Hospital.BLL.AutoMapperConfig;
using Hospital.BLL.Configurations;
using Hospital.BLL.Repo;
using Hospital.BLL.Repo.IRepo;
using Hospital.BLL.Service;
using Hospital.BLL.Service.IService;
using Hospital.BLL.Service.TokenService;
using Hospital.DAL.Database;
using Hospital.DAL.Entities;
using Hospital.DAL.Repo.IRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Hospital.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IAppuserRepo, AppuserRepo>();
            builder.Services.AddScoped<ISalaryRepo, SalaryRepo>();
            builder.Services.AddScoped<IClinicRepo, ClinicRepo>();
            builder.Services.AddScoped<IAppointmentRepo, AppointmentRepo>();
            builder.Services.AddScoped<IRayRepo, RayRepo>();
            builder.Services.AddScoped<IRoomRepo, RoomRepo>();
            //Add Services 
            builder.Services.AddScoped<IAppointmentService, AppointmentService >();
            builder.Services.AddScoped<IAppuserService, AppuserService>();
            builder.Services.AddScoped<ISalaryService, SalaryService>();
            builder.Services.AddScoped<IClinicService, ClinicService>();
            builder.Services.AddScoped<IRayService, RayService>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<EmailService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<ITokenService, TokenService>();






            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(
               (options) =>
               {
                   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
               }

           );
            builder.Services.AddIdentity<Appuser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["JWT:Issuer"],
                        ValidAudience = builder.Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))

                    };
                });
            builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromDays(30);
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
            builder.Services.AddHangfire(config =>
            {
                config.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddHangfireServer();

            builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("EmailSettings"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseHangfireDashboard("/dashboard");


            app.MapControllers();

            app.Run();
        }
    }
}
