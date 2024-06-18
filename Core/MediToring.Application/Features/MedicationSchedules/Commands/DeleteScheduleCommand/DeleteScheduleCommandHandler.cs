using MediatR;
using MediToring.Application.Common.Exceptions;
using MediToring.Application.Interfaces;
using MediToring.Domain;
using MediToring.Domain.Medications;

namespace MediToring.Application.Features.MedicationSchedules.Commands.DeleteScheduleCommand;

public class DeleteScheduleCommandHandler(IMedicationScheduleRepository repository) 
    : IRequestHandler<DeleteScheduleCommand>
{
    public async Task Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
    {
        var schedule = await repository.Get(request.Id);

        if (schedule == null)
        {
            throw new NotFoundException(nameof(MedicationSchedule), request.Id);
        }

        repository.Delete(schedule);
        await repository.UnitOfWork.SaveEntitiesASync(cancellationToken);
    }
}