using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryMvcApplication.Entities;
using RepositoryMvcApplication.Models;

namespace RepositoryMvcApplication.Trasformation
{
    interface IWidgetTrasformation
    {
        List<WidgetDto> Serialize(List<Widget> list);

        List<Widget> Deserialize(List<WidgetDto> list);

        WidgetDto Serialize(Widget widget);

        Widget DeSerialize(WidgetDto widget);
    }
}
