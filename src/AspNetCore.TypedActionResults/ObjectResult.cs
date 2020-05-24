using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.TypedActionResults
{
    /// <summary>
    /// Base class used to return HTTP response with a body of type <typeparamref name="TValue"/>, ensuring
    /// it converts into <see cref="ActionResult{TValue}"/> but not to ActionResult&lt;another_type&gt;.
    /// </summary>
    /// <typeparam name="TValue">Type of value returned in the entity body.</typeparam>
    public class ObjectResult<TValue> // Note: Do NOT inherit from ActionResult in any ways otherwise this would convert implicitly to ActionResult<anything>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectResult{TValue}"/> class.
        /// </summary>
        /// <param name="value">The content to format into the entity body.</param>
        /// <param name="statusCode">The HTTP status code.</param>
        public ObjectResult(TValue value, int statusCode)
        {
            Value = value;
            StatusCode = statusCode;
        }

        /// <summary>
        /// Gets or sets the value to format into the entity body.
        /// </summary>
        public TValue Value { get; set; }

        /// <summary>
        /// Gets or sets the HTTP status code.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Converts the current object to an object convertible to an <see cref="ActionResult"/>.
        /// This is called by the implicit conversion to <see cref="ActionResult{TValue}"/>
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult<TValue> ConvertToActionResultOfT()
        {
            return new ObjectResult(Value)
            {
                StatusCode = StatusCode
            };
        }

        /// <summary>
        /// Implicitly converts to a <see cref="ActionResult{TValue}"/> with <typeparamref name="TValue"/> equal to the type as the value returned.
        /// </summary>
        /// <param name="result">The object result to convert.</param>
        public static implicit operator ActionResult<TValue>(ObjectResult<TValue> result)
            => result.ConvertToActionResultOfT();
    }
}

