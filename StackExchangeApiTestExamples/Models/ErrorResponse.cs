namespace StackExchangeApiTestExamples.Models
{
    /// <summary>
    ///     Representation of the Json error response when making a call
    /// </summary>
    public class ErrorResponse
    {
        public int Error_Id { get; set; }
        public string Error_Message { get; set; }
        public string Error_Name { get; set; }
    }
}
