using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Nexmo.Tests
{
    [TestClass]
    public class NexmoClientTests
    {
        [TestMethod]
        public async Task TestInvalidCredentials()
        {
            NexmoClient client = new NexmoClient("wrong", "credentials");
            var response = await client.SendSMSAsync(new Model.Message()
            {
                From = "Test",
                Text = "Hello World!",
                To = "10002224444"
            });

            Assert.AreEqual(response.MessageCount, 1);
            Assert.IsNotNull(response.Messages);
            Assert.AreEqual(response.Messages.Count, 1);

            var message = response.Messages.Single();

            Assert.AreEqual(message.Status, Model.ResponseStatus.InvalidCredentials);

        }
    }
}
