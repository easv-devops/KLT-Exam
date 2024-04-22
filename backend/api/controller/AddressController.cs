using api.TransferModels;
using infrastructure.dataModels;
using Microsoft.AspNetCore.Mvc;
using service.services;

namespace api.controller;

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
            ResponseData = _addressService.GetAddress()
        };
    }

    [HttpPost]
    [Route("/address/post")]
    public ResponseDto PostAddress([FromBody] AddressModel addressModel)
    {
        return new ResponseDto()
        {
            MessageToClient = "Successfully created a new entry of address",
            ResponseData = _addressService.PostAddress(addressModel)
        };
    }
}