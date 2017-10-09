using Autofac;
using MusicRecommendation.Mappers;
using MusicRecommendation.Mappers.Interfaces;
using MusicRecommendation.Services;
using MusicRecommendation.Services.Interfaces;

namespace MusicRecommendation.Framework.DependencyInjection
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SpotifyClient>()
              .As<ISpotifyCLient>()
              .InstancePerLifetimeScope();

            builder.RegisterType<SpotifyApiService>()
               .As<ISpotifyApiService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<SearchResultMapper>()
             .As<ISearchResultMapper>()
             .InstancePerLifetimeScope();

            builder.RegisterType<RecommendationService>()
            .As<IRecommendationService>()
            .InstancePerLifetimeScope();
        }
    }
}
