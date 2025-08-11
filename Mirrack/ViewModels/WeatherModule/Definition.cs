using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirrack.ViewModels.WeatherModule
{
    internal class Definition : IModuleDefinition
    {
        public ViewModelBase CreateContentVM()
        {
            return new ContentViewModel();
        }

        public ViewModelBase CreateIconVM()
        {
            return new IconViewModel();
        }

        public ViewModelBase CreateLOptionVM()
        {
            return new LOptionViewModel();
        }

        public ViewModelBase CreateROptionVM()
        {
            return new ROptionViewModel();
        }

        public ViewModelBase CreateScrollVM()
        {
            return new ScrollViewModel();
        }
    }
}
