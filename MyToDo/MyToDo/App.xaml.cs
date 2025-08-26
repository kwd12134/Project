using MyToDo.Views;
using System.Windows;
using MyToDo.ViewModels;
using MyToDo.Service;
namespace MyToDo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {

        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }
        /// <summary>
        /// 告诉容器：当需要 HttpRestClient 时，构造函数里需要的 string 参数，会从容器里取 serviceKey = "webUrl" 的值。
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.GetContainer()
                .Register<HttpRestClient>(made: Parameters.Of.Type<string>(serviceKey:"webUrl"));
            containerRegistry.GetContainer().RegisterInstance(@"http://localhost:3389/", serviceKey: "webUrl");

            //当别的地方需要 IToDoService 时，容器就会自动创建 ToDoService，并且把它依赖的 HttpRestClient 也一并注入。
            containerRegistry.Register<IToDoService, ToDoService>();
            containerRegistry.Register<IMemoService, MemoService>();
            containerRegistry.Register<ILoginService, LoginService>();

            containerRegistry.RegisterForNavigation<SkinView, SkinViewModel>();
            containerRegistry.RegisterForNavigation<AboutView>();
            containerRegistry.RegisterForNavigation<IndexView, IndexViewModel>();
            containerRegistry.RegisterForNavigation<MemoView, MemoViewModel>();
            containerRegistry.RegisterForNavigation<ToDoView, ToDoViewModel>();
            containerRegistry.RegisterForNavigation<SettingView, SettingViewModel>();
        }
    }

}
