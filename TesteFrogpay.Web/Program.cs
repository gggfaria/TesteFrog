using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TesteFrogpay.Domain;
using TesteFrogpay.Domain.Interfaces;
using TesteFrogpay.Infra;
using TesteFrogpay.Infra.Repositories;
using TesteFrogpay.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Teste", Version = "v1" });
    //Adição do header de autenticação no Swagger 
    c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. 
                                              Escreva 'Bearer' [espaço] e o token gerado no login na caixa abaixo.
                                              Exemplo: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                },
            },
            new List<string>()
        }
    });
});

builder.Services.AddSingleton<DbContext>
    (_ => new DbContext(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<ILojaRepository, LojaRepository>();
builder.Services.AddScoped<IDadosBancariosRespository, DadosBancariosRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<PessoaService>();
builder.Services.AddScoped<LojaService>();
builder.Services.AddScoped<EnderecoService>();
builder.Services.AddScoped<DadosBancariosRepository>();



builder.Services.AddSingleton<JwtInjection>
    (
       _=> new JwtInjection(builder.Configuration.GetSection("jwtTokenChave").Get<string>())
    );

var jwtChave = builder.Configuration.GetSection("jwtTokenChave").Get<string>();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtChave)),
        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = true
    };
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();