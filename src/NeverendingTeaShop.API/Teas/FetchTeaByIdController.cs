using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeverendingTeaShop.Core.Interfaces.Queries;
using NeverendingTeaShop.Domain;

namespace NeverendingTeaShop.API.Teas
{
    [ApiController]
    [Route("/teas")]
    public class FetchProductItemByIdController: Controller
    {
        private readonly IFetchTeaByIdQuery _fetchTeaByIdQuery;

        public FetchProductItemByIdController(IFetchTeaByIdQuery fetchTeaByIdQuery)
        {
            _fetchTeaByIdQuery = fetchTeaByIdQuery ?? throw new ArgumentNullException(nameof(IFetchTeaByIdQuery));
        }

        /// <summary>
        ///  Fetch Tea by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Tea>> FetchTeaById(string id)
        {
            var fetchedTea = await _fetchTeaByIdQuery.Execute(id);
            if (fetchedTea.HasValue)
            {
                return Ok(fetchedTea.GetValueOrDefault());
            }

            return NotFound($"No tea with id {id}");
        }
    }
}