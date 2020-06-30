using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VRChatApi.Classes;

namespace VRChatApi.Endpoints
{
    public class ModerationsApi
    {
        public async Task<List<PlayerModeratedResponse>> GetPlayerModerations()
        {
            HttpResponseMessage response = await Global.HttpClient.GetAsync("auth/user/playermoderations");
            return await Utils.ParseResponse<List<PlayerModeratedResponse>>(response);
        }

        public async Task<List<PlayerModeratedResponse>> GetPlayerModerated()
        {
            HttpResponseMessage response = await Global.HttpClient.GetAsync("auth/user/playermoderated");
            return await Utils.ParseResponse<List<PlayerModeratedResponse>>(response);
        }
    }
}
