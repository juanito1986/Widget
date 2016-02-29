using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RepositoryMvcApplication.Models
{
    [Serializable()]
    public class WidgetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public Nullable<double> Price { get; set; }
    }
}