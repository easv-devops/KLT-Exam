using infrastructure.dataModels;
using infrastructure.repositories;
using Monitoring;

namespace service.services;

public class AddressService
{
    private readonly AddressRepository _addressRepository;
    
    public AddressService(AddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }
    
    public IEnumerable<AddressModel> GetAddress()
    {
        MonitorService.Log.Debug("SAY HELLO TO MY LITTLE FRIEND");
        return _addressRepository.GetAddress();
    } 
    
    public AddressModel PostAddress(AddressModel addressModel)
    {
        return _addressRepository.PostAddress(addressModel);
    }
}