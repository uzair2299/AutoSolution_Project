using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services
{
    public class TransmissionTypeRepository : AutoSolutionRepository<TransmissionType>, ITransmissionTypeRepository
    {
        public TransmissionTypeRepository(AutoSolutionContext context) : base(context) { }

        public bool isExist(string TransmissionType)
        {
            return AutoSolutionContext.TransmissionTypes.Any(x => x.TransmissionTypeName.Trim().ToLower() == TransmissionType.Trim().ToLower());
        }

        public IEnumerable<SelectListItem> GetTransmissionTypeDownEmpty()
        {
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = (-1).ToString(),
                    Text = "------------- Select Vehicle TransmissionType --------------"
                }
            };
            return new SelectList(items, "value", "Text");
        }

        public IEnumerable<SelectListItem> GetTransmissionDropDown()
        {
            List<SelectListItem> items = Context.Set<TransmissionType>().OrderBy(n => n.TransmissionTypeName).Select(n => new SelectListItem
            {
                Value = n.TransmissionTypeId.ToString(),
                Text = n.TransmissionTypeName
            }).ToList();

            var Tip = new SelectListItem()
            {
                Value = null,
                Text = "------------- Select Vehicle TransmissionType --------------"
            };
            items.Insert(0, Tip);
            return new SelectList(items, "value", "Text");
        }


        public AutoSolutionContext AutoSolutionContext
        {
            get { return Context as AutoSolutionContext; }
        }
    }
}
