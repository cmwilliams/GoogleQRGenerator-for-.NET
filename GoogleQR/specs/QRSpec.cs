using System;
using NUnit.Framework;

namespace GoogleQRGenerator.specs
{
    [TestFixture]
    public class QRSpec
    {
        private GoogleQR _qrCode;

        [SetUp]
        public void Init()
        {
            _qrCode = new GoogleQR();
        }
        
        [Test]
        public void ShouldRaiseErrorWithoutData()
        {
            _qrCode.Data = null;
            var ex = Assert.Throws<Exception>(() => _qrCode.ToString());
            Assert.That(ex.Message, Is.EqualTo("Data is required"));
        }

        [Test]
        public void ShouldRenderWithTheDefaultSizeOf100X100()
        {
            _qrCode.Data = "ExampleQRData";
            Assert.AreEqual(_qrCode.ToString(), "https://chart.googleapis.com/chart?cht=qr&chl=ExampleQRData&chs=100x100");
        }


        [Test]
        public void ShouldRenderWithASizeGiven()
        {
            _qrCode.Size = "200x200";
            Assert.AreEqual(_qrCode.ToString(), "https://chart.googleapis.com/chart?cht=qr&chl=" + _qrCode.Data + "&chs=200x200");
        }

        [Test]
        public void ShouldRenderWithoutHttpsIfRequested()
        {
            _qrCode.UseHttps = false;
            Assert.AreEqual(_qrCode.ToString(), "http://chart.googleapis.com/chart?cht=qr&chl=" + _qrCode.Data + "&chs=" + _qrCode.Size);
        }


        [Test]
        public void ShouldRenderWithImgTagWithWidthAndHeightAttributes()
        {
            _qrCode.Size = "100x100";
            Assert.AreEqual(_qrCode.Render(), "<img src='https://chart.googleapis.com/chart?cht=qr&chl=" + _qrCode.Data + "&chs=" + _qrCode.Size + "' height='100' width='100' />");
        }

        [Test]
        public void ShouldSetEncoding()
        {
            _qrCode.Encoding = "Shift_JIS";
            Assert.AreEqual(_qrCode.ToString(), "https://chart.googleapis.com/chart?cht=qr&chl=" + _qrCode.Data + "&chs=" + _qrCode.Size + "&choe=Shift_JIS");
        }

        [Test]
        public void ShouldSetSetErrorCorrectionLevel()
        {
            _qrCode.ErrorCorrection = "L";
            Assert.AreEqual(_qrCode.ToString(), "https://chart.googleapis.com/chart?cht=qr&chl=" + _qrCode.Data + "&chs=" + _qrCode.Size + "&chld=L");
        }


    }
}
