using System;
using Hqub.Mellody.Music.Services;
using Hqub.Mellody.Music.Services.Implementation;
using Hqub.Mellody.Music.Services.Interfaces;
using Hqub.Mellody.Web.Services;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Hqub.Mellody.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            container.RegisterType<IPlaylistService, LastfmPlaylistService>();
            container.RegisterType<IStationService, StationService>();
            container.RegisterType<ICacheService, CacheService>();
            container.RegisterType<IAccountService, AccauntService>();
            container.RegisterType<IVkontakteService, VkontakteService>();
            container.RegisterType<ILogService, LogService>();
            container.RegisterType<IConfigurationService, ConfigurationService>();
            container.RegisterType<IYoutubeService, YoutubeService>();
            container.RegisterType<ILastfmService, LastfmService>();
            container.RegisterType<IEchonestService, EchonestService>();
        }
    }
}
