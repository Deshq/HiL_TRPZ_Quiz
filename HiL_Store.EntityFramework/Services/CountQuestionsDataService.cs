
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
    public class CountQuestionsDataService : ICountQuestionsService
    {
        private readonly HiLDbContextCreate _contextFactory;
        private readonly NonQueryDataService<CountQuestions> _nonQueryDataService;

        public CountQuestionsDataService(HiLDbContextCreate contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<CountQuestions>(contextFactory);
        }

        public async Task<CountQuestions> Create(CountQuestions entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<CountQuestions> Get(int id)
        {
            using (HiLDbContext context = _contextFactory.CreateDbContext())
            {
                CountQuestions entity = await context.CountOfQuestions
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<CountQuestions>> GetAll()
        {
            using (HiLDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<CountQuestions> entities = await context.CountOfQuestions
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<CountQuestions> Update(int id, CountQuestions entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
