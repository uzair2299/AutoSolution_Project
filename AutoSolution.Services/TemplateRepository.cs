using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.Repo;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services
{
    public class TemplateRepository : AutoSolutionRepository<Template>, ITemplateRepository
    {
        public TemplateRepository(AutoSolutionContext context): base(context){}


        public bool isExist(string TemplateShortCode)
        {
            return AutoSolutionContext.Templates.Any(x => x.TemplateShortCode.Trim().ToLower() == TemplateShortCode.Trim().ToLower());
        }

        public TemplateViewModel GetTemplate(int PageNo, int TotalCount)
        {

            var templateViewModel = new TemplateViewModel()
            {
                TemplateList = AutoSolutionContext.Templates.OrderBy(x => x.TemplateTitle).Skip((PageNo - 1) * 10).Take(10).ToList(),
                Pager = new Pager(TotalCount, PageNo, 10)

            };
            return templateViewModel;
        }

        public TemplateViewModel GetTemplate(int PageNo, int TotalCount, string SearchTerm)
        {
            var templateViewModel = new TemplateViewModel()
            {

                TemplateList = AutoSolutionContext.Templates.OrderBy(x => x.TemplateTitle).Where(x => x.TemplateTitle.Contains(SearchTerm)).Skip((PageNo - 1) * 10).Take(10).ToList(),
                Pager = new Pager(TotalCount, PageNo, 10)

            };
            return templateViewModel;


        }

        public int GetTemplateCount(string SearchTerm)
        {
            return AutoSolutionContext.Templates.OrderBy(x => x.TemplateTitle).Where(x => x.TemplateTitle.Contains(SearchTerm)).Count();

        }

        public AutoSolutionContext AutoSolutionContext
        {
            get { return Context as AutoSolutionContext; }
        }
    }
}

