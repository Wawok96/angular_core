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
    public class UpdateHouseUseCase : ICommandHandler<UpdateHouseCommand>
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateHouseUseCase(IHouseRepository houseRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _houseRepository = houseRepository;
        }
        public async Task Handle(UpdateHouseCommand command)
        {
            _houseRepository.Update(new House(command.Name, command.SizeInMeters,command.SingleFloor), command.Id);
            await _unitOfWork.Save();
        }
    }
}
