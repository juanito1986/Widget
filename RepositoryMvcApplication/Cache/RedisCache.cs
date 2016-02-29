using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using RedisCache;
using RepositoryMvcApplication;
using RepositoryMvcApplication.Entities;
using RepositoryMvcApplication.Models;
using RepositoryMvcApplication.Trasformation;
using RepositoryMvcApplication.Cache;

namespace RepositoryMvcApplication
{
    public class RedisCache : IRedisCache
    {
        //private DataTestEntities m_Context = null;
        private IWidgetTrasformation widgetTrasformation = null;
        //private List<Widget> ;
        //private IMultiplexer mul = null;

        public RedisCache()
        {
            //m_Context = new DataTestEntities();
            widgetTrasformation = new WidgetTrasformation();
            //mul = new Multiplexer();
        }

        public List<Widget> GetWidgetsList()
        {
            List<Widget> list = widgetTrasformation.Deserialize(StackExchangeRedisExtensions.GetList<WidgetDto>("list"));
            return list;
        }

        public void AddWidget(Widget widget)
        {
            List<Widget> list = this.GetWidgetsList();
            if (list == null)
                list = new List<Widget>();
            list.Add(widget);
            StackExchangeRedisExtensions.SetList("list", widgetTrasformation.Serialize(list));
        }

        public Widget GetWidget(int id) 
        {
            if (StackExchangeRedisExtensions.GetList<WidgetDto>("list").SingleOrDefault(w => w.Id == id) != null)
                return widgetTrasformation.DeSerialize(StackExchangeRedisExtensions.GetList<WidgetDto>("list").SingleOrDefault(w => w.Id == id));
            return null;
        }

        public void UpdateWidget(Widget widget)
        {
            List<WidgetDto> list = StackExchangeRedisExtensions.
                    GetList<WidgetDto>("list");
            if (list.SingleOrDefault(w => w.Id == widget.Id) != null)
            {
                list = StackExchangeRedisExtensions.
                    GetList<WidgetDto>("list");

                list.
                    SingleOrDefault(w => w.Id == widget.Id).
                    Category = widget.Category;
                list.
                    SingleOrDefault(w => w.Id == widget.Id).
                    Name = widget.Name;
                list.
                    SingleOrDefault(w => w.Id == widget.Id).
                    Price = widget.Price;

                StackExchangeRedisExtensions.SetList<WidgetDto>("list", list);
                
            } 
        }

        public void DeleteWidget(Widget widget)
        {
            List<WidgetDto> list = StackExchangeRedisExtensions.GetList<WidgetDto>("list");

            if (list.SingleOrDefault(w => w.Id == widget.Id) != null)
            {
                list.Remove(list.SingleOrDefault(w => w.Id == widget.Id));

                StackExchangeRedisExtensions.SetList<WidgetDto>("list", list);
            }
        }

    }
}