using System;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.TypedActionResults
{
    /// <summary>
    /// Base class for classes that are convertible to an <see cref="ActionResult{TValue}"/> and return a Location header.
    /// </summary>
    /// <typeparam name="TValue">Type of value returned in the entity body.</typeparam>
    public abstract class LocationObjectResult<TValue> : ObjectResult<TValue>
    {
        /// <summary>
        /// Gets or sets the location at which the content has been created.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationObjectResult{TValue}"/> class with the values
        /// provided.
        /// </summary>
        /// <param name="location">The location at which the content has been created.</param>
        /// <param name="value">The value to format in the entity body.</param>
        /// <param name="statusCode">The HTTP status code.</param>
        protected LocationObjectResult(string location, TValue value, int statusCode)
            : base(value, statusCode)
        {
            Location = location;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationObjectResult{TValue}"/> class with the values
        /// provided.
        /// </summary>
        /// <param name="locationUri">The location at which the content has been created.</param>
        /// <param name="value">The value to format in the entity body.</param>
        /// <param name="statusCode">The HTTP status code.</param>
        protected LocationObjectResult(Uri locationUri, TValue value, int statusCode)
            : base(value, statusCode)
        {
            if (locationUri == null)
            {
                throw new ArgumentNullException(nameof(locationUri));
            }

            if (locationUri.IsAbsoluteUri)
            {
                Location = locationUri.AbsoluteUri;
            }
            else
            {
                Location = locationUri.GetComponents(UriComponents.SerializationInfoString, UriFormat.UriEscaped);
            }
        }

        /// <inherited/>
        /// <remarks>You must override this method to take into account the Location header.</remarks>
        protected abstract override ActionResult<TValue> ConvertToActionResultOfT();
    }
}