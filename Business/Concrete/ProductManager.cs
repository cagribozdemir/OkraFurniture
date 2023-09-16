﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        public IResult Add(CreateProductDto createProductDto)
        {
            Product product = new Product();

            Category category = new Category();
            category.Id = createProductDto.CategoryId;

            product.Name = createProductDto.Name;
            product.Code = createProductDto.Code;
            product.Price = createProductDto.Price;
            product.Category = category;
            product.Status = true;

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public void Delete(int id)
        {
            Product product = _productDal.Get(p => p.Id == id);
            _productDal.Delete(product);
        }

        public List<ResultProductDto> GetAll()
        {
            List<ResultProductDto> resultProductDtos = new List<ResultProductDto>();
            var products = _productDal.GetAll();

            foreach (var product in products)
            {
                ResultProductDto resultProductDto = new ResultProductDto();
                resultProductDto.Id = product.Id;
                resultProductDto.Name = product.Name;
                resultProductDto.Code = product.Code;
                resultProductDto.Price = product.Price;
                resultProductDto.CategoryName = _categoryService.GetById(product.CategoryId).Name;

                resultProductDtos.Add(resultProductDto);
            }

            return resultProductDtos;
        }

        public List<ResultProductDto> GetAllByCategoryId(int id)
        {
            List<ResultProductDto> resultProductDtos = new List<ResultProductDto>();
            var products = _productDal.GetAll(p => p.CategoryId == id);

            foreach (var product in products)
            {
                ResultProductDto resultProductDto = new ResultProductDto();
                resultProductDto.Id = product.Id;
                resultProductDto.Name = product.Name;
                resultProductDto.Code = product.Code;
                resultProductDto.Price = product.Price;
                resultProductDto.CategoryName = _categoryService.GetById(product.CategoryId).Name;

                resultProductDtos.Add(resultProductDto);
            }

            return resultProductDtos;
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.Id == id);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);

            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
