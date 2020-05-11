using BLL_Kvest.Interfaces;
using BLL_Kvest.Services;
using Ninject.Modules;

namespace UI_Kvest.Util
{
    public class KvestRoomModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IKvestRoomService>().To<KvestRoomService>();
        }
    }
}
