namespace StackExchangeApiTestExamples.Utils
{
    /// <summary>
    ///     Utilities that can be utilized across tests
    /// </summary>
    public class ApiTestUtils
    {
        /// <summary>
        ///     Request filter that adds Page, Page Size, and Total to default filter
        /// </summary>
        public static string DefaultPlusPageSizeFilter = "!9Z(-x-d8(";

        /// <summary>
        ///     Adds a filter to any requestUri string
        /// </summary>
        /// <param name="requestUri">RequestUri to add filter to</param>
        /// <param name="filter">Filter to add</param>
        /// <returns>RequestUri with a filter string</returns>
        public static string AddFilterToRequestUri(string requestUri, string filter)
        {
            return requestUri + "&filter=" + filter;
        }

        /// <summary>
        ///     Adds the page_size parameter to a request uri
        /// </summary>
        /// <param name="requestUri">the uri to add the parameter to</param>
        /// <param name="pageSize">the number to set the parameter to</param>
        /// <returns></returns>
        public static string AddPageSizeParameterToRequest(string requestUri, int pageSize)
        {
            return requestUri.Replace("?", "?pagesize=" + pageSize + "&");
        }
    }
}
