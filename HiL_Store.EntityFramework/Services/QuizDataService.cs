using HiL_Store.Domain.Entities.QuizEntities;
using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.EntityFramework.Services
{
    public class QuizDataService : IQuizService
    {
        private readonly HiLDbContextCreate _contextFactory;
        private readonly NonQueryDataService<Quiz> _nonQueryDataService;

        public QuizDataService(HiLDbContextCreate contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Quiz>(contextFactory);
        }

        public async Task<Quiz> Create(Quiz entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Quiz> Get(int id)
        {
            using (HiLDbContext context = _contextFactory.CreateDbContext())
            {
                Quiz entity = await context.Quizzes
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Quiz>> GetAll()
        {
            using (HiLDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Quiz> entities = await context.Quizzes
                    .ToListAsync();
                return entities;
            }
        }


        public async Task<Quiz> GetByQuestion(string question)
        {
            using (HiLDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Quizzes
                    .FirstOrDefaultAsync(a => a.Question == question);
            }
        }

        public async Task<Quiz> Update(int id, Quiz entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
