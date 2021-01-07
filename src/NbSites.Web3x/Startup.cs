using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NbSites.Web.Libs.PlaySounds;
using NbSites.Web.Libs.TextSpeech;

namespace NbSites.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPlaySoundFileRepository, PlaySoundFileRepository>();
            //services.AddSingleton<ISoundPlayer, MediaSoundPlayer>();
            services.AddSingleton<ISoundPlayer, NAudioSoundPlayer>();
            services.AddSingleton<ITextSpeaker, TextSpeaker>();
            
            services.AddSingleton<ServerPathHelper>();
            services.AddTransient<PlaySoundAppService>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
