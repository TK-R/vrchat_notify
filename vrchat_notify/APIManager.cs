using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using VRChatApi;
using VRChatApi.Classes;
using Windows.Media.Core;

namespace VRChat_Notify
{
    public static class APIManager
    {
        public static RootAPI API { get; private set; }

        public static UserResponse CurrentUserResponse { get; private set; }

        public async static Task<bool> Initialize(string username, string password)
        {
            return await Task.Run(() =>
            {
                try
                {
                    API = new RootAPI(username, password);
                    CurrentUserResponse = API.UserApi.Login().Result;

                    if (CurrentUserResponse == null) return false;
                    
                }catch(Exception)
                {
                    return false;
                }

                return true;
            });
        }
    }
}
