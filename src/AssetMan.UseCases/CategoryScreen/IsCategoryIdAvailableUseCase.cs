using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AssetMan.CoreBusiness;
using AssetMan.UseCases.DTO;

using AssetMan.UseCases.RepositoryPlugins;

namespace AssetMan.UseCases.CategoryScreen
{
    public class IsCategoryIdAvailableUseCase : IIsCategoryIdAvailableUseCase
    {
        private readonly ICategoryRepository categoryRepository;
        
        public IsCategoryIdAvailableUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
            

        }            

        public async Task<bool> Execute(string id)
        {
            return await categoryRepository.IsCategoryIDAvailable(id);
        }
    }
}
