using JudgeSystem.Common;
using JudgeSystem.Data;
using JudgeSystem.Data.Seeding;
using JudgeSystem.Services.Mapping;
using JudgeSystem.Web.Configuration;
using JudgeSystem.Web.Dtos.Course;
using JudgeSystem.Web.Dtos.ML;
using JudgeSystem.Web.InputModels.Course;
using JudgeSystem.Web.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.ML;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;
// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString(GlobalConstants.DefaultConnectionStringName)));
builder.Services.AddPredictionEnginePool<UserLesson, UserLessonScore>()
                .FromFile(GlobalConstants.LessonsRrecommendationMlModelPath);

builder.Services.ConfigureIdentity()
    .ConfigureSession()
    .ConfigureDistributedSqlServerCache(configuration)
    .ConfigureLocalization()
    .ConfigureMvc()
    .ConfigureCookies()
    .ConfigureSettings(configuration)
    .AddEmailSendingService(configuration)
    .ConfigureAzureBlobStorage(configuration)
    .AddRepositories()
    .AddBusinessLogicServices()
    .AddOptions()
    .AddApplicationInsightsTelemetry();

//builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages().AddRazorRuntimeCompilation(); 

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
LocalizationConfiguration.SetDefaultCulture();
CompilersConfiguration.CreateWorkingDirectoryIfNotExists();

AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly,
    typeof(CourseInputModel).GetTypeInfo().Assembly, typeof(ContestCourseDto).GetTypeInfo().Assembly);

using (IServiceScope serviceScope = app.Services.CreateScope())
{
    ApplicationDbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    dbContext.Database.Migrate();
    new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UserLocalization();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();
app.UseCors("default");
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areaRoute",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});
app.Run();
