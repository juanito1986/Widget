using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedisCache;
using RepositoryMvcApplication.Entities;
using RepositoryMvcApplication.Models;
using Repository;
//using RepositoryMvcApplication.Trasformation;

namespace RepositoryMvcApplication.Cache
{
    public class Multiplexer : IMultiplexer
    {
        private IRepository<Widget> repo = null;
        private DataTestEntities m_Context = null;
        private IRedisCache rd = null;

        public Multiplexer() 
        {
            m_Context = new DataTestEntities();
            repo = new Repository<Widget>(m_Context);
            rd = new RedisCache();
        }

        public Widget GetWidget(int id) 
        {
             Widget wd = rd.GetWidget(id);
             if(wd != null) return wd;
                return repo.Get(item => item.Id == id);
        }

        public List<Widget> GetWidgetsList() 
        {
            List<Widget> list = rd.GetWidgetsList();

            if (list == null || (list.Count == 0))
            {
                list = repo.GetAll().ToList();
                SetWidgetList(list);
            }

            return list;
        }

        public void SetWidgetList(List<Widget> list)
        {
            foreach(Widget widget in list)
            {
                rd.AddWidget(widget);
            }
        }

        public void AddWidget(Widget w) 
        {
            repo.Add(w);
            repo.Save();
            rd.AddWidget(w);
        }

        public void UpdateWidget(Widget w) 
        {
            repo.Update(w);
            repo.Save();
            rd.UpdateWidget(w);
        }

        public void DeleteWidget(Widget w) 
        {
            Widget findWidget = repo.Get(item => item.Id == w.Id);
            repo.Delete(findWidget);
            rd.DeleteWidget(findWidget);
            repo.Save();
        }
    }
}