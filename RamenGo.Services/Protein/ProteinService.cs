using RamenGo.Communication.Responses;
using RamenGo.Infrastructure.DbContexts;
using RamenGo.Services.Protein.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo.Services.Protein
{
    public class ProteinService
    {
        private RamenGoDbContext _dbContext { get; set; }
        private DbInitialiazer _initialiazer { get; set; }

        public ProteinService(RamenGoDbContext dbContext, DbInitialiazer initialiazer)
        {
            _dbContext = dbContext;
            _initialiazer = initialiazer;
            _initialiazer.InitiateAsync().Wait();
        }

        public async Task<List<ProteinResponse>> GetAllAsync()
        {
            var listProtein = new List<ProteinResponse>();
            if (_dbContext == null) throw new ProteinException("Error in Database");

            foreach (var protein in _dbContext.Proteins)
                listProtein.Add(new ProteinResponse()
                {
                    Id = protein.Id,
                    Description = protein.Description,
                    ImageActive = protein.ImageActive,
                    ImageInactive = protein.ImageInactive,
                    Name = protein.Name,
                    Price = protein.Price
                });

            return listProtein;
        }
    }
}
