using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;

namespace VRChat_Notify
{
    public class MainViewModel
    {
        public ReactiveProperty<string> Hoge { get; set; }



        public MainViewModel()
        {
            Hoge = new ReactiveProperty<string>("ほげ");
        }
    }
}
