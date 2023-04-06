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

        [Test]
        public void Scan23456Barcode()
        {
            var pointOfSale = new PointOfSale();
            var price = pointOfSale.Scan("23456");
            price.Should().Be("$12.50");
        }

        [Test]
        public void Scan99999Barcode()
        {
            var pointOfSale = new PointOfSale();
            var price = pointOfSale.Scan("99999");
            price.Should().Be("Error: barcode not found");
        }
    }

    public class PointOfSale
    {
        private readonly Dictionary<string, string> _codes;

        public PointOfSale()
        {
            _codes = new()
            {
                {"12345", "$7.25"},
                {"23456", "$12.50"}
            };
        }

        public string Scan(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return "Error: empty barcode";
            }

            if (_codes.TryGetValue(code, out var response))
            {
                return response;
            }

            return "Error: barcode not found";
        }
    }
}