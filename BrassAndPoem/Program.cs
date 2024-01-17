using static Product;
using static ProductType;

//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> Products = new List<Product>
{
    new Product { Name = "Tuba", Price = 4586.25M, ProductTypeId = 1},
    new Product { Name = "Trumpet", Price = 898.99M, ProductTypeId = 1},
    new Product { Name = "French Horn", Price = 2500.99M, ProductTypeId = 1},
    new Product { Name = "Cornet", Price = 457.99M, ProductTypeId = 1},
    new Product { Name = "Flugel Horn", Price = 708.99M, ProductTypeId = 1},
    new Product { Name = "Plastic Butter", Price = 45.99M, ProductTypeId = 2},
    new Product { Name = "Lines in My Head", Price = 15.99M, ProductTypeId = 2},
    new Product { Name = "I found the Lost Soul", Price = 28.99M, ProductTypeId = 2},
};

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>
{
    new ProductType { Id = 1, Title = "Brass Instruments" },
    new ProductType { Id = 2, Title = "Poetry Books" }
};

//put your greeting here
Console.WriteLine($@"=============================================================
==                                                         ==
==     Welcome to Poetry and Brass Instruments Shop!       ==
==                                                         ==
=============================================================");


Console.WriteLine("Please Select an Option Below: ");


//implement your loop here

void DisplayMenu()
{
    throw new NotImplementedException();
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

// don't move or change this!
public partial class Program { }