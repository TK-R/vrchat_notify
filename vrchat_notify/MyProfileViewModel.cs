using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRChat_Notify.Model;
using VRChatApi.Classes;

namespace VRChat_Notify
{
    public class MyProfileViewModel
    {
        public UserResponseModel MyProfile { get; private set; }
        public MyProfileViewModel()
        {
#if DEBUG
            if (APIManager.CurrentUserResponse == null)
            {
                var source = new UserResponse();
                source.id = "hogehoge";
                source.currentAvatarThumbnailImageUrl = @"https://api.vrchat.cloud/api/1/image/file_cf2e2b67-555d-44df-be8d-5972b6329c2b/1/256";
                source.displayName = "TK-R [JP]";
                source.username = "tk-r213";
                source.last_login = DateTime.UtcNow;

                MyProfile = new UserResponseModel(source);
            }
            else
            {
                MyProfile = new UserResponseModel(APIManager.CurrentUserResponse);
            }
#else
            MyProfile = new UserResponseModel(APIManager.CurrentUserResponse);
#endif
        }

    }
}
