using System.Collections.Generic;

namespace StackExchangeApiTestExamples.Models
{
    /// <summary>
    ///     Representation of the Json object returned when calling /sites endpoint
    /// </summary>
    public class SitesResponse : ResponseWrapper
    {
        public List<Site> Items { get; set; }
    }
}
