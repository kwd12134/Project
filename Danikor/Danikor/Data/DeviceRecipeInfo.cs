using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public  class DeviceRecipeInfo
    {

        /// <summary>
        /// 配方名称
        /// </summary>
        public string RecipeName { get; set; }

        /// <summary>
        /// 配方参数
        /// </summary>
        public RecipeParameter RecipeParameters { get; set; }

    }
}
