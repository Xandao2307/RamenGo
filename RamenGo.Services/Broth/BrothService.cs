using RamenGo.Services.Responses.Exceptions;
using RamenGo.Communication.Responses;
using RamenGo.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RamenGo.Services.Broth
{
    public class BrothService
    {
        private RamenGoDbContext _dbContext { get; set; }

        public BrothService(RamenGoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BrothResponse>> GetAllAsync()
        {
            var listBroth = new List<BrothResponse>();
            if (_dbContext != null) throw new BrothException("Error in Database");

            foreach (var broth in _dbContext.Broths)
                listBroth.Add(new BrothResponse()
                {
                    Id = broth.Id,
                    Description = broth.Description,
                    ImageActive = broth.ImageActive,
                    ImageInactive = broth.ImageInactive,
                    Name = broth.Name,
                    Price = broth.Price
                });
            
            return listBroth;
        }
    }
}
