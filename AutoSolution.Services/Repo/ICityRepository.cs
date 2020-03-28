using AutoSolution.Entities;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.Repo
{
    public interface ICityRepository: IRepository<City>
    {
        List<City> GetCityWithRespectToProvince(int Id);
    }
}
