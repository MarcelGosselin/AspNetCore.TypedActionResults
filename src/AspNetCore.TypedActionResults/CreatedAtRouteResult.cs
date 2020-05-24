using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.TypedActionResults
{
    /// <summary>
    /// A type convertible to an <see cref="ActionResult{TValue}"/> that returns a Created (201) response with a Location header.
    /// </summary>
    /// <typeparam name="TValue">Type of value returned in the entity body.</typeparam>
    public class CreatedAtRouteResult<TValue> : ObjectResult<TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatedAtRouteResult{TValue}"/> class with the values
        /// provided.
        /// </summary>
        /// <param name="routeName">The name of the route to use for generating the URL.</param>
        /// <param name="routeValues">The route data to use for generating the URL.</param>
        /// <param name="value">The value to format in the entity body.</param>
        public CreatedAtRouteResult(string routeName,
            object routeValues,
            TValue value)
            : base(value, StatusCodes.Status201Created)
        {
            RouteName = routeName;
            RouteValues = routeValues;
        }

        /// <summary>
        /// Gets or sets the name of the route to use for generating the URL.
        /// </summary>
        public string RouteName { get; set; }

        /// <summary>
        /// Gets or sets the route data to use for generating the URL.
        /// </summary>
        public object RouteValues { get; set; }

        /// <inheritdoc/>
        protected override ActionResult<TValue> ConvertToActionResultOfT()
            => new CreatedAtRouteResult(RouteName, RouteValues, Value);
    }
}