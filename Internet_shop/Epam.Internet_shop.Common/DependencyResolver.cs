﻿using Epam.Internet_shop.Logger.Log4net;
using Epam.Internet_shop.Logger.Contracts;
using Epam.Internet_shop.DAL.Contracts;
using Epam.Internet_shop.BLL.Contracts;
using Epam.Internet_shop.BLL.TestForPL;
using Epam.Internet_shop.BLL;

namespace Epam.Internet_shop.Common
{
    public static class DependencyResolver
    {
        public static ILogger Logger { get; }

        public static IRoleDao RoleDao { get; }
        public static IUserDao UserDao { get; }
        public static ICategoryDao CategoryDao { get; }
        public static IProductDao ProductDao { get; }
        public static IStoreDao StoreDao { get; }
        public static IVendorDao VendorDao { get; }
        public static IStatusDao StatusDao { get; }
        public static ICommodityUnitDao CommodityUnitDao { get; }

        public static IRoleBll RoleBll { get; }
        public static IUserBll UserBll { get; }
        public static IAuthenticationBll AuthenticationBll { get; }
        public static ICategoryBll CategoryBll { get; }
        public static IProductBll ProductBll { get; }
        public static IStoreBll StoreBll { get; }
        public static IVendorBll VendorBll { get; }
        public static IStatusBll StatusBll { get; }
        public static ICommodityUnitBll CommodityUnitBll { get; }

        static DependencyResolver()
        {
            Logger = new Log4net();
            
            RoleBll = new TestRoleBll();
            UserBll = new TestUserBll();

            AuthenticationBll = new AuthenticationBll(UserBll);

            CategoryBll = new TestCategoryBll();
            ProductBll = new TestProductBll();
            StoreBll = new TestStoreBll();
            VendorBll = new TestVendorBll();
            StatusBll = new TestStatusBll();
            CommodityUnitBll = new TestCommodityUnitBll();
        }
    }
}
