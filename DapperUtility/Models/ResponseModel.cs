namespace DapperUtility.Models
{
    /// <summary>
    /// A common response model
    /// </summary>
    public class ResponseModel
    {
        public int result { get; set; }
        public string message { get; set; }

        public ResponseModel(int Result, string Message)
        {
            result = Result;
            message = Message;
        }
        public ResponseModel()
        {

        }
    }
}
