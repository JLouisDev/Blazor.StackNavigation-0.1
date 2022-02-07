using Microsoft.AspNetCore.Components;

namespace Maui.Blazor.StackNavigation
{
    public class NavStack
    {
        public NavStack(NavigationManager navMan)
        {
            NavMan = navMan;
            BNavigation = new Stack<StackItem>();
        }

        public NavigationManager NavMan { get; set; }
        public Stack<StackItem> BNavigation { get; set; }
        public bool CanGoBack => BNavigation?.Count > 0;
    }

    public class StackItem
    {
        public StackItem(string route, object viewmodel)
        {
            Route = route;
            ViewModel = viewmodel;
            ModelType = viewmodel.GetType();
        }

        public StackItem(string route)
        {
            Route = route;
        }

        public string Route { get; set; }
        public object ViewModel { get; set; }
        public Type ModelType { get; set; }
    }

    public static class NavExtensions
    {
        public static void Pop(this NavStack s)
        {
            if (s.CanGoBack)
            {
                s.BNavigation.Pop();
                s.NavMan.NavigateTo(s.BNavigation.Peek().Route);
            }
        }

        public static void Push(this NavStack s, StackItem item)
        {
            s.BNavigation.Push(item);
            s.NavMan.NavigateTo(item.Route);
        }
    }

    public static class Registration
    {
        public static void UseBlazorStackNavigation(this IServiceCollection services)
        {
            services.AddScoped<NavStack>();
        }
    }
}