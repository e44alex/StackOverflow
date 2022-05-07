using NUnit.Framework;
using StackOverflow.Common.Utils;

namespace StackOverflowTests;

[TestFixture]
public class EncryptionTests
{

    [Test]
    [TestCase("this is a test string")]
    public void EncryptionTests_EncryptedString_ShouldNotEqual(string str)
    {
        Assert.AreNotEqual(str, str.Encrypt());
    }

    [Test]
    [TestCase("this is a test string")]
    public void EncryptionTests_StringUnEncrypted_ShouldEqual(string str)
    {
        var encryptedString = str.Encrypt();
        Assert.True(str.CompareWithEncrypted(encryptedString));
    }
}