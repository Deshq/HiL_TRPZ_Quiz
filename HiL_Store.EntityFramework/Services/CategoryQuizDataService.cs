using HiL_Store.Domain.Entities.QuizEntities;
using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.EntityFramework.Services
{
    public class CategoryQuizDataService : ICategoryQuizService
    {
        private readonly HiLDbContextCreate _contextFactory;
        private readonly NonQueryDataService<CategoryQuiz> _nonQueryDataService;

        public CategoryQuizDataService(HiLDbContextCreate contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<CategoryQuiz>(contextFactory);
        }

        public async Task<CategoryQuiz> Create(CategoryQuiz entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<CategoryQuiz> Get(int id)
        {
            using (HiLDbContext context = _contextFactory.CreateDbContext())
            {
                CategoryQuiz entity = await context.CategoryQuizzes
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<CategoryQuiz>> GetAll()
        {
            using (HiLDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<CategoryQuiz> entities = await context.CategoryQuizzes
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<CategoryQuiz> GetQuizByCategory(Category entity)
        {
            using (HiLDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.CategoryQuizzes
                    .Include(a => a.Quiz)
                    .FirstOrDefaultAsync(a => a.Category == entity);
            }
        }

        public List<CategoryQuiz> GetQuizByCategory2(Category entity)
        {
            using (HiLDbContext context = _contextFactory.CreateDbContext())
            {
                IQueryable<CategoryQuiz> data = (from bm in context.CategoryQuizzes
                                                 join
                                                 b in context.Categories on bm.CategoryID equals b.Id
                                                 join m in context.Quizzes on bm.QuizID equals m.Id
                                                 where bm.CategoryID == entity.Id
                                                 select bm)
                                            .Include(p => p.Quiz);
                                           
                return data.ToList();         
            }
        }

        public async Task<CategoryQuiz> Update(int id, CategoryQuiz entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
