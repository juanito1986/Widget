using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepositoryMvcApplication.Entities;

namespace RepositoryMvcApplication
{
    interface IRedisCache
    {
        List<Widget> GetWidgetsList();
        void AddWidget(Widget widget);
        Widget GetWidget(int id);
        void UpdateWidget(Widget widget);
        void DeleteWidget(Widget widget);
    }
}
