using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuitSupply.ProductCatalogRestApi.Common
{
    public class DefaultExceptionDto
    {
        public List<string> Errors { get; set; }

        public DefaultExceptionDto()
        {
            Errors = new List<string>();
        }
    }
}
