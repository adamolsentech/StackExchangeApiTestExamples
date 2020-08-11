namespace StackExchangeApiTestExamples.Models
{
    /// <summary>
    ///     Response Wrapper on all API call responses
    /// </summary>
    public abstract class ResponseWrapper
    {
        public bool Has_More { get; set; }
        public int Quota_Max { get; set; }
        public int Quota_Remaining { get; set; }
        public int Page_Size { get; set; }
    }
}
