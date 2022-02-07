using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackNavigation.Core.Utils
{
    public class NavStack
    {
        public NavStack(NavigationManager navMan)
        {
            NavMan = navMan;
        }

        public NavigationManager NavMan { get; set; }
        public Stack<StackItem>? BNavigation { get; set; }
        public bool CanGoBack => BNavigation?.Count > 1;
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
        public object? ViewModel { get; set; }
        public Type? ModelType { get; set; }
    }

    public static class NavExtensions
    {
        public static StackItem? Pop(this NavStack s)
        {
            if(s.CanGoBack) { return s.BNavigation?.Pop(); }
            return null;
        }

        public static void Push(this NavStack s, StackItem item)
        {
            s.BNavigation?.Push(item);
            s.NavMan.NavigateTo(item.Route);
        }
    }

    public static class Registration
    {
        public static void UseBlazorStackNavigation(this IServiceCollection services)
        {
            services.AddSingleton<NavStack>();
        }
    }

}
