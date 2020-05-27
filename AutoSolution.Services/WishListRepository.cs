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
    public class WishListRepository: AutoSolutionRepository<WishList>, IWishListRepository
    {
      
        public WishListRepository(AutoSolutionContext context)
         : base(context)
        {
        }

        public WishList AddToWishList(int partProductId, int UserId)
        {
           
            bool result = AutoSolutionContext.WishLists.Any(x => x.PartsProductId == partProductId && x.UserId == UserId);
            if (result != true)
            {
                WishList wishList = new WishList()
                {
                    PartsProductId = partProductId,
                    UserId = UserId,
                    DateTime = DateTime.Now
                };


                return wishList;
            }
            else
            {
                return null;
            }
            
        }

        public AutoSolutionContext AutoSolutionContext
        {
            get { return Context as AutoSolutionContext; }
        }
    }
}
