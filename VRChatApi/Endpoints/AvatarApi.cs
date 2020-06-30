using System.Net.Http;
using System.Threading.Tasks;
using VRChatApi.Classes;

namespace VRChatApi.Endpoints
{
    public class AvatarApi
    {

        public async Task<AvatarResponse> GetById(string id)
        {
            HttpResponseMessage response = await Global.HttpClient.GetAsync($"avatars/{id}?apiKey={Global.ApiKey}");
            return await Utils.ParseResponse<AvatarResponse>(response);
        }
    }
}
