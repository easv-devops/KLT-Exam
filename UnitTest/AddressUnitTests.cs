using api.controller;
using infrastructure;
using infrastructure.dataModels;
using infrastructure.repositories;
using service.services;

namespace UnitTest;

public class Tests
{
    [Test]
    public void GetAddress()
    {
        var repository = new AddressRepository(null);
        var service = new AddressService(repository);
        var controller = new AddressController(service);

        var expectedAddress = new List<AddressModel>
        {
            new AddressModel
                { Name = "Test1", StreetnameAndNumber = "Test Street 1", Zip = "12345", City = "Test City 1" },
            new AddressModel
                { Name = "Test2", StreetnameAndNumber = "Test Street 2", Zip = "54321", City = "Test City 2" }
        };
        
        var addresses = controller.GetAddress();
        
        addresses.ResponseData.Equals(expectedAddress);
    }

    [Test]
    public void CreateAddress()
    {
        var repository = new AddressRepository(null);
        var service = new AddressService(repository);
        var controller = new AddressController(service);

        var Testaddress = new AddressModel
            { Name = "Test1", StreetnameAndNumber = "Test Street 1", Zip = "12345", City = "Test City 1" };
        
        var address = controller.PostAddress(Testaddress);
        
        address.ResponseData.Equals(Testaddress);
    }
    
    [Test]
    public void CreateAddressFailed()
    {
        var repository = new AddressRepository(null);
        var service = new AddressService(repository);
        var controller = new AddressController(service);

        var testAddress = new AddressModel
            { Name = null, StreetnameAndNumber = null, Zip = null, City = null };
        
        var address = controller.PostAddress(testAddress);

        address.ResponseData.Equals(null);
    }

    [Test]
    public void GetVersionTest()
    {
        var repository = new AddressRepository(null);
        var service = new AddressService(repository);
        var controller = new AddressController(service);

        var version = controller.GetVersion();
        
        Assert.IsNotNull(version);
        Assert.That(version, Is.EqualTo(0.1));
    }

    [Test]
    public void GetUtilitiesString()
    {
        Assert.That(Utilities.connectionStringDev, Has.Length.EqualTo(73));
    }
}