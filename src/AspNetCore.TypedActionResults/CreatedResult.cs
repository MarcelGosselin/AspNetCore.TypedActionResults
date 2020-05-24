using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.TypedActionResults
{
    /// <summary>
    /// A type convertible to an <see cref="ActionResult{TValue}"/> that returns a Created (201) response with a Location header.
    /// </summary>
    /// <typeparam name="TValue">Type of value returned in the entity body.</typeparam>
    public class CreatedResult<TValue> : LocationObjectResult<TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatedResult{TValue}"/> class with the values
        /// provided.
        /// </summary>
        /// <param name="location">The location at which the content has been created.</param>
        /// <param name="value">The value to format in the entity body.</param>
        public CreatedResult(string location, TValue value)
            : base(location, value, StatusCodes.Status201Created)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatedResult{TValue}"/> class with the values
        /// provided.
        /// </summary>
        /// <param name="locationUri">The location at which the content has been created.</param>
        /// <param name="value">The value to format in the entity body.</param>
        public CreatedResult(Uri locationUri, TValue value)
            : base(locationUri, value, StatusCodes.Status201Created)
        {
        }

        /// <inheritdoc/>
        protected override ActionResult<TValue> ConvertToActionResultOfT()
            => new CreatedResult(Location, Value);
    }
}