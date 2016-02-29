using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using RepositoryMvcApplication.Entities;
using RepositoryMvcApplication.Models;

namespace RepositoryMvcApplication.Trasformation
{
    public class WidgetTrasformation : IWidgetTrasformation
    {
        public List<WidgetDto> Serialize(List<Widget> list)
        {
            Mapping mapping = new Mapping();
            List<WidgetDto> list_serialized = new List<WidgetDto>();
            IMapper mapper = mapping.ConfigureMapper();

            foreach (Widget ele in list)
            {
                WidgetDto copied = mapper.Map<Widget, WidgetDto>(ele);
                list_serialized.Add(copied);
            }

            return list_serialized.ToList();
        }

        public List<Widget> Deserialize(List<WidgetDto> list)
        {
            Mapping mapping = new Mapping();
            List<Widget> list_deserialized = new List<Widget>();
            IMapper mapper = mapping.ConfigureReverseMapper();

            if (list == null) return list_deserialized;

            foreach (WidgetDto ele in list)
            {
                Widget copied = mapper.Map<WidgetDto, Widget>(ele);
                list_deserialized.Add(copied);
            }

            return list_deserialized.ToList();    
        }

        public WidgetDto Serialize(Widget widget)
        {
            Mapping mapping = new Mapping();
            IMapper mapper = mapping.ConfigureMapper();
            WidgetDto copied = mapper.Map<Widget, WidgetDto>(widget);
            return copied;
        }

        public Widget DeSerialize(WidgetDto widget)
        {
            Mapping mapping = new Mapping();
            IMapper mapper = mapping.ConfigureMapper();
            Widget copied = mapper.Map<WidgetDto, Widget>(widget);
            return copied;
        }
    }
}