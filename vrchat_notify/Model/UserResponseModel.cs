using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using VRChatApi.Classes;
using Windows.System;
using Windows.UI.Xaml.Media.Imaging;

namespace VRChat_Notify.Model
{
    public class UserResponseModel : IDisposable
    {
        private UserResponse APIResponse { get; set; }

        public ReactiveProperty<string> Id { get; private set; }

        public ReactiveProperty<string> UserName { get; private set; }

        public ReactiveProperty<string> DisplayName { get; private set; }

        public ReactiveProperty<string> CurrentAvatarThumbnailImage { get; private set; }

        public ReactiveProperty<string> State { get; private set; }

        public ReactiveProperty<string> Status { get; private set; }

        public ReactiveProperty<string> LastLogin { get; private set; }

        private CompositeDisposable Disposable { get; } = new CompositeDisposable();

        
        public UserResponseModel(UserResponse source)
        {
            APIResponse = source;
            if (APIResponse == null) return;

            Id = new ReactiveProperty<string>(APIResponse.id).AddTo(Disposable);
            DisplayName = new ReactiveProperty<string>(APIResponse.displayName).AddTo(Disposable);
            UserName = new ReactiveProperty<string>(APIResponse.username).AddTo(Disposable);
            CurrentAvatarThumbnailImage = new ReactiveProperty<string>(APIResponse.currentAvatarThumbnailImageUrl).AddTo(Disposable);

            // UTC -> JST
            TimeZoneInfo jstZoneInfo = System.TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            DateTime jst = System.TimeZoneInfo.ConvertTimeFromUtc(APIResponse.last_login, jstZoneInfo);
            LastLogin = new ReactiveProperty<string>(jst.ToString());

            State = new ReactiveProperty<string>(APIResponse.state).AddTo(Disposable);
            Status = new ReactiveProperty<string>(APIResponse.status).AddTo(Disposable);

        }

        public void Dispose()
        {
            Disposable.Dispose();
        }
    }
}
