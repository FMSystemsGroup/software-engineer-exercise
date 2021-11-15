var builder = WebApplication.CreateBuilder(args);

// Add services to container
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
   options.SwaggerDoc(name: "v1", info: new OpenApiInfo
   { Title = "City API", Version = "v1" })
);

var app = builder.Build();

// Controllers no longer necessary in ".Net 6 Minimal API"

CityEndpoints.DefineEndpoints(app);

// Add middleware pipeline

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.UseSwagger();
app.UseSwaggerUI(c =>{
    c.SwaggerEndpoint("/swagger/v1/swagger.json",
        "City API Version 1");

    c.SupportedSubmitMethods(new[]{
        SubmitMethod.Get, SubmitMethod.Post,
        SubmitMethod.Put, SubmitMethod.Delete});
});

app.Run();