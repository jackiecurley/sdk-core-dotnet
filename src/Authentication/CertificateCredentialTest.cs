using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Authentication;

namespace PayPal
{
    [TestClass]
    public class CertificateCredentialTest
    {
        private CertificateCredential CertCredential;

        public CertificateCredentialTest()
        {
            CertCredential = new CertificateCredential("platfo_1255077030_biz_api1.gmail.com", "1255077037", "sdk-cert.p12", "KJAERUGBLVF6Y");          
        }

        [TestMethod]
        public void UserName()
        {
            Assert.AreEqual("platfo_1255077030_biz_api1.gmail.com", CertCredential.UserName);
        }
        
        [TestMethod]
        public void Password()
        {
            Assert.AreEqual("1255077037", CertCredential.Password);
        }

        [TestMethod]
        public void CertificateFile()
        {
            Assert.AreEqual("sdk-cert.p12", CertCredential.CertificateFile);
        }

        [TestMethod]
        public void PrivateKeyPassword()
        {
            Assert.AreEqual("KJAERUGBLVF6Y", CertCredential.PrivateKeyPassword);
        }
        
        [TestMethod]
        public void ApplicationID()
        {
            CertCredential.ApplicationID = Constants.ApplicationID ;
            Assert.AreEqual(Constants.ApplicationID, CertCredential.ApplicationID);
        }               

        [TestMethod]
        public void SetAndGetThirdPartyAuthorizationForSubject()
        {
            IThirdPartyAuthorization thirdPartyAuthorization = new SubjectAuthorization("Subject");
            CertCredential.ThirdPartyAuthorization = thirdPartyAuthorization;
            Assert.AreEqual(((SubjectAuthorization)thirdPartyAuthorization).Subject,"Subject");

        }

        [TestMethod]
        public void ThirdPartyAuthorizationTestForToken()
        {
            IThirdPartyAuthorization thirdPartyAuthorization = new TokenAuthorization(Constants.AccessToken, Constants.TokenSecret);
            CertCredential.ThirdPartyAuthorization = thirdPartyAuthorization;
            Assert.AreEqual(((TokenAuthorization)thirdPartyAuthorization).AccessToken, Constants.AccessToken);
            Assert.AreEqual(((TokenAuthorization)thirdPartyAuthorization).AccessTokenSecret, Constants.TokenSecret);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CertificateCredentialArgumentException()
        {
            try
            {
                CertCredential = new CertificateCredential(null, null, null, null);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Certificate Credential arguments cannot be null", ex.Message);
                throw;
            }
        }
    }
}