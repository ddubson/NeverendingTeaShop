using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeverendingTeaShop.Application.Interfaces.Queries;
using NeverendingTeaShop.Domain;
using static LanguageExt.Prelude;

namespace NeverendingTeaShop.API.Teas
{
    [ApiController]
    [Route("/teas")]
    public class FetchAllTeasController : ControllerBase
    {
        private readonly IFetchAllTeasQuery<JsonResult> _fetchAllTeasQuery;

        public FetchAllTeasController(IFetchAllTeasQuery<JsonResult> fetchAllTeasQuery)
        {
            _fetchAllTeasQuery = fetchAllTeasQuery;
        }

        [HttpGet]
        public async Task<ActionResult> FetchAllTeas() =>
            await _fetchAllTeasQuery.Execute(new FetchAllTeasOutcomeHandler());
    }

    public class FetchAllTeasOutcomeHandler : IFetchAllTeasOutcomes<JsonResult>
    {
        public JsonResult GotTeas(IList<Tea> teas)
        {
            throw new System.NotImplementedException();
        }
    }
}