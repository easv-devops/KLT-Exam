using Dapper;
using infrastructure.dataModels;
using Npgsql;

namespace infrastructure.repositories;

public class AddressRepository
{
    private readonly NpgsqlDataSource _dataSource;

    public AddressRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public IEnumerable<AddressModel> GetAddress()
    {
        var sql = @"SELECT * FROM Addresses;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<AddressModel>(sql);
        }
    }

    public AddressModel PostAddress(AddressModel addressModel)
    {
        var sql = @"INSERT INTO Addresses (""Name"", ""StreetnameAndNumber"", ""Zip"", ""City"") VALUES (@Name, @StreetnameAndNumber, @Zip, @City) RETURNING *;";
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
}