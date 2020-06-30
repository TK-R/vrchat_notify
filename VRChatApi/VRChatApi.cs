﻿using System;
using System.Net.Http;
using System.Text;
using VRChatApi.Endpoints;

namespace VRChatApi
{
    public class RootAPI
    {
        public RemoteConfig RemoteConfig { get; set; }
        public UserApi UserApi { get; set; }
        public FriendsApi FriendsApi { get; set; }
        public WorldApi WorldApi { get; set; }
        public ModerationsApi ModerationsApi { get; set; }
        public AvatarApi AvatarApi { get; set; }
        public FavouriteApi FavouriteApi { get; set; }

        public RootAPI(string username, string password)
        {
            // initialize endpoint classes
            RemoteConfig = new RemoteConfig();
            UserApi = new UserApi(username, password);
            FriendsApi = new FriendsApi();
            WorldApi = new WorldApi();
            ModerationsApi = new ModerationsApi();
            AvatarApi = new AvatarApi();
            FavouriteApi = new FavouriteApi();

            // initialize http client
            // TODO: use the auth cookie
            if (Global.HttpClient == null)
            {
                Global.HttpClient = new HttpClient();
                Global.HttpClient.BaseAddress = new Uri("https://api.vrchat.cloud/api/1/");
            }

            string authEncoded = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{UserApi.Username}:{UserApi.Password}"));

            var header = Global.HttpClient.DefaultRequestHeaders;

            if (header.Contains("Authorization"))
            {
                header.Remove("Authorization");
            }

            header.Add("Authorization", $"Basic {authEncoded}");
        }
    }
}
