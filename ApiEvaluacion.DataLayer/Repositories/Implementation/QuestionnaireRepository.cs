using ApiEvaluacion.DataLayer.Context;
using ApiEvaluacion.DataLayer.Repositories.Interfaces;
using ApiEvaluacion.DomainLayer.Entities;
using ApiEvaluacion.DomainLayer.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEvaluacion.DataLayer.Repositories.Implementation
{
    public class QuestionnaireRepository : Repository<Questionnaire>, IQuestionnaireRepository
    {
        public QuestionnaireRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<QuestionnaireResponse>> GetAllDetail()
        {
            var questionnaires = await _context.Questionnaires
                .Select(q => new QuestionnaireResponse 
                {
                    Id = q.Id,

                    NamesEmployee = _context.Users
                        .Where(us => us.Id == q.UserId)
                        .Select(us => us.Employee.NamesEmployee)
                        .FirstOrDefault(),

                    NameActivity = _context.Activities
                        .Where(act => act.Id == q.ActivityId)
                        .Select(act => act.NameActivity)
                        .FirstOrDefault(),

                    NameJob = _context.JobSectors
                        .Where(jb => jb.Id == q.JobSectorId)
                        .Select(jb => jb.NameJob)
                        .FirstOrDefault(),

                    NamesSupervisor = _context.Employees
                        .Where(emp => emp.Id == q.SupervisorId)
                        .Select(emp => emp.NamesEmployee)
                        .FirstOrDefault(),

                    Supervised = q.Supervised,
                    Comment = q.Comment,
                    DateQuestionnaire = q.DateQuestionnaire,
                }).ToListAsync();

            return questionnaires;
        }

        public async Task<QuestionnaireResponse> GetDetailById(int id)
        {
            var questionnaires = await _context.Questionnaires
                .Where(q => q.Id == id)
                .Select(q => new QuestionnaireResponse
                {
                    Id = q.Id,

                    NamesEmployee = _context.Users
                        .Where(us => us.Id == q.UserId)
                        .Select(us => us.Employee.NamesEmployee)
                        .FirstOrDefault(),

                    NameActivity = _context.Activities
                        .Where(act => act.Id == q.ActivityId)
                        .Select(act => act.NameActivity)
                        .FirstOrDefault(),

                    NameJob = _context.JobSectors
                        .Where(jb => jb.Id == q.JobSectorId)
                        .Select(jb => jb.NameJob)
                        .FirstOrDefault(),

                    NamesSupervisor = _context.Employees
                        .Where(emp => emp.Id == q.SupervisorId)
                        .Select(emp => emp.NamesEmployee)
                        .FirstOrDefault(),

                    Supervised = q.Supervised,
                    Comment = q.Comment,
                    DateQuestionnaire = q.DateQuestionnaire,
                }).FirstOrDefaultAsync();

            return questionnaires;
        }
    }
}
