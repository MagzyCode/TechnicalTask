using System.Text.Json;

namespace ServerPart.Models.ErrorModel
{
    public class ErrorDetails
    {
        /// <summary>
        /// Represents status code of error.
        /// </summary>
        /// <example>
        /// 401
        /// </example>
        public int StatusCode { get; set; }

        /// <summary>
        /// Represents error messge.
        /// </summary>
        /// <example>
        /// Some error happen.
        /// </example>
        public string Message { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
