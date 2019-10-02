using System;
using System.Threading.Tasks;
using CK.Tutorial.GraphQlApi.Common.Model;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CK.Tutorial.GraphQlApi.Web.Controllers
{
    [Route("graphql")]
    public class GraphQlController : ControllerBase
    {
        private readonly ILogger _logger;

        public GraphQlController(IDocumentExecuter documentExecuter,
            ISchema schema,
            ILogger<GraphQlController> logger)
        {
            DocumentExecuter = documentExecuter;
            Schema = schema;
            _logger = logger;
        }

        private IDocumentExecuter DocumentExecuter { get; }
        private ISchema Schema { get; }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQlQuery query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            var executionOptions = new ExecutionOptions
            {
                Schema = Schema,
                Query = query.Query
            };

            try
            {
                var result = await DocumentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

                if (result.Errors?.Count > 0)
                {
                    _logger.LogError("GraphQL errors: {0}", result.Errors);
                    return BadRequest(result);
                }

                _logger.LogDebug("GraphQL execution result: {result}", JsonConvert.SerializeObject(result.Data));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Document executer exception", ex);
                return BadRequest(ex);
            }
        }
    }
}