using AutoMapper;

namespace API.Mappers
{
    public static class MapperConfigurationExtension
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MapperProfile());
                });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}