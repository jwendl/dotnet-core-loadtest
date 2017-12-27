using DotNetCore.Interfaces;
using DotNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace DotNetCore.Controllers
{
    [Route("api/[controller]")]
    public class SetupController
        : Controller
    {
        private readonly DocumentSettings documentSettings;
        private readonly IDataRepository<string, Customer> customerRepository;

        public SetupController(IOptions<DocumentSettings> options, IDataRepository<string, Customer> customerRepository)
        {
            documentSettings = options.Value;
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await customerRepository.InitializeDatabaseAsync("/address/state", documentSettings.DatabaseId, documentSettings.CollectionId);

            return Ok();
        }
    }
}
