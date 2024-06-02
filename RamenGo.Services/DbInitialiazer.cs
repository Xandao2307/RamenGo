using RamenGo.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo.Services
{
    public class DbInitialiazer
    {
        private RamenGoDbContext _dbContext { get; set; }
        public DbInitialiazer(RamenGoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InitiateAsync()
        {
            if (_dbContext.Broths.Any() && _dbContext.Proteins.Any() && _dbContext.Meals.Any())
                return;

            var broth = new Infrastructure.Entities.Broth()
            {
                Id = 1,
                Description = "Simple like the seawater, nothing more",
                ImageActive = "https://tech.redventures.com.br/icons/salt/active.svg",
                ImageInactive = "https://tech.redventures.com.br/icons/salt/inactive.svg",
                Name = "Salt",
                Price = 10,
            };
            var protein = new Infrastructure.Entities.Protein()
            {
                Id = 1,
                Description = "A sliced flavourful pork meat with a selection of season vegetables.",
                ImageActive = "https://tech.redventures.com.br/icons/pork/active.svg",
                ImageInactive = "https://tech.redventures.com.br/icons/pork/inactive.svg",
                Name = "Chasu",
                Price = 10,
            };
            var meal = new Infrastructure.Entities.Meal()
            {
                Id = 1,
                BrothId = broth.Id,
                Broth = broth,
                ProteinId = protein.Id,
                Protein = protein,
                Description = "Salt and Chasu Ramen",
                Image = "https://tech.redventures.com.br/icons/ramen/ramenChasu.png"

            };

            _dbContext.Broths.Add(broth);
            _dbContext.Proteins.Add(protein);
            _dbContext.Meals.Add(meal);

            await _dbContext.SaveChangesAsync();

        }

    }
}
