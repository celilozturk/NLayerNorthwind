﻿using NorthwindExample.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindExample.Core.Services
{
    public interface ICategoryService:IService<Category>
    {
        Task<Category> GetSingleCategoryByIdWithProdyctsAsync(int categoryId);
    }
}
