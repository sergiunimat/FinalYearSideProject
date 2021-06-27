using AlternativeRealEstateSolution.Interfaces;
using AlternativeRealEstateSolution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AlternativeRealEstateSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDbServices _databaseService;
        private readonly IBlockchainServices _blockchainServices;

        public HomeController(ILogger<HomeController> logger, IDbServices databaseService, IBlockchainServices blockchainServices)
        {
            _logger = logger;
            _databaseService = databaseService;
            _blockchainServices = blockchainServices;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var viewObj = new ViewListsDTO()
            {
                Events = await _databaseService.GetAllEventsAsync(),
                Properties = await _databaseService.GetAllPropertiesAsync(),
                Users = await _databaseService.GetAllUsersAsync()
            };
            return View(viewObj);
        }

        public async Task<IActionResult> AddProperty()
        {
            var testUser = new User()
            {
                Email = "owner.mail@mail.com",
                Ether = "1",
                FullName = "Property Sale Ltd.",
                PrivateAddress = "8f5370e51350f2c3b2a34a79c9b7e4f5d6899a02ae7db3d47feadee532073c38",
                PublicAddress = "0x836A666a4febd5C4BA19a1898e590492A92e97D7",
                Type = 1
            };
            var testEstateProperty = new Property()
            {
                Ether = "1",
                Description = "This is a test description of the estate property",
                GeographicalAddress = "Marsaskala",
                Id = Guid.NewGuid().ToString()

            };
            try
            {
                var response = await _blockchainServices.AddEstateProperty(testEstateProperty, testUser);
                if (response == ResponseStatus.SUCCESS)
                {
                    var applicationEvent = new Event()
                    {
                        Message = "A new estate property was successfully added with the  id (" + testEstateProperty.Id + ").",
                        TimeStamp = DateTime.Now,
                        Type = 1,
                        UserPublicAddress = testUser.PublicAddress
                    };
                    await _databaseService.AddEventAsync(applicationEvent);
                }
                else
                {
                    var applicationEvent = new Event()
                    {
                        Message = response,
                        TimeStamp = DateTime.Now,
                        Type = 0,
                        UserPublicAddress = testUser.PublicAddress
                    };
                    await _databaseService.AddEventAsync(applicationEvent);
                    //return View(Index());
                }
                return View();

            }
            catch (Exception)
            {

                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
