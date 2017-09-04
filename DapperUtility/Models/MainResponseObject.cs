using System.Collections.Generic;

namespace DapperUtility.Models
{
    /// <summary>
    /// Base Response Object that should be inherited for other response types
    /// </summary>
    public class MainResponseObject
    {
        /// <summary>
        /// A common response object that contains 'result' for code and 'message' for description of any response
        /// </summary>
        public List<ResponseModel> Response { get; set; }
    }
}
