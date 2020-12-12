﻿using E_Shop_Cosmetic.Data.Interfaces;
using E_Shop_Cosmetic.Data.Models;
using E_Shop_Cosmetic.Data.Specifications;
using E_Shop_Cosmetic.Data.Specifications.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop_Cosmetic.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductsRepository
    {
        public ProductRepository(AppDBContext appDBContext) : base(appDBContext)
        {

        }

        public async Task AddProductAsync(Product product)
        {
            await AddAsync(product);
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await GetByIdAsync(productId);
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            var collection = await GetAllAsync();
            return collection.FirstOrDefault(n => n.Name.Equals(name));
        }

        public async Task<Product> GetProductByPriceAsync(int price)
        {
            var collection = await GetAllAsync();
            return collection.FirstOrDefault(n => n.Price == price);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync(ISpecification<Product> specification)
        {
            return await GetAllAsync(specification);
        }

        public async Task<IReadOnlyList<Product>> GetProductsByIdsAsync(IEnumerable<int> ids)
        {
            var specification = new ProductSpecification(prod => ids.Contains(prod.Id));
            return await GetAllAsync(specification);
        }

        public async Task<IReadOnlyList<Product>> GetProductListAsync(ISpecification<Product> specification)
        {
            return await GetAllAsync(specification);
        }

        public async Task DeleteProductAsync(Product product)
        {
            await DeleteAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await UpdateAsync(product);
        }
    }
}