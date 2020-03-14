using AutoSolution.Entities;
using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.IUnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        ICityRepository City { get; }
        IProvinceRepository Province { get; }
        IServiceCategoryRepository ServiceCategory { get; }

        int Complete();
    }
}
