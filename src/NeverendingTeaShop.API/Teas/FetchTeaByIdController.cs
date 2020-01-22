using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeverendingTeaShop.Core.Interfaces.Queries;
using NeverendingTeaShop.Domain;
using static LanguageExt.Prelude;

namespace NeverendingTeaShop.API.Teas
{
    [ApiController]
    [Route("/teas")]
    public class FetchProductItemByIdController: Controller
    {
        private readonly IFetchTeaByIdQuery _fetchTeaByIdQuery;

        public FetchProductItemByIdController(IFetchTeaByIdQuery fetchTeaByIdQuery)
        {
            _fetchTeaByIdQuery = fetchTeaByIdQuery;
        }
        
        /// <summary>
        ///  Fetch Tea by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Tea>> FetchTeaById(string id) =>
            await match(_fetchTeaByIdQuery.Execute(id),
                Right: option => match(option,
                    item => Ok(item),
                    () => StatusCode(404, "None Found")),
                Left: error => StatusCode(400, "Failed to fetch a product item")
            );
    }
}