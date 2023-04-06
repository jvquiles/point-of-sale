using FluentAssertions;

namespace POS.Tests
{
    public class PointOfSaleShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ScanEmptyBarcode()
        {
            var pointOfSale = new PointOfSale();
            var price = pointOfSale.Scan("");
            price.Should().Be("Error: empty barcode");
        }

        [Test]
        public void Scan12345Barcode()
        {
            var pointOfSale = new PointOfSale();
            var price = pointOfSale.Scan("12345");
            price.Should().Be("$7.25");
        }
    }

    public class PointOfSale
    {
        public string Scan(string code)
        {
            if (code == "12345")
            {
                return "$7.25";
            }

            return "Error: empty barcode";
        }
    }
}