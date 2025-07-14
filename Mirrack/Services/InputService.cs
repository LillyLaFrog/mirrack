using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Input;

namespace Mirrack.Services
{
    public static class InputService
    {
        public static event Action<Key, bool>? KeyInput;
        public static event Action<Vector>? ScrollInput;

        public static void RaiseKey(Key key, bool held) => KeyInput?.Invoke(key, held);
        public static void RaiseScroll(Vector delta) => ScrollInput?.Invoke(delta);
    }
}
