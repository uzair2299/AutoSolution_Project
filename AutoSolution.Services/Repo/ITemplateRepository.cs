using AutoSolution.Entities;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.Repo
{
    public interface ITemplateRepository : IRepository<Template>
    {
        TemplateViewModel GetTemplate(int PageNo, int TotalCount);

        TemplateViewModel GetTemplate(int PageNo, int TotalCount, string SearchTerm);

        int GetTemplateCount(string SearchTerm);

        bool isExist(string TemplateShortCode);
    }
}
