using System.Collections.Generic;

namespace StackExchangeApiTestExamples.Models
{
    /// <summary>
    ///     Representation of the Site Json object
    /// </summary>
    public class Site
    {
        public List<string> Aliases { get; set; }
        public Styling Styling { get; set; }
        public List<RelatedSite> Related_Sites { get; set; }
        public List<string> Markdown_Extensions { get; set; }
        public int Launch_Date { get; set; }
        public int Open_Beta_Date { get; set; }
        public string Site_State { get; set; }
        public string High_Resolution_Icon_Url { get; set; }
        public string Favicon_Url { get; set; }
        public string Icon_Url { get; set; }
        public string Audience { get; set; }
        public string Site_Url { get; set; }
        public string Api_Site_Parameter { get; set; }
        public string Logo_Url { get; set; }
        public string Name { get; set; }
        public string Site_Type { get; set; }
    }
}
