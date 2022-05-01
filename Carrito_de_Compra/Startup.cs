using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Carrito_de_Compra.Startup))]
namespace Carrito_de_Compra
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
