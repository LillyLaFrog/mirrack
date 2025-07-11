using Mirrack.Models;
using ReactiveUI;
using System.ComponentModel;

namespace Mirrack.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private string _greeting = "hello world!";
        public string Greeting {
            get => _greeting;
            set {
                this.RaiseAndSetIfChanged(ref _greeting, value);
            }
        }
    }
}
