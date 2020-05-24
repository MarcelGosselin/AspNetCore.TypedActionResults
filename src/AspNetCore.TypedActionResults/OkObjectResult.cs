using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.TypedActionResults
{
    /// <summary>
    /// A type convertible to an <see cref="ActionResult{TValue}"/> that returns a OK (200).
    /// </summary>
    /// <typeparam name="TValue">Type of value returned in the entity body.</typeparam>
    public class OkObjectResult<TValue> : ObjectResult<TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OkObjectResult{TValue}"/> class.
        /// </summary>
        /// <param name="value">The content to format into the entity body.</param>
        public OkObjectResult(TValue value)
            : base(value, StatusCodes.Status200OK)
        {
        }
    }
}