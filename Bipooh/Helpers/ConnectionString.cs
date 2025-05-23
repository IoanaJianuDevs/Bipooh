using Bipooh.Services;

namespace Bipooh.Helpers
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly AppSettings _appSettings;
        private IConfiguration _configuration;
        public ConnectionStringProvider(AppSettings appSettings, IConfiguration configuration)
        {
            _appSettings = appSettings;
            _configuration = configuration;
        }

        public string Get()
        {
            return _configuration.GetConnectionString(name: _appSettings.ConnectionStringName);
        }
    }
}
