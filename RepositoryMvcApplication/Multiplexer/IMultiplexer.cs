using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryMvcApplication;
using RepositoryMvcApplication.Entities;

namespace RepositoryMvcApplication.Cache
{
    public interface IMultiplexer
    {
        Widget GetWidget(int id);
        List<Widget> GetWidgetsList();
        void AddWidget(Widget w);
        void UpdateWidget(Widget w);
        void DeleteWidget(Widget w);
        void SetWidgetList(List<Widget> list);
    }
}
