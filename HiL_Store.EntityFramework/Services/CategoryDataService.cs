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
    public class CategoryDataService : ICategoryService
    {
        private readonly HiLDbContextCreate _contextFactory;
        private readonly NonQueryDataService<Category> _nonQueryDataService;

        public CategoryDataService(HiLDbContextCreate contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Category>(contextFactory);
        }

        public async Task<Category> Create(Category entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Category> Get(int id)
        {
            using (HiLDbContext context = _contextFactory.CreateDbContext())
            {
                Category entity = await context.Categories
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            using (HiLDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Category> entities = await context.Categories
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<Category> GetByCategory(string categoryName)
        {
            using (HiLDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Categories
                    .FirstOrDefaultAsync(a => a.Name == categoryName);
            }
        }

        public async Task<Category> Update(int id, Category entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
