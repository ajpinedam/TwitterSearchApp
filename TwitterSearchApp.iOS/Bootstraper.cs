using System;
using TwitterSearchApp.Core;

namespace TwitterSearchApp.iOS
{
    public static class Bootstraper
    {
        public static void Init ()
        {
            RegisterServices ();
            RegisterRepositories ();
            RegisterViewModels ();
        }

        static void RegisterServices ()
        {
            TinyIoC.TinyIoCContainer.Current.Register<IApiClient, ApiClient> ();
        }

        static void RegisterRepositories ()
        {
            TinyIoC.TinyIoCContainer.Current.Register<ISearchRepository, SearchRepository> ();
        }

        static void RegisterViewModels ()
        {
            TinyIoC.TinyIoCContainer.Current.Register<SearchViewModel, SearchViewModel> ();
        }
    }
}
