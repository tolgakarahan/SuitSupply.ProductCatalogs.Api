using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuitSupply.ProductCatalogRestApi.Common
{
    public class UpdateCommandIdentityException : Exception
    {
        public UpdateCommandIdentityException(string name, int requestedId, int postedId)
            : base($"Requested identity {name}/{requestedId} does not match with posted data identity \"{postedId}\" ")
        {
        }
    }
}
