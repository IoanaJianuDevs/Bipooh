using System.Configuration;

using Bipooh.Helpers;
namespace Bipooh.Helpers
{
    public class TokenProvider
    {
        private readonly AppSettings _appSettings;
        public TokenProvider()
        {
            _appSettings = new AppSettings();
            _appSettings.TokenSecret = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["TokenSecret"];

        }

        public string Get()
        {
            return _appSettings.TokenSecret;
        }
    }
}
