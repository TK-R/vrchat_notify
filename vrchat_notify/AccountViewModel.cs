using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VRChat_Notify
{
    public class AccountViewModel :IDisposable
    {
        public ReactiveProperty<string> UserID { get; set; }

        public ReactiveProperty<string> Password { get; set; } 

        public ReactiveProperty<string> LoginStatus { get; set; } 

        public ReactiveProperty<bool> Waiting { get; set; }
        public ReactiveCommand ApplyCommand { get; set; }

        private CompositeDisposable Disposable { get; } = new CompositeDisposable();

        public AccountViewModel()
        {
            UserID = new ReactiveProperty<string>().AddTo(Disposable);
            Password = new ReactiveProperty<string>().AddTo(Disposable);
            LoginStatus = new ReactiveProperty<string>().AddTo(Disposable);
            Waiting = new ReactiveProperty<bool>().AddTo(Disposable);


            ApplyCommand = UserID.CombineLatest(Password, (id, password) => !string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(password))
                                 .ToReactiveCommand().AddTo(Disposable);

            ApplyCommand.Subscribe(async _ =>
            {
                await LoginCommand();
            });

            if (APIManager.CurrentUserResponse != null)
            {
                LoginStatus.Value = "Login Successful!!";
            }
            else
            {
                LoginStatus.Value = "Not Logged In...";
            }

        }

        private async Task<bool> LoginCommand()
        {
            LoginStatus.Value = "Please Wait...";
            Waiting.Value = true;

            var res = await APIManager.Initialize(UserID.Value, Password.Value);
            if (res == false)
            {
                LoginStatus.Value = "Login Faild...";
                Waiting.Value = false;
                return false;
            }

            LoginStatus.Value = "Login Successful!!";
            Waiting.Value = false;

            return true;
        }

        public void Dispose()
        {
            Disposable.Dispose();
        }
    }
}
