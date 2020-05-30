using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Controllers
{
    public class PlaceOrderController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: PlaceOrder
        public ActionResult Index(int?id)
        {
            if (id == 1)
            {
                var province = new ProvinceRepository(new AutoSolutionContext());
                var city = new CityRepository(new AutoSolutionContext());
                ShipmentViewModel shipmentViewModel = new ShipmentViewModel()
                {
                    ProvincesList = province.GetProvinces(),
                    CitiesList = city.GetCities(),
                    CartWrapper = (CartWrapper)Session["AddToCart"]

                };
                return View("Shipment", shipmentViewModel);
            }
            else if (Session["UserID"] != null)
            { 
                int Id = Convert.ToInt32(Session["UserId"]);
                var user = _unitOfWork.User.GetByID(Id);
                var province = new ProvinceRepository(new AutoSolutionContext());
                var city = new CityRepository(new AutoSolutionContext());
                ShipmentViewModel shipmentViewModel = new ShipmentViewModel()
                {
                    UserId = user.UserId,
                    First_Name = user.FirstName,
                    Last_Name = user.LastName,
                    MobileNumber = user.MobileNumber,
                    ProvincesList = province.GetProvinces(),
                    CitiesList = city.GetCities(),
                   CartWrapper = (CartWrapper)Session["AddToCart"]

            };

                return View("Shipment", shipmentViewModel);
            }
            else
            {
                return View("Check");
            }
            
        }

        [HttpPost]
        public ActionResult shipment(ShipmentViewModel shipmentViewModel)
        {
            CartWrapper cart = new CartWrapper();
            cart = (CartWrapper)Session["AddToCart"];
            Order order = new Order()
            {
                First_Name = shipmentViewModel.First_Name,
                Last_Name = shipmentViewModel.Last_Name,
                MobileNumber = shipmentViewModel.MobileNumber,
                ShippingAddress = shipmentViewModel.ShippingAddress,
                CityId = Convert.ToInt32(shipmentViewModel.SelectedCity),
                OrderDate = DateTime.Now,
                TaxAmount = cart.Tax,
                TotalAmount = cart.Total,
                SubTotal = cart.SubTotal,
                UserId = shipmentViewModel?.UserId,
                OrderStatusId = 1,
                OrderDetails = OrderDetails(cart)
            };
          Order orderNo =  _unitOfWork.Order.Add(order);
          _unitOfWork.Complete();
            _unitOfWork.Dispose();
            Session["AddToCart"] = null;
            return RedirectToAction("Invoice", orderNo);
        }
     
        public ActionResult Invoice(Order order)
        {
            var orderposted = _unitOfWork.Order.GetByID(order.OrderId);
            InvoiceViewModel invoiceViewModel = new InvoiceViewModel();

            invoiceViewModel.OrderId = orderposted.OrderId;
            invoiceViewModel.First_Name = orderposted.First_Name;
            invoiceViewModel.Last_Name = orderposted.Last_Name;
            invoiceViewModel.OrderDate = orderposted.OrderDate;
            invoiceViewModel.MobileNumber = orderposted.MobileNumber;
            invoiceViewModel.ShippingAddress = orderposted.ShippingAddress;
            invoiceViewModel.SelectedCity = orderposted.Cities.CityName;
            invoiceViewModel.SelectedProvince = orderposted.Cities.Province.ProvinceName;
            invoiceViewModel.SubTotal = orderposted.SubTotal;
            invoiceViewModel.TaxAmount = orderposted.TaxAmount;
            invoiceViewModel.TotalAmount = orderposted.TotalAmount;
            invoiceViewModel.orderDetails = orderDetails(orderposted.OrderDetails.ToList());
            return View(invoiceViewModel);
        }

        public List<OrderDetailViewModel> orderDetails(List<OrderDetail> order)
        {
            List<OrderDetailViewModel> list = new List<OrderDetailViewModel>();
            foreach(var item in order)
            {
                OrderDetailViewModel orderDetail = new OrderDetailViewModel();
                orderDetail.PartsProductName = item.PartsProduct.PartsProductName;
                orderDetail.ProductUnitPrice = item.ProductUnitPrice;
                orderDetail.Quantity = item.Quantity;
                list.Add(orderDetail);
            }
                return list;
        }


        public List<OrderDetail> OrderDetails(CartWrapper cart)
        {
            List<OrderDetail> ord = new List<OrderDetail>();
            if (cart.PartsProductsViewModelList.Count >= 0 && cart.PartsProductsViewModelList != null)
            {
                foreach (var item in cart.PartsProductsViewModelList)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.PartsProductId = item.PartsProductId;
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.ProductUnitPrice = item.UnitPrice;
                    orderDetail.ItemQuanitiyPrice = (item.UnitPrice * item.Quantity);
                    orderDetail.Discount = 0;
                    orderDetail.ProductUnitPriceAfterDiscount = 0;
                    ord.Add(orderDetail);
                }
            }
            return ord;
        }
    }
}