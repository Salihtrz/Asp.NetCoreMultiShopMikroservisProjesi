using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var value = await _repository.GetByIdAsync(updateAddressCommand.AddressID);
            value.AddressID = updateAddressCommand.AddressID;
            value.UserID = updateAddressCommand.UserID;
            value.Detail1 = updateAddressCommand.Detail1;
            value.City = updateAddressCommand.City;
            value.District = updateAddressCommand.District;
            await _repository.UpdateAsync(value);
        }
    }
}
