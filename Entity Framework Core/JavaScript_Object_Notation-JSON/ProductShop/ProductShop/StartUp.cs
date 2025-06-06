﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();

            string jsonString = File.ReadAllText("../../../Datasets/categories-products.json");
            string result = GetCategoriesByProductsCount(dbContext);

            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportUserDto[]? userDtos = JsonConvert
                .DeserializeObject<ImportUserDto[]>(inputJson);

            if (userDtos != null)
            {
                ICollection<User> usersToAdd= new List<User>();

                foreach (ImportUserDto userDto in userDtos)
                {
                    if (!IsValid(userDto))
                    {
                        continue;
                    }

                    int? userAge = null;
                    if (userDto.Age != null)
                    {
                        bool isAgeValid = int.TryParse(userDto.Age, out int parsedAge);
                        if (!isAgeValid)
                        {
                            continue;
                        }

                        userAge = parsedAge;
                    }

                    User user = new User()
                    {
                        FirstName = userDto.FirstName,
                        LastName = userDto.LastName,
                        Age = userAge
                    };

                    usersToAdd.Add(user);
                }

                context.AddRange(usersToAdd);
                context.SaveChanges();

                result = $"Successfully imported {usersToAdd.Count}";
            }

            return result;
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportProductDto[]? productDtos = JsonConvert
                .DeserializeObject<ImportProductDto[]>(inputJson);

            if (productDtos != null)
            {
                ICollection<Product> productsToAdd = new List<Product>();

                foreach (ImportProductDto productDto in productDtos)
                {
                    if (!IsValid(productDto))
                    {
                        continue;
                    }

                    bool isPriceValid = decimal
                        .TryParse(productDto.Price, out decimal parsedPrice);
                    bool isSellerIdValid = int
                        .TryParse(productDto.SellerId, out int parsedSellerId);

                    if ((!isPriceValid) || (!isSellerIdValid))
                    {
                        continue;
                    }

                    int? buyerId = null;
                    if (productDto.BuyerId != null)
                    {
                        bool buyerIdValid = int .TryParse(productDto.BuyerId, out int parsedBuyerId);

                        if (!buyerIdValid)
                        {
                            continue;
                        }

                        buyerId = parsedBuyerId;
                    }

                    Product product = new Product()
                    {
                        Name = productDto.Name,
                        Price = parsedPrice,
                        SellerId = parsedSellerId,
                        BuyerId = buyerId
                    };

                    productsToAdd.Add(product);
                }

                context.AddRange(productsToAdd);
                context.SaveChanges();

                result = $"Successfully imported {productsToAdd.Count}";
            }

            return result;
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportCategoryDto[]? categoryDtos = JsonConvert
                .DeserializeObject<ImportCategoryDto[]>(inputJson);

            if (categoryDtos != null)
            {
                ICollection<Category> categoriesToAdd = new List<Category>();

                foreach (ImportCategoryDto categoryDto in categoryDtos)
                {
                    if (!IsValid(categoryDto))
                    {
                        continue;
                    }

                    Category category = new Category()
                    {
                        Name = categoryDto.Name,
                    };

                    categoriesToAdd.Add(category);
                }

                context.AddRange(categoriesToAdd);
                context.SaveChanges();

                result = $"Successfully imported {categoriesToAdd.Count}";
            }

            return result;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportCategoriesProductsDto[]? validCategoriesProductsDtos = JsonConvert
                .DeserializeObject<ImportCategoriesProductsDto[]>(inputJson);

            if (validCategoriesProductsDtos != null)
            {
                ICollection<CategoryProduct> categoriesProducts = new List<CategoryProduct>();

                foreach (ImportCategoriesProductsDto catProdDto in validCategoriesProductsDtos)
                {
                    if (!IsValid(catProdDto))
                    {
                        continue;
                    }

                    bool isCatIdValid = int
                        .TryParse(catProdDto.CategoryId, out int categoryId);
                    bool isProdIdValid = int
                        .TryParse(catProdDto.ProductId, out int productId);

                    if ((!isCatIdValid) || (!isProdIdValid))
                    {
                        continue;
                    }

                    CategoryProduct categoryProduct = new CategoryProduct()
                    {
                        CategoryId = categoryId,
                        ProductId = productId,
                    };

                    categoriesProducts.Add(categoryProduct);
                }

                context.AddRange(categoriesProducts);
                context.SaveChanges();
                result = $"Successfully imported {categoriesProducts.Count}";
            }

            return result;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(p => p.Price)
                .ToArray();

            DefaultContractResolver camelCaseContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert
                .SerializeObject(products, Formatting.Indented, new JsonSerializerSettings()
                {
                    ContractResolver = camelCaseContractResolver
                });

            return jsonResult;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold
                      .Where(p => p.BuyerId.HasValue)
                      .Select(p => new
                      {
                          p.Name,
                          p.Price,
                          BuyerFirstName = p.Buyer!.FirstName,
                          BuyerLastName = p.Buyer!.LastName
                      })
                      .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToArray();

            DefaultContractResolver camelCaseContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert
                .SerializeObject(usersWithSoldProducts, Formatting.Indented, new JsonSerializerSettings()
                {
                    ContractResolver = camelCaseContractResolver
                });

            return jsonResult;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold
                           .Where(p => p.BuyerId.HasValue)
                           .Count(),
                        Products = u.ProductsSold
                           .Where(p => p.BuyerId.HasValue)
                           .Select(p => new
                           {
                               p.Name,
                               p.Price
                           })
                           .ToArray()
                    }
                })
                .ToArray()
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToArray();

            var userDto = new
            {
                UsersCount = usersWithSoldProducts.Length,
                Users = usersWithSoldProducts
            };

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert
                .SerializeObject(userDto, Formatting.Indented, new JsonSerializerSettings()
                {
                    ContractResolver = camelCaseResolver,
                    NullValueHandling = NullValueHandling.Ignore
                });

            return jsonResult;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoriesProducts.Count(),
                    AveragePrice = c.CategoriesProducts.Average(cp => cp.Product.Price).ToString("F2"),
                    TotalRevenue = c.CategoriesProducts.Sum(cp => cp.Product.Price).ToString("F2")

                })
                .OrderByDescending(c => c.ProductsCount)
                .ToArray();

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert
                .SerializeObject(categories, Formatting.Indented, new JsonSerializerSettings()
                {
                    ContractResolver = camelCaseResolver
                });

            return jsonResult;
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(dto, validateContext, validationResult, true);

            return isValid; 
        }
    }
}