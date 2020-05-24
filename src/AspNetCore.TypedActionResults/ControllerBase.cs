using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.TypedActionResults
{
    public class ControllerBase
        : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Creates an <see cref="OkObjectResult{TValue}"/> object that produces an <see cref="StatusCodes.Status200OK"/> response.
        /// </summary>
        /// <param name="value">The content value to format in the entity body.</param>
        /// <returns>The created <see cref="OkObjectResult{TValue}"/> for the response.</returns>
        [NonAction]
        public virtual OkObjectResult<TValue> Ok<TValue>(TValue value)
            => new OkObjectResult<TValue>(value);

        /// <summary>
        /// Creates a <see cref="CreatedResult{TValue}"/> object that produces a <see cref="StatusCodes.Status201Created"/> response.
        /// </summary>
        /// <param name="uri">The URI at which the content has been created.</param>
        /// <param name="value">The content value to format in the entity body.</param>
        /// <returns>The created <see cref="CreatedResult{TValue}"/> for the response.</returns>
        [NonAction]
        public virtual CreatedResult<TValue> Created<TValue>(string uri, TValue value)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            return new CreatedResult<TValue>(uri, value);
        }

        /// <summary>
        /// Creates a <see cref="CreatedResult{TValue}"/> object that produces a <see cref="StatusCodes.Status201Created"/> response.
        /// </summary>
        /// <param name="uri">The URI at which the content has been created.</param>
        /// <param name="value">The content value to format in the entity body.</param>
        /// <returns>The created <see cref="CreatedResult{TValue}"/> for the response.</returns>
        [NonAction]
        public virtual CreatedResult<TValue> Created<TValue>(Uri uri, TValue value)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            return new CreatedResult<TValue>(uri, value);
        }

        /// <summary>
        /// Creates a <see cref="CreatedAtActionResult{TValue}"/> object that produces a <see cref="StatusCodes.Status201Created"/> response.
        /// </summary>
        /// <param name="actionName">The name of the action to use for generating the URL.</param>
        /// <param name="value">The content value to format in the entity body.</param>
        /// <returns>The created <see cref="CreatedAtActionResult{TValue}"/> for the response.</returns>
        [NonAction]
        public virtual CreatedAtActionResult<TValue> CreatedAtAction<TValue>(string actionName, TValue value)
            => CreatedAtAction<TValue>(actionName, routeValues: null, value: value);

        /// <summary>
        /// Creates a <see cref="CreatedAtActionResult{TValue}"/> object that produces a <see cref="StatusCodes.Status201Created"/> response.
        /// </summary>
        /// <param name="actionName">The name of the action to use for generating the URL.</param>
        /// <param name="routeValues">The route data to use for generating the URL.</param>
        /// <param name="value">The content value to format in the entity body.</param>
        /// <returns>The created <see cref="CreatedAtActionResult{TValue}"/> for the response.</returns>
        [NonAction]
        public virtual CreatedAtActionResult<TValue> CreatedAtAction<TValue>(string actionName, object routeValues, TValue value)
            => CreatedAtAction<TValue>(actionName, controllerName: null, routeValues: routeValues, value: value);

        /// <summary>
        /// Creates a <see cref="CreatedAtActionResult{TValue}"/> object that produces a <see cref="StatusCodes.Status201Created"/> response.
        /// </summary>
        /// <param name="actionName">The name of the action to use for generating the URL.</param>
        /// <param name="controllerName">The name of the controller to use for generating the URL.</param>
        /// <param name="routeValues">The route data to use for generating the URL.</param>
        /// <param name="value">The content value to format in the entity body.</param>
        /// <returns>The created <see cref="CreatedAtActionResult{TValue}"/> for the response.</returns>
        [NonAction]
        public virtual CreatedAtActionResult<TValue> CreatedAtAction<TValue>(
            string actionName,
            string controllerName,
            object routeValues,
            TValue value)
            => new CreatedAtActionResult<TValue>(actionName, controllerName, routeValues, value);

        /// <summary>
        /// Creates a <see cref="CreatedAtRouteResult{TValue}"/> object that produces a <see cref="StatusCodes.Status201Created"/> response.
        /// </summary>
        /// <param name="routeName">The name of the route to use for generating the URL.</param>
        /// <param name="value">The content value to format in the entity body.</param>
        /// <returns>The created <see cref="CreatedAtRouteResult{TValue}"/> for the response.</returns>
        [NonAction]
        public virtual CreatedAtRouteResult<TValue> CreatedAtRoute<TValue>(string routeName, TValue value)
            => CreatedAtRoute<TValue>(routeName, routeValues: null, value: value);

        /// <summary>
        /// Creates a <see cref="CreatedAtRouteResult{TValue}"/> object that produces a <see cref="StatusCodes.Status201Created"/> response.
        /// </summary>
        /// <param name="routeValues">The route data to use for generating the URL.</param>
        /// <param name="value">The content value to format in the entity body.</param>
        /// <returns>The created <see cref="CreatedAtRouteResult{TValue}"/> for the response.</returns>
        [NonAction]
        public virtual CreatedAtRouteResult<TValue> CreatedAtRoute<TValue>(object routeValues, TValue value)
            => CreatedAtRoute<TValue>(routeName: null, routeValues: routeValues, value: value);

        /// <summary>
        /// Creates a <see cref="CreatedAtRouteResult{TValue}"/> object that produces a <see cref="StatusCodes.Status201Created"/> response.
        /// </summary>
        /// <param name="routeName">The name of the route to use for generating the URL.</param>
        /// <param name="routeValues">The route data to use for generating the URL.</param>
        /// <param name="value">The content value to format in the entity body.</param>
        /// <returns>The created <see cref="CreatedAtRouteResult{TValue}"/> for the response.</returns>
        [NonAction]
        public virtual CreatedAtRouteResult<TValue> CreatedAtRoute<TValue>(string routeName, object routeValues, TValue value)
            => new CreatedAtRouteResult<TValue>(routeName, routeValues, value);
    }
}
