using AutoSolution.Database.DataBaseContext;
using AutoSolution.Services;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Views.Home
{
    public class CartController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewCart()
        {
            return PartialView("_ViewCart");
        }

        public ActionResult AddToCart(int? id, int? quantity)
        {
            if (id != null)
            {
                if (Session["AddToCart"] == null)
                {
                    int Quantity = quantity.HasValue ? quantity.Value > 0 ? quantity.Value : 1 : 1;
                    var item = _unitOfWork.PartsProducts.PartProductDetail(id, Quantity);
                    List<PartsProductsViewModel> Cart = new List<PartsProductsViewModel>();
                    Cart.Add(item);

                    CartWrapper cartWarpper = new CartWrapper();
                    cartWarpper.PartsProductsViewModelList = Cart;
                    cartWarpper.SubTotal = item.UnitPrice * item.Quantity;
                    cartWarpper.Tax = (cartWarpper.SubTotal * (decimal).16);
                    cartWarpper.Total = cartWarpper.SubTotal + cartWarpper.Tax;
                    Session["AddToCart"] = cartWarpper;
                }
                else
                {
                    bool IsInCart = false;
                    CartWrapper Cart = (CartWrapper)Session["AddToCart"];
                    int Quantity = quantity.HasValue ? quantity.Value > 0 ? quantity.Value : 1 : 1;
                    var item = _unitOfWork.PartsProducts.PartProductDetail(id, Quantity);
                    if (Quantity == 1)
                    {
                        if (Cart.PartsProductsViewModelList.Count == 0)
                        {
                            Cart.SubTotal = 0;
                            Cart.Tax = 0;
                            Cart.Total = 0;
                            Cart.PartsProductsViewModelList.Add(item);
                            Cart.SubTotal = item.UnitPrice * item.Quantity;
                            Cart.Tax = (Cart.SubTotal * (decimal).16);
                            Cart.Total = Cart.SubTotal + Cart.Tax;
                        }
                        else
                            foreach (var CartItem in Cart.PartsProductsViewModelList)
                            {
                                if (CartItem.PartsProductId == item.PartsProductId)
                                {
                                    CartItem.Quantity = CartItem.Quantity + 1;
                                    Cart.SubTotal = (item.UnitPrice * item.Quantity) + Cart.SubTotal;
                                    IsInCart = true;
                                    break;
                                }
                            }
                        if (IsInCart != true)
                        {

                            Cart.PartsProductsViewModelList.Add(item);
                            Cart.SubTotal = (item.UnitPrice * item.Quantity)+Cart.SubTotal;
                            IsInCart = false;
                         

                        }
                    }
                    Cart.Tax = Cart.SubTotal * (decimal).16;
                    Cart.Total = Cart.Tax + Cart.SubTotal;

                    Session["AddToCart"] = Cart;
                }


            }


            return PartialView("_AutoSolutionCart");
        }

        public ActionResult RemoveFromCart(int id)
        {
            CartWrapper Cart = (CartWrapper)Session["AddToCart"];
                  if (Cart.PartsProductsViewModelList.Count > 0)
            {
                foreach(var item in Cart.PartsProductsViewModelList)
                {
                    if (item.PartsProductId == id)
                    {
                        Cart.SubTotal = Cart.SubTotal - (item.Quantity * item.UnitPrice);
                        Cart.Tax = Cart.SubTotal * (decimal).16;
                        Cart.Total = Cart.SubTotal + Cart.Tax;
                        Cart.PartsProductsViewModelList.Remove(item);
                     break;
                    }
                }
            }
            Session["AddToCart"] = Cart;
            return PartialView("_ViewCart");
        }
    }
}