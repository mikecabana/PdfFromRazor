using Bogus;

namespace PdfFromRazor.Invoices;

public static class InvoiceGenerator
{
    public static Invoice Generate()
    {
        var faker = new Faker();

        return new Invoice
        {
            InvoiceNumber = faker.Random.Number(1000, 9999).ToString(),
            InvoiceDate = faker.Date.SoonDateOnly(0),
            DueDate = faker.Date.SoonDateOnly().AddMonths(1),
            SellerAddress = new Address
            {
                CompanyName = faker.Company.CompanyName(),
                City = faker.Address.City(),
                Country = faker.Address.Country(),
                State = faker.Address.State(),
                PostalCode = faker.Address.ZipCode(),
                Street = faker.Address.StreetAddress(),
                Email = faker.Person.Email,
                Phone = faker.Person.Phone,
            },
            CustomerAddress = new Address
            {
                CompanyName = faker.Company.CompanyName(),
                City = faker.Address.City(),
                Country = faker.Address.Country(),
                State = faker.Address.State(),
                PostalCode = faker.Address.ZipCode(),
                Street = faker.Address.StreetAddress(),
                Email = faker.Person.Email,
                Phone = faker.Person.Phone,
            },
            TaxRate = 0.15m,
            Items = new List<OrderItem>
            {
                new OrderItem
                {
                    Name = "Laptop",
                    Quantity = 1,
                    UnitPrice = 1200.00m
                },
                new OrderItem
                {
                    Name = "Wireless Mouse",
                    Quantity = 2,
                    UnitPrice = 25.50m
                },
                new OrderItem
                {
                    Name = "Mechanical Keyboard",
                    Quantity = 1,
                    UnitPrice = 150.75m
                },
                new OrderItem
                {
                    Name = "USB-C Adapter",
                    Quantity = 3,
                    UnitPrice = 19.99m
                },
                new OrderItem
                {
                    Name = "Monitor",
                    Quantity = 2,
                    UnitPrice = 300.00m
                }
            }
        };
    }
}