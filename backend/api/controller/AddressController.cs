namespace DefaultNamespace;

[ApiController]
public class AddressController
{
    private readonly AddressService _addressService;

    public AddressController(AddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet]
    [Route("/address/get")]
    public ResponseDto GetAddress()
    {
        return new ResponseDto()
        {
            MessageToClient = "Successfully got all addresses",
            ResponseData = _addressService.GetAdress()
        };
    }

    [HttpPost]
    [Route("/address/post")]
    public ResponseDto PostAddress([FromBody] AddressModel addressModel)
    {
        return new ResponseDto()
        {
            MessageToClient = "Successfully created a new entry of address",
            ReponseData = _addressService.PostAddress(addressModel)
        };
    }
}