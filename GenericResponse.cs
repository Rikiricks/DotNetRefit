using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetRefit
{
    public class GenericResponse<T>
    {
        public bool IsSuccess { get; set; }
        public required T Result { get; set; }
        public required string Message { get; set; }
    }
}
