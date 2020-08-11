using System.Collections.Generic;

namespace StackExchangeApiTestExamples.Models
{
    /// <summary>
    ///     Representation of the Question (Item) Json object
    /// </summary>
    public class Question
    {
        public List<string> Tags { get; set; }
        public Owner Owner { get; set; }
        public bool Is_Answered { get; set; }
        public int View_Count { get; set; }
        public int Answer_Count { get; set; }
        public int Score { get; set; }
        public int Last_Activity_Date { get; set; }
        public int Creation_Date { get; set; }
        public int Question_Id { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public int Last_Edit_Date { get; set; }
        public int Accepted_Answer_Id { get; set; }
        public int Closed_Date { get; set; }
        public string Closed_Reason { get; set; }
        public int Bounty_Amount { get; set; }
        public int Bounty_Closes_Date { get; set; }
    }
}
