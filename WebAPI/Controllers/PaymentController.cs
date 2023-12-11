using Business.Abstract;
using Entities.Concrete;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NUnit.Framework;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Diagnostics;
using Iyzipay;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using WebAPI.Hubs;
using System.Threading.Tasks;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        IPaymentService _paymentService;
        private readonly IHubContext<PayHub> _hubContext;

        public PaymentController(IPaymentService paymentService, IHubContext<PayHub> hubContext)
        {
            _paymentService = paymentService;
            _hubContext = hubContext;
        }
        Iyzipay.Options options = new Iyzipay.Options
        {
            ApiKey = "sandbox-5qWbldcKyN6tQHY6mauKzPh4JtOjFzrT",
            SecretKey = "sandbox-FnsVgbFrYFy8Rmtv5fjDJ1dGoQHQxLF2",
            BaseUrl = "https://sandbox-api.iyzipay.com"
        };

        [HttpPost("add")]
        public IActionResult Add(Entities.Concrete.Payment payment)
        {
            var result = _paymentService.Add(payment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("initializeCheckoutForm")]
        public IActionResult InitializeCheckoutForm([FromBody] string price)
        {


            void PrintResponse<T>(T resource)
            {
                TraceListener consoleListener = new ConsoleTraceListener();
                Trace.Listeners.Add(consoleListener);
                Trace.WriteLine(JsonConvert.SerializeObject(resource, new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }));
            }

            CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest();
            request.Locale = Locale.EN.ToString();
            request.ConversationId = Guid.NewGuid().ToString();
            request.Price = "1";
            request.PaidPrice = price;
            request.Currency = Currency.USD.ToString();
            request.BasketId = "B67832";
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();


            request.CallbackUrl = "https://apiv2.rentacar.yeyilmaz.online/api/Payment/retrievePaymentResult";
            //request.CallbackUrl = "https://localhost:5001/api/Payment/retrievePaymentResult";

            List<int> enabledInstallments = new List<int>();
            enabledInstallments.Add(2);
            enabledInstallments.Add(3);
            enabledInstallments.Add(6);
            enabledInstallments.Add(9);
            request.EnabledInstallments = enabledInstallments;

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = "John";
            buyer.Surname = "Doe";
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem();
            firstBasketItem.Id = "BI101";
            firstBasketItem.Name = "Binocular";
            firstBasketItem.Category1 = "Collectibles";
            firstBasketItem.Category2 = "Accessories";
            firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            firstBasketItem.Price = "0.3";
            basketItems.Add(firstBasketItem);

            BasketItem secondBasketItem = new BasketItem();
            secondBasketItem.Id = "BI102";
            secondBasketItem.Name = "Game code";
            secondBasketItem.Category1 = "Game";
            secondBasketItem.Category2 = "Online Game Items";
            secondBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
            secondBasketItem.Price = "0.5";
            basketItems.Add(secondBasketItem);

            BasketItem thirdBasketItem = new BasketItem();
            thirdBasketItem.Id = "BI103";
            thirdBasketItem.Name = "Usb";
            thirdBasketItem.Category1 = "Electronics";
            thirdBasketItem.Category2 = "Usb / Cable";
            thirdBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            thirdBasketItem.Price = "0.2";
            basketItems.Add(thirdBasketItem);
            request.BasketItems = basketItems;

            CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(request, options);
           
            
            return Ok(checkoutFormInitialize);
        }


        [HttpPost("retrievePaymentResult")]
        public async  Task<IActionResult> RetrievePaymentResult([FromForm] IFormCollection collections)
        {
            RetrieveCheckoutFormRequest request = new RetrieveCheckoutFormRequest();
            request.Token = collections["Token"];

            CheckoutForm checkoutForm = CheckoutForm.Retrieve(request, options);

            if (checkoutForm.Status != "success")
            {
                return BadRequest("Payment is not successful");
            }
            
            await _hubContext.Clients.Client(PayHub.TransactionConnections[request.Token]).SendAsync("Receive", checkoutForm);

            return Ok();
            
        }

    }

}













