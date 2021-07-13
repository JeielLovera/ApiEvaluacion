using ApiEvaluacion.DataLayer.Context;
using ApiEvaluacion.DataLayer.Repositories.Implementation;
using ApiEvaluacion.DataLayer.Repositories.Interfaces;

namespace ApiEvaluacion.DataLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUserRepository userRepository { get; private set; }
        public IJobSectorRepository jobSectorRepository { get; private set; }
        public IActivityRepository activityRepository { get; private set; }
        public IEmployeeRepository employeeRepository { get; private set; }
        public IQuestionnaireRepository questionnaireRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            this.userRepository = new UserRepository(_context);
            this.jobSectorRepository = new JobSectorRepository(_context);
            this.activityRepository = new ActivityRepository(_context);
            this.employeeRepository = new EmployeeRepository(_context);
            this.questionnaireRepository = new QuestionnaireRepository(_context);
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }
    }
}
