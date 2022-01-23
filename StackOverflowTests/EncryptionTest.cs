using NUnit.Framework;
using StackOverflow.Common.Utils;

namespace StackOverflowTests;

public class EncryptionTest
{
    [SetUp]
    public void Setup()
    {
    }


    [Test]
    public void TestEncryptedStringEqualsDerctyptedString()
    {
        var text = "some text";
        var encryptedText = text.Encrypt();
        var decryptedText = encryptedText.Decrypt();

        Assert.AreNotEqual(text, encryptedText);
        Assert.AreEqual(text, decryptedText);
    }
}