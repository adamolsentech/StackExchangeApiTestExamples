using NUnit.Framework;
using Shouldly;
using StackExchangeApiTestExamples.Models;
using StackExchangeApiTestExamples.Utils;

namespace StackExchangeApiTestExamples.Tests
{
    /// <summary>
    ///     Testing of the page_size parameter/attribute
    /// </summary>
    //[TestFixture]
    public class PageSizeTests : StackExchangeApiBaseTest
    {
        /// <summary>
        ///     Questions request string with 
        /// </summary>
        private readonly string _baseQuestionsRequestUriWithFilter =
            ApiTestUtils.AddFilterToRequestUri("questions?order=desc&sort=activity&site=stackoverflow",
                ApiTestUtils.DefaultPlusPageSizeFilter);

        private readonly string _baseSitesRequestUriWithFilter = ApiTestUtils.AddFilterToRequestUri("sites?",
            ApiTestUtils.DefaultPlusPageSizeFilter);

        /// <summary>
        ///     Verifies that the page size defaults to 30 with the same number of returned questions
        /// </summary>
        [Test]
        public void PageSizeDefaultTest()
        {
            //Send request without page size parameter getting QuestionResponse object
            QuestionsResponse questionResponse = HttpUtils.SendGetRequest<QuestionsResponse>(BaseAddress,
                _baseQuestionsRequestUriWithFilter);
            //Verify that the page size  is 30 (default)
            ShouldBeBooleanExtensions.ShouldBeTrue(questionResponse.Page_Size == 30,
                "The default page-size attribute is not 30 as expected!  Actual: " + questionResponse.Page_Size);
            //Verify there are 30 question items returned (default)
            ShouldBeBooleanExtensions.ShouldBeTrue(questionResponse.Items.Count == 30,
                "The default items returned is not 30 as expected!  Actual: " + questionResponse.Items.Count);
        }

        /// <summary>
        ///     Sets a page size of 0 and verifies that the has more 
        ///     (more pages available) property is true
        /// </summary>
        [Test]
        public void VerifyLowerBoundsAndHasMoreProperty()
        {
            //create request uri with 0 page size parameter
            string zeroPageRequest = ApiTestUtils.AddPageSizeParameterToRequest(_baseQuestionsRequestUriWithFilter, 0);
            //Send request
            QuestionsResponse questionsResponse = HttpUtils.SendGetRequest<QuestionsResponse>(BaseAddress,
                zeroPageRequest);
            //Verify page size of 0
            ShouldBeBooleanExtensions.ShouldBeTrue(questionsResponse.Page_Size.Equals(0),
                "The page-size returned is not the same as requested (0)!  Actual: " + questionsResponse.Page_Size);
            //Verify 'has more' property is true
            ShouldBeBooleanExtensions.ShouldBeTrue(questionsResponse.Has_More, "The has-more attribute is not true as expected!");
        }

        /// <summary>
        ///     Verifies the upper bounds of the page_size attribute of 100
        ///     and verifies the error messaging for out-of-bounds request
        /// </summary>
        [Test]
        public void UpperLimitErrorTest()
        {
            //create request uri with 100 page size parameter
            string oneHundredPageSizeRequest = ApiTestUtils.AddPageSizeParameterToRequest(_baseQuestionsRequestUriWithFilter, 100);
            //Send request
            QuestionsResponse questionsResponse = HttpUtils.SendGetRequest<QuestionsResponse>(BaseAddress,
                oneHundredPageSizeRequest);
            //Verify 100 page size response was retuned
            (questionsResponse.Page_Size == 100).ShouldBeTrue("The page size returned is not what was requested (100)!");
            //Create request uri with 101 page size parameter 
            string oneHundredOnePageSizeRequest = ApiTestUtils.AddPageSizeParameterToRequest(_baseQuestionsRequestUriWithFilter, 101);
            //Send request resulting in error response, verify message
            ErrorResponse errorResponse = HttpUtils.SendGetRequest<ErrorResponse>(BaseAddress,
                oneHundredOnePageSizeRequest);
            ShouldBeBooleanExtensions.ShouldBeTrue(errorResponse.Error_Message.Equals("pagesize"),
                "The error message is not 'pagesize' as expected!  Actual: " + errorResponse.Error_Message);
            //Verify error name
            ShouldBeBooleanExtensions.ShouldBeTrue(errorResponse.Error_Name.Equals("bad_parameter"),
                "The error name is not 'bad_parameter' as expected!  Actual: " + errorResponse.Error_Name);
        }

        /// <summary>
        ///     The /sites endpoint is the only API call with expanded upper limit for page size
        ///     this tests that a request can have a page_size over 100
        /// </summary>
        [Test]
        public void SitesRequestPageSizeLimitTest()
        {
            //Create sites request uri with page_size of 200
            string twoHundredPageSizeRequest = ApiTestUtils.AddPageSizeParameterToRequest(_baseSitesRequestUriWithFilter, 200);
            //Send request
            SitesResponse sitesResponse = HttpUtils.SendGetRequest<SitesResponse>(BaseAddress, twoHundredPageSizeRequest);
            //Verify page_size of 200
            ShouldBeBooleanExtensions.ShouldBeTrue(sitesResponse.Page_Size.Equals(200),
                "The page_size parameter is not 200 as expected!  Actual: " + sitesResponse.Page_Size);
        }


    }
}
