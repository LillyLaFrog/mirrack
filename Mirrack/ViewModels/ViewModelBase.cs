using ReactiveUI;

namespace Mirrack.ViewModels
{
    public abstract class ViewModelBase : ReactiveObject
    {
        public bool IsFocused { get; set; }
    }
}
