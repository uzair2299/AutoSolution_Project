using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services
{
    public class TransmissionTypeRepository : AutoSolutionRepository<TransmissionType>, ITransmissionTypeRepository
    {
        public TransmissionTypeRepository(AutoSolutionContext context) : base(context) { }

        public bool isExist(string TransmissionType)
        {
            return AutoSolutionContext.TransmissionTypes.Any(x => x.TransmissionTypeName.Trim().ToLower() == TransmissionType.Trim().ToLower());
        }

        public AutoSolutionContext AutoSolutionContext
        {
            get { return Context as AutoSolutionContext; }
        }
    }
}
