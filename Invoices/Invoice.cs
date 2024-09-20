namespace PdfFromRazor.Invoices;

public class OrderItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice
    {
        get
        {
            return Quantity * UnitPrice;
        }
    }
}

public class Address
{
    public string CompanyName { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }

    public object Email { get; set; }
    public string Phone { get; set; }
}

public class Invoice
{
    public string InvoiceNumber { get; set; }
    public DateOnly InvoiceDate { get; set; }
    public DateOnly DueDate { get; set; }
    public Address SellerAddress { get; set; }
    public Address CustomerAddress { get; set; }
    public List<OrderItem> Items { get; set; }
    public decimal TaxRate { get; set; }

    public decimal Subtotal
    {
        get
        {
            decimal subtotal = 0;
            foreach (var item in Items)
            {
                subtotal += item.TotalPrice;
            }
            return subtotal;
        }
    }

    public decimal TaxAmount
    {
        get
        {
            return Subtotal * TaxRate;
        }
    }

    public decimal TotalAmount
    {
        get
        {
            return Subtotal + TaxAmount;
        }
    }

    public Invoice()
    {
        Items = new List<OrderItem>();
    }
}
