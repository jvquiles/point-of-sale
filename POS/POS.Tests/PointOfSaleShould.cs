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
        public void Scan12345Barcode()
        {
            var pointOfSale = new PointOfSale();
            var price = pointOfSale.Scan("");
            price.Should().Be("Error: empty barcode");
        }
    }

    public class PointOfSale
    {
        public string Scan(string s)
        {
            return "Error: empty barcode";
        }
    }
}