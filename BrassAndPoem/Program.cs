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


//implement your loop here

    int userChoice;

    do
    {
        DisplayMenu();

        Console.Write("\nEnter your choice (1-5): ");
        if (!int.TryParse(Console.ReadLine(), out userChoice))
        {
            Console.Write("\nInvalid input. Please enter a number.");
            continue;
        }

        switch (userChoice)
        {
            case 1:
                DisplayAllProducts(Products, productTypes);
                break;
            case 2:
                DeleteProduct(Products, productTypes);
                break;
            case 3:
                AddProduct(Products, productTypes);
                break;
            case 4:
                UpdateProduct(Products, productTypes);
                break;
            case 5:
                Console.WriteLine("\nExiting. Thank you!");
                break;
            default:
                Console.WriteLine("\nInvalid choice. Please enter a number between 1 & 5.");
                break;
        }

    } while (userChoice != 5);
   
    void DisplayMenu()
{
    Console.WriteLine("\nPlease select an option below:\n");
    Console.WriteLine("1. Display all products");
    Console.WriteLine("2. Delete a product");
    Console.WriteLine("3. Add a new product");
    Console.WriteLine("4. Update a products properties");
    Console.WriteLine("5. Exit");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("\nAll Products:\n");

    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];
        ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);

        Console.WriteLine($"{i + 1}. Name: {product.Name}, Price: {product.Price:C}, Type: {productType?.Title}");
    }

    Console.WriteLine();
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("\nProducts to Delete:\n");

    for (int i = 0;i < products.Count;i++) 
    { 
        Product product= products[i];
        ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);

        Console.WriteLine($"{i + 1}. Name: {product.Name}, Price: {product.Price:C}, Type: {productType?.Title}");
    }

    Console.Write("\nEnter the number of the product to delete: ");

    if (int.TryParse(Console.ReadLine(), out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= products.Count)
    {

        int indexToDelete = selectedIndex - 1;

        Product productToDelete= products[indexToDelete];

        products.RemoveAt(indexToDelete);
        Console.WriteLine($"\nProduct '{productToDelete.Name}' deleted successfully!");
    }
    else
    {
        Console.WriteLine("\nInvalid number, no product was deleted.");
    }
}


void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("\nEnter the new product details:\n");
    Console.Write("Name: ");
    string productName = Console.ReadLine();

    Console.Write("Price: ");
    if (decimal.TryParse(Console.ReadLine(), out decimal productPrice))
    {
        Console.WriteLine("\nProduct Types:\n");
        foreach (var productType in productTypes)
        {
            Console.WriteLine($"{productType.Id}. {productType.Title}");
        }


    Console.Write("\nChoose a product type (Enter the corresponding number): ");
            if (int.TryParse(Console.ReadLine(), out int selectedProductTypeId) && productTypes.Any(pt => pt.Id == selectedProductTypeId))
            {

                Product newProduct = new Product
                {
                    Name = productName,
                    Price = productPrice,
                    ProductTypeId = selectedProductTypeId
                };

                products.Add(newProduct);

                Console.WriteLine($"\nProduct '{productName}' added successfuly.");
            }
            else
            {
                Console.WriteLine("Inavalid product type. No product added.");
            }
    }
        else
        {
            Console.WriteLine("Invalid price. No product added.");
        }
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("\nProducts to update:\n");

    for (int i = 0; i< products.Count; i++)
    {
        Product product = products[i];
        ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);

        Console.WriteLine($"{i + 1}. Name: {product.Name}, Price: {product.Price:C}, Type: {productType?.Title}");
    }

    Console.Write("\nEnter the number of the product to be updated: ");

    if (int.TryParse(Console.ReadLine(), out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= products.Count)
    {
 
        int indexToUpdate = selectedIndex - 1;

        Product productToUpdate = products[indexToUpdate];

        Console.WriteLine("\nEnter the updated details for the product (press Enter to leave unchanged):\n");

        Console.Write($"New Name ({productToUpdate.Name}): ");
        string newProductName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newProductName))
        {
            productToUpdate.Name = newProductName;
        }

        Console.Write($"\nNew Price ({productToUpdate.Price:C}): ");
        string newPriceInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newPriceInput) && decimal.TryParse(newPriceInput, out decimal newProductPrice))
        {
            productToUpdate.Price = newProductPrice;
        }

        
        Console.WriteLine($"\nNew Product Type ({productToUpdate.ProductTypeId} for unchanged): ");
        foreach (var productType in productTypes)
        {
            Console.Write($"{productType.Id}. {productType.Title}  ");
        }
        Console.WriteLine();
        string newProductTypeInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newProductTypeInput) && int.TryParse(newProductTypeInput, out int newProductTypeId) && productTypes.Any(pt => pt.Id == newProductTypeId))
        {
            productToUpdate.ProductTypeId = newProductTypeId;
        }

        Console.WriteLine($"\nProduct '{productToUpdate.Name}' updated successfully.");
    }
    else
    {
        Console.WriteLine("Invalid number chosen, no product updated.");
    }
}

// don't move or change this!
public partial class Program { }