using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeverendingTeaShop.Core.Interfaces.Queries;

namespace NeverendingTeaShop.API.Teas
{
    [ApiController]
    [Route("/teas")]
    public class FetchAllTeasController : ControllerBase
    {
        private readonly IFetchAllTeasQuery _fetchAllTeasQuery;

        public FetchAllTeasController(IFetchAllTeasQuery fetchAllTeasQuery)
        {
            _fetchAllTeasQuery = fetchAllTeasQuery;
        }

        [HttpGet]
        public async Task<ActionResult> FetchAllTeas() => Ok(await _fetchAllTeasQuery.Execute());
    }
}