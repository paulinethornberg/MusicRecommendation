using System.Net.Http;

namespace MusicRecommendation.Framework
{
    public interface ISpotifyCLient
    {
        HttpClient GetDefaultClient();
    }
}
