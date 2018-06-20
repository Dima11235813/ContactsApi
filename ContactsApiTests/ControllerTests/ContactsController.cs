using ContactsApi.Controllers;
using ContactsApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ContactsApiTests
{
    [TestClass]
    public class ContactsControllerTest
    {
        private IContactRepository _contactRepository;
        public ContactsControllerTest(IContactRepository cityInfoRepository)
        {
            _contactRepository = cityInfoRepository;
        }
        [TestMethod]
        public void GetOneContactById()
        {
            // Arrange
            ContactsController contactsController = new ContactsController();
            controller.ControllerContext = TradeviewAnalytics.Tests.TestUtilities.GenerateControllerContext(Convert.ToInt32(ConfigurationManager.AppSettings["test_WebUser_ID"]));

            // Act 
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
    }
}
