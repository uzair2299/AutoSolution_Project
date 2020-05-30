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

        public ActionResult ViewCart(int? id, int? quantity)
        {
            if (id != null)
            {
                int Quantity = 0;
                if (Session["AddToCart"] != null)
                {
                    CartWrapper Cart = (CartWrapper)Session["AddToCart"];
                    if(quantity==null || quantity >= 1)
                    {
                         Quantity = quantity.HasValue ? quantity.Value > 0 ? quantity.Value : 1 : 1;

                    }
                    else
                    {
                        Quantity = (int)quantity;
                    }
                    var item = _unitOfWork.PartsProducts.PartProductDetail(id, Quantity);
                    foreach (var CartItem in Cart.PartsProductsViewModelList)
                    {
                        if (CartItem.PartsProductId == item.PartsProductId)
                        {
                            CartItem.Quantity = CartItem.Quantity + item.Quantity;
                            Cart.SubTotal = (item.UnitPrice * item.Quantity) + Cart.SubTotal;
                            break;
                        }
                    }

                    Cart.Tax = Cart.SubTotal * (decimal).16;
                    Cart.Total = Cart.Tax + Cart.SubTotal;
                    Session["AddToCart"] = Cart;
                }
            }
            return PartialView("_ViewCart");
        }



        //[ChildActionOnly]
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
                    if (Quantity >= 1)
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
                            Session["AddToCart"] = Cart;
                            return PartialView("_AutoSolutionCart");

                        }
                        else {
                            foreach (var CartItem in Cart.PartsProductsViewModelList)
                            {
                                if (CartItem.PartsProductId == item.PartsProductId)
                                {
                                    CartItem.Quantity = CartItem.Quantity + item.Quantity;
                                    Cart.SubTotal = (item.UnitPrice * item.Quantity) + Cart.SubTotal;
                                    IsInCart = true;
                                    break;
                                }
                            }
                            if (IsInCart != true)
                            {

                                Cart.PartsProductsViewModelList.Add(item);
                                Cart.SubTotal = (item.UnitPrice * item.Quantity) + Cart.SubTotal;
                                IsInCart = false;


                            }
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

        [Authorize]
        public ActionResult AddToWishList(int id)
        {
            int userId =Convert.ToInt32(Session["UserID"]);
            var widhlistItem = _unitOfWork.WishList.AddToWishList(id, userId);
            bool result = false;
            if (widhlistItem != null)
            {
                _unitOfWork.WishList.Add(widhlistItem);
                _unitOfWork.Complete();
                _unitOfWork.Dispose();
                result = true;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            
        }


        public ActionResult ClearCart()
        {
            Session["AddToCart"] = null;
            return RedirectToAction("Index");
        }
    }
}