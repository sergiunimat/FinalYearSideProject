using AlternativeRealEstateSolution.Interfaces;
using AlternativeRealEstateSolution.Models;
using AlternativeRealEstateSolution.SmartContractMapping;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlternativeRealEstateSolution.Services
{
    public class BlockchainServices : IBlockchainServices
    {

        private readonly IDbServices _databaseService;

        public BlockchainServices(IDbServices databaseService)
        {
            _databaseService = databaseService;
        }

        private Web3 InitialiseConnectionWithSenderAddress(string accountPrivateAddress)
        {
            var externalProjectLink = "https://rinkeby.infura.io/v3/78bd716a98df40dd8f9d6e669254041a";
            var account = new Account(accountPrivateAddress);
            return new Web3(account, externalProjectLink);
        }

        public async Task<string> AddPropertyToChainAsync(string accountPrivate, Property propertyObj)
        {            
            var web3 = InitialiseConnectionWithSenderAddress(accountPrivate);            
            var smartContractAddress = "0xb3d687b46080f68cca9ed4f739872e7381648765";
            var _addPropertyInterdace = new AddProperty()
            {
                propertyId = propertyObj.Id,
                weiPrice = Web3.Convert.ToWei(propertyObj.Ether)
            };
            try
            {
                var _interfaceHandler = web3.Eth.GetContractTransactionHandler<AddProperty>();
                var transactionReceipt = await _interfaceHandler.SendRequestAndWaitForReceiptAsync(smartContractAddress, _addPropertyInterdace);
                return ResponseStatus.SUCCESS;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> AddEstateProperty(Property estatePropertyItem, User frameworkUserItem) 
        {           
            try
            {                
                var chainResponse = await AddPropertyToChainAsync(frameworkUserItem.PrivateAddress, estatePropertyItem);
                if (chainResponse == ResponseStatus.SUCCESS)
                {
                    await _databaseService.AddPropertyAsync(estatePropertyItem);
                    return ResponseStatus.SUCCESS;
                }
                return chainResponse;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
