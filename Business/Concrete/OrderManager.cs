using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.DTOs.Order;
using Entity.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        IProductService _productService;
        IProductColorService _productColorService;
        IFootService _footService;
        IFootColorService _footColorService;
        IFabricService _fabricService;
        IProformaService _proformaService;
        ICategoryService _categoryService;

        public OrderManager(IOrderDal orderDal, IProductService productService, IProductColorService productColorService, 
            IFootColorService footColorService, IFabricService fabricService, IFootService footService, IProformaService proformaService,
            ICategoryService categoryService)
        {
            _orderDal = orderDal;
            _productService = productService;
            _productColorService = productColorService;
            _footColorService = footColorService;
            _fabricService = fabricService;
            _footService = footService;
            _proformaService = proformaService;
            _categoryService = categoryService;
        }

        public IResult Add(CreateOrderDto createOrderDto)
        {
            decimal totalPrice = createOrderDto.Price * createOrderDto.Amount * (100 - createOrderDto.Discount) / 100;
            Order order = new Order();
            Product product = new Product();
            ProductColor productColor = new ProductColor();
            Fabric fabric = new Fabric();
            Foot foot = new Foot();
            FootColor footColor = new FootColor();
            Proforma proforma = new Proforma();

            product.Id = createOrderDto.ProductId;
            productColor.Id = createOrderDto.ProductColorId;
            fabric.Id = createOrderDto.FabricId;
            foot.Id = createOrderDto.FootId;
            footColor.Id = createOrderDto.FootColorId;
            proforma.Id = createOrderDto.ProformaId;

            order.Amount = createOrderDto.Amount;
            order.Discount = createOrderDto.Discount;
            order.Piece = createOrderDto.Amount*4*4; //Hesap
            order.Price = createOrderDto.Price;
            order.Description = createOrderDto.Description;
            order.TotalPrice = totalPrice;
            order.Product = product;
            order.ProductColor = productColor;
            order.Fabric = fabric;
            order.Foot = foot;
            order.FootColor = footColor;
            order.Proforma = proforma;
            order.Status = true;

            _orderDal.Add(order);
            _proformaService.UpdateTotalPrice(order.ProformaId, totalPrice);
            return new SuccessResult(Messages.OrderAdded);
        }

        public void Delete(int id)
        {
            Order order = _orderDal.Get(o => o.Id == id);
            _proformaService.UpdateTotalPrice(order.ProformaId, order.TotalPrice * -1);
            _orderDal.Delete(order);
        }

        public List<ResultOrderDto> GetAll()
        {
            List<ResultOrderDto> resultOrderDtos = new List<ResultOrderDto>();
            var orders = _orderDal.GetAll();

            foreach (var order in orders)
            {
                ResultOrderDto resultOrderDto = new ResultOrderDto();

                resultOrderDto.Id = order.Id;
                resultOrderDto.Amount = order.Amount;
                resultOrderDto.ProductCode = _productService.GetById(order.ProductId).Code;
                resultOrderDto.ProductName = _productService.GetById(order.ProductId).Name;
                resultOrderDto.FabricName = _fabricService.GetById(order.FabricId).Name;
                resultOrderDto.ProductColorName = _productColorService.GetById(order.ProductColorId).Name;
                resultOrderDto.FootName = _footService.GetById(order.FootId).Name;
                resultOrderDto.FootColorName = _footColorService.GetById(order.FootColorId).Name;
                resultOrderDto.Piece = order.Piece;
                resultOrderDto.Discount = order.Discount;
                resultOrderDto.Price = order.Price;
                resultOrderDto.TotalPrice = order.TotalPrice;
                resultOrderDto.CategoryName = _categoryService.GetById(_productService.GetById(order.ProductId).CategoryId).Name;
                resultOrderDto.Description = order.Description;

                resultOrderDtos.Add(resultOrderDto);
            }
            return resultOrderDtos;
        }

        public List<ResultOrderDto> GetByProformaId(int proformmaId)
        {
            List<ResultOrderDto> resultOrderDtos = new List<ResultOrderDto>();
            var orders = _orderDal.GetAll(o => o.ProformaId == proformmaId);

            foreach (var order in orders)
            {
                ResultOrderDto resultOrderDto = new ResultOrderDto();

                resultOrderDto.Id = order.Id;
                resultOrderDto.Amount = order.Amount;
                resultOrderDto.ProductCode = _productService.GetById(order.ProductId).Code;
                resultOrderDto.ProductName = _productService.GetById(order.ProductId).Name;
                resultOrderDto.FabricName = _fabricService.GetById(order.FabricId).Name;
                resultOrderDto.ProductColorName = _productColorService.GetById(order.ProductColorId).Name;
                resultOrderDto.FootName = _footService.GetById(order.FootId).Name;
                resultOrderDto.FootColorName = _footColorService.GetById(order.FootColorId).Name;
                resultOrderDto.Piece = order.Piece;
                resultOrderDto.Discount = order.Discount;
                resultOrderDto.Price = order.Price;
                resultOrderDto.TotalPrice = order.TotalPrice;
                resultOrderDto.CategoryName = _categoryService.GetById(_productService.GetById(order.ProductId).CategoryId).Name;
                resultOrderDto.Description = order.Description;

                resultOrderDtos.Add(resultOrderDto);
            }
            return resultOrderDtos;
        }

        public Order GetById(int id)
        {
            return _orderDal.Get(o => o.Id == id);
        }

        public IResult Update(Order order)
        {
            decimal proformaTotalPrice = _orderDal.Get(o => o.Id == order.Id).TotalPrice * -1;
            decimal newTotalPrice = order.Price * order.Amount * (100 - order.Discount) / 100;
            order.Piece = order.Amount * 4 * 4;
            order.TotalPrice = newTotalPrice;

            proformaTotalPrice += newTotalPrice;
            _proformaService.UpdateTotalPrice(order.ProformaId, proformaTotalPrice);
            _orderDal.Update(order);

            return new SuccessResult(Messages.OrderUpdated);
        }
    }
}
