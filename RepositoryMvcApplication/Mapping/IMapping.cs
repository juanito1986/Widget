using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace RepositoryMvcApplication
{
    interface IMapping
    {
        IMapper ConfigureMapper();
        IMapper ConfigureReverseMapper();
    }
}
