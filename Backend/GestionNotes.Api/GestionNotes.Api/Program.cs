using Microsoft.EntityFrameworkCore;
using GestionNotes.Api.Data;
using GestionNotes.Api.Mappings;
using GestionNotes.Api.Services.ServicesInterfaces;
using GestionNotes.Api.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Ajouter des services au conteneur.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Convertir les �num�rations en cha�nes de caract�res
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Configurer Swagger pour l'API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "GestionNotes.Api", Version = "v1" });
    // Vous pouvez ajouter un fichier XML pour documenter les commentaires si n�cessaire
    // c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "GestionNotes.Api.xml"));
});

// Ajouter la politique CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Ajouter le DbContext avec la cha�ne de connexion
builder.Services.AddDbContext<GestionNotesDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

// Configurer AutoMapper pour les mappages d'objets
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Enregistrer les services
builder.Services.AddScoped<IPreinscriptionService, PreinscriptionService>();
builder.Services.AddScoped<IPdfService, PdfService>();

var app = builder.Build();

// Configurer le pipeline de requ�tes HTTP.
if (app.Environment.IsDevelopment())
{
    // Activer Swagger en mode d�veloppement
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GestionNotes.Api v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Utiliser la politique CORS
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
