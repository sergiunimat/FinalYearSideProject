using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace AlternativeRealEstateSolution.SmartContractMapping
{
    [Function("addProperty")]
    public class AddProperty : FunctionMessage
    {
        [Parameter("string", "_propertyId", 1)]
        public string propertyId { get; set; }
        [Parameter("uint", "_weiPrice", 2)]
        public BigInteger weiPrice { get; set; }
    }
}
