using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryMvcApplication.Cache;
using RepositoryMvcApplication.Entities;

namespace UnitTestProject
{
    [TestClass] 
    public class WidgetTest
    {
        //public DataTestEntities db = new DataTestEntities();
        public IMultiplexer mul = new Multiplexer();

        [TestMethod]
        public void GetWidget()
        {
           Widget w = mul.GetWidget(5003);
           
            Assert.AreEqual(w.Name, "Italy");
            Assert.AreEqual(w.Category, "Europe");
            Assert.AreEqual(w.Price, 5000);
            
        }
    }
}
