using PruebaMasterLoyalty.Business.Interfaces;

namespace PruebaMasterLoyalty.API.Providers
{
    public class WebRootPathProvider : IPathProvider

    {
        private readonly IWebHostEnvironment _env;

        public WebRootPathProvider(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string GetUploadsPath()
        {
            return Path.Combine(_env.WebRootPath, "uploads");
        }

    }
}
