using System.Collections.Generic;

namespace StackExchangeApiTestExamples.Models
{
    /// <summary>
    ///     Representation of the Json response when calling /questions
    /// </summary>
    public class QuestionsResponse : ResponseWrapper
    {
        public List<Question> Items { get; set; }
    }
}
