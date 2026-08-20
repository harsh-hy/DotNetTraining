using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
public class ProductRepository
{
    private readonly string _connectionString;
    private readonly ILogger<ProductRepository> _logger;

    public ProductRepository(string connectionString, ILogger<ProductRepository> logger)
    {
        _connectionString = connectionString;
        _logger = logger;
    }

    public async Task<Product?> GetProductAsync(string productName)
    {
        if (string.IsNullOrWhiteSpace(productName))
        {
            _logger.LogWarning("Product name is null or empty");
            return null;
        }

        try
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            const string sql = "SELECT Id, Name FROM Products WHERE Name = @ProductName";

            await using var command = new SqlCommand(sql, connection);
            command.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.NVarChar)
            {
                Value = productName
            });

            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new Product
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name"))
                };
            }

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching product with name {ProductName}", productName);
            throw;
        }
    }
}
