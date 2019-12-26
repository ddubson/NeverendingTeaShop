using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeverendingTeaShop.Application.Interfaces.Queries;
using static LanguageExt.Prelude;

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
        public async Task<ActionResult> FetchAllTeas() =>
            await match(_fetchAllTeasQuery.Execute(),
                Right: option => match(option,
                    Some: Ok,
                    None: () => StatusCode(404, "None found")),
                Left: error => StatusCode(500, "Whoa! Error!"));
    }
}