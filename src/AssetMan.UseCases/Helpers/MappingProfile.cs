using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AssetMan.CoreBusiness;
using AssetMan.UseCases.DTO;


namespace AssetMan.UseCases.Helpers
{
    public class MappingProfile: Profile
    {
       public MappingProfile()
        {

            CreateMap<Asset, AssetDTO>();
            CreateMap<AssetDTO, Asset>();
            CreateMap<AssetView, AssetViewDTO>();

            CreateMap<Contact, ContactDTO>();
            CreateMap<ContactDTO, Contact>();


            CreateMap<Location, LocationDTO>();
            CreateMap<LocationDTO, Location>();


            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<CategoryInFinance, CategoryInFinanceDTO>();
            CreateMap<CategoryInFinanceDTO, CategoryInFinance>();

        }
    }
    
}
