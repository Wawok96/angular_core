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
    public class DeleteHouseUseCase : ICommandHandler<DeleteHouseCommand>
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteHouseUseCase(IHouseRepository houseRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _houseRepository = houseRepository;
        }
        public async Task Handle(DeleteHouseCommand command)
        {
            _houseRepository.EnsureThatHouseExist(command.Name);
            _houseRepository.Delete(command.Name);
            await _unitOfWork.Save();
        }

    }
}
