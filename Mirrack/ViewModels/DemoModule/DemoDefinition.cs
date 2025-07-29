using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mirrack.ViewModels.DemoModule;

namespace Mirrack.ViewModels.DemoModule
{
    internal class DemoDefinition : IModuleDefinition
    {
        public ViewModelBase CreateContentVM()
        {
            return new DemoContentViewModel();
        }

        public ViewModelBase CreateIconVM()
        {
            return new DemoIconViewModel();
        }

        public ViewModelBase CreateLOptionVM()
        {
            return new DemoLOptionViewModel();
        }

        public ViewModelBase CreateROptionVM()
        {
            return new DemoROptionViewModel();
        }

        public ViewModelBase CreateScrollVM()
        {
            return new DemoScrollViewModel();
        }
    }
}
