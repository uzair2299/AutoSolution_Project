using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services.ViewModel
{
    public class SelectYourInterest
    {
        public SelectYourInterest()
        {
            findYourMechanic = new FindYourMechanicViewModel();
            FindYourPart = new FindYourPartViewModel();
        }
        public FindYourMechanicViewModel findYourMechanic { get; set; }
        public FindYourPartViewModel FindYourPart { get; set; }

        public Pager Pager { get; set; }


    }
}
