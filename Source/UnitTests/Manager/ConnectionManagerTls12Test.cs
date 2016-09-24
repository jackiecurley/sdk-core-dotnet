using System.Collections.Generic;
using System.Net;
using PayPal.Manager;
using PayPal.Exception;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PayPal.Testing
{
    [TestClass]
    public class ConnectionManagerTls12Test
    {

        private SecurityProtocolType DefaultSecurityProtocol { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            DefaultSecurityProtocol = ServicePointManager.SecurityProtocol;
        }

        [TestCleanup]
        public void TearDown()
        {
            ServicePointManager.SecurityProtocol = DefaultSecurityProtocol;
        }

        private static SecurityProtocolType Ssl3 => SecurityProtocolType.Ssl3;

        private static SecurityProtocolType Tls => SecurityProtocolType.Tls;

        private static SecurityProtocolType Tls11 => (SecurityProtocolType)0x300;

        private static SecurityProtocolType Tls12 => (SecurityProtocolType)0xC00;

        [Ignore]
        public void Tls12SupportShouldBeAddedWithoutAffectingExistingProtocols()
        {
            ServicePointManager.SecurityProtocol = Ssl3 | Tls | Tls11;

            var connectionManager = ConnectionManager.Instance;

            SecurityProtocolType actual = ServicePointManager.SecurityProtocol;
            Assert.IsTrue(actual.HasFlag(Ssl3), "SSL3 support got removed.");
            Assert.IsTrue(actual.HasFlag(Tls), "TLSv1.0 support got removed.");
            Assert.IsTrue(actual.HasFlag(Tls11), "TLSv1.1 support got removed.");
            Assert.IsTrue(actual.HasFlag(Tls12), "TLSv1.2 support not added.");
        }

    }
}