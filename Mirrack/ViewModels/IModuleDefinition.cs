using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirrack.ViewModels
{
    internal interface IModuleDefinition
    {
        public ViewModelBase CreateIconVM();
        public ViewModelBase CreateScrollVM();
        public ViewModelBase CreateContentVM();
        public ViewModelBase CreateROptionVM();
        public ViewModelBase CreateLOptionVM();
    }
}
