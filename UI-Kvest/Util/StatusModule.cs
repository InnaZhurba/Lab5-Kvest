using BLL_Kvest.Interfaces;
using BLL_Kvest.Services;
using Ninject.Modules;

namespace UI_Kvest.Util
{
    public class StatusModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStatusService>().To<StatusService>();
        }
    }
}
