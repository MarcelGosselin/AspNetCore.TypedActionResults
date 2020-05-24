using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.TypedActionResults
{
    /// <summary>
    /// A type convertible to an <see cref="ActionResult{TValue}"/> that returns a Created (201) response with a Location header.
    /// </summary>
    /// <typeparam name="TValue">Type of value returned in the entity body.</typeparam>
    public class CreatedAtActionResult<TValue> : ObjectResult<TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatedAtActionResult{TValue}"/> with the values
        /// provided.
        /// </summary>
        /// <param name="actionName">The name of the action to use for generating the URL.</param>
        /// <param name="controllerName">The name of the controller to use for generating the URL.</param>
        /// <param name="routeValues">The route data to use for generating the URL.</param>
        /// <param name="value">The value to format in the entity body.</param>
        public CreatedAtActionResult(string actionName,
            string controllerName,
            object routeValues,
            TValue value)
            : base(value, StatusCodes.Status201Created)
        {
            ActionName = actionName;
            ControllerName = controllerName;
            RouteValues = routeValues;
        }

        /// <summary>
        /// Gets or sets the name of the action to use for generating the URL.
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// Gets or sets the name of the controller to use for generating the URL.
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// Gets or sets the route data to use for generating the URL.
        /// </summary>
        public object RouteValues { get; set; }

        /// <inheritdoc/>
        protected override ActionResult<TValue> ConvertToActionResultOfT()
            => new CreatedAtActionResult(ActionName, ControllerName, RouteValues, Value);
    }
}