using AlternativeRealEstateSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlternativeRealEstateSolution.Interfaces
{
    public interface IBlockchainServices
    {
        Task<string> AddPropertyToChainAsync(string accountPrivate, Property propertyObj);
        Task<string> AddEstateProperty(Property estatePropertyItem, User frameworkUserItem);
    }
}
