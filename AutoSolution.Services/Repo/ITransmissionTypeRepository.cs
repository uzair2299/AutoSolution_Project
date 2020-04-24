using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services.Repo
{
    public interface ITransmissionTypeRepository: IRepository<TransmissionType>
    {
        bool isExist(string TransmissionType);
        IEnumerable<SelectListItem> GetTransmissionTypeDownEmpty();
        IEnumerable<SelectListItem> GetTransmissionDropDown();
    }
}
