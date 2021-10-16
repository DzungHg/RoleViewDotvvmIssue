﻿using AssetMan.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetMan.UseCases.DTO;

namespace AssetMan.UseCases.FinnCategoryScreen
{
    public interface ICreateFinanceCategoryUseCase
    {
        Task Execute(CategoryInFinanceDTO categoryDTO);
    }
}
