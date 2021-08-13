using Insig.ApplicationServices.Boundaries;
using Insig.Common.CQRS;
using Insig.Domain;
using Insig.Domain.Houses;
using Insig.PublishedLanguage.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insig.ApplicationServices.UseCases
{
    public class AddHouseUseCase : ICommandHandler<AddHouseCommand>
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddHouseUseCase(IHouseRepository houseRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _houseRepository = houseRepository;
        }

        public async Task Handle(AddHouseCommand command)
        {
            _houseRepository.EnsureThatHouseDoesNotExist(command.Name);
            _houseRepository.Store(new House(command.Name, command.SizeInMeters, command.SingleFloor));
            await _unitOfWork.Save();
        }
    }
}
