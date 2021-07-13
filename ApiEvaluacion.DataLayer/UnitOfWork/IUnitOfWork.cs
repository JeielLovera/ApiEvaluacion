using ApiEvaluacion.DataLayer.Repositories.Interfaces;
using System;

namespace ApiEvaluacion.DataLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository userRepository { get; }
        IJobSectorRepository jobSectorRepository { get; }
        IActivityRepository activityRepository { get; }
        IEmployeeRepository employeeRepository { get; }
        IQuestionnaireRepository questionnaireRepository { get; }
    }
}
