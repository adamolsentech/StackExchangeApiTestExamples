using NUnit.Framework;

namespace StackExchangeApiTestExamples.Tests
{
    public class StackExchangeApiBaseTest
    {
        /// <summary>
        ///     Gets or sets the test context which provides
        ///     information about and functionality for the current test run.
        ///</summary>
        protected TestContext TestContext { get; set; }

        /// <summary>
        ///     Base Address for all stackexchange calls
        /// </summary>
        protected string BaseAddress = "https://api.stackexchange.com/2.2/";

        /// <summary>
        ///     Default constructor
        /// </summary>
        public StackExchangeApiBaseTest()
        {
        }

        [SetUp]
        public void Setup()
        {
        }
    }
}