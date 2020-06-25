using Reactive.Bindings;
using System;
using System.Linq;
using System.Reactive.Linq;


namespace VRChat_Notify
{
    public class AccountViewModel 
    {
        public ReactiveProperty<string> UserID { get; private set; } = new ReactiveProperty<string>();

        public ReactiveProperty<string> Password { get; private set; } = new ReactiveProperty<string>();

        public ReactiveProperty<string> LoginStatus { get; private set; } = new ReactiveProperty<string>();

        public ReactiveCommand ApplyCommand { get; private set; }

        public AccountViewModel()
        {
            ApplyCommand = new ReactiveCommand();

            ApplyCommand.Subscribe(_ =>
                LoginStatus.Value = "Login Successful!!"
            );
            LoginStatus.Value = "Not Logged In...";
        }

    }
}
