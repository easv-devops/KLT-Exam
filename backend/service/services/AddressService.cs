using infrastructure.dataModels;
using infrastructure.repositories;

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
        return _addressRepository.GetAddress();
    } 
    
    public AddressModel PostAddress(AddressModel addressModel)
    {
        return _addressRepository.PostAddress(addressModel);
    }
}