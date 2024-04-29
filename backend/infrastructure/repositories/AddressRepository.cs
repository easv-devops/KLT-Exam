using Dapper;
using infrastructure.dataModels;
using Npgsql;

namespace infrastructure.repositories;

public class AddressRepository
{
    private readonly NpgsqlDataSource? _dataSource;

    public AddressRepository(NpgsqlDataSource? dataSource)
    {
        if (_dataSource != null)
        {
            _dataSource = dataSource;   
        }
    }

    public IEnumerable<AddressModel> GetAddress()
    {
        var sql = @"SELECT * FROM Addresses;";
        if (_dataSource != null)
        {
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Query<AddressModel>(sql);
            }
        }
        return new List<AddressModel>
        {
            new AddressModel
                { Name = "Test1", StreetnameAndNumber = "Test Street 1", Zip = "12345", City = "Test City 1" },
            new AddressModel
                { Name = "Test2", StreetnameAndNumber = "Test Street 2", Zip = "54321", City = "Test City 2" }
        };
    }

    public AddressModel PostAddress(AddressModel addressModel)
    {
        var sql = @"INSERT INTO Addresses (""Name"", ""StreetnameAndNumber"", ""Zip"", ""City"") VALUES (@Name, @StreetnameAndNumber, @Zip, @City) RETURNING *;";
        if (_dataSource != null)
        {
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirst<AddressModel>(sql,
                    new
                    {
                        Name = addressModel.Name, StreetnameAndNumber = addressModel.StreetnameAndNumber,
                        Zip = addressModel.Zip, City = addressModel.City
                    });
            }
        }
        return new AddressModel{ Name = "Test1", StreetnameAndNumber = "Test Street 1", Zip = "12345", City = "Test City 1" };
    }
}