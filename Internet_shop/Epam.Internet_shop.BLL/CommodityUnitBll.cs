using System.Collections.Generic;
using System.Linq;

using Epam.Internet_shop.Logger.Contracts;
using Epam.Internet_shop.BLL.Contracts;
using Epam.Internet_shop.DAL.Contracts;
using Epam.Internet_shop.Common.Entities.CommodityUnit;

namespace Epam.Internet_shop.BLL
{
    public class CommodityUnitBll : ICommodityUnitBll
    {
        private readonly ILogger _logger;
        private readonly ICategoryDao _categoryDao;
        private readonly IProductDao _productDao;
        private readonly IStatusDao _statusDao;
        private readonly IStoreDao _storeDao;
        private readonly IVendorDao _vendorDao;
        private readonly ICommodityUnitDao _commodityUnitDao;

        public CommodityUnitBll(ILogger logger, ICategoryDao categoryDao, IProductDao productDao, IStatusDao statusDao, IStoreDao storeDao, IVendorDao vendorDao, ICommodityUnitDao commodityUnitDao)
        {
            _logger = logger;
            _categoryDao = categoryDao;
            _productDao = productDao;
            _statusDao = statusDao;
            _storeDao = storeDao;
            _vendorDao = vendorDao;
            _commodityUnitDao = commodityUnitDao;
        }

        public IEnumerable<CommodityUnit> GetAllCommodityUnits()
        {
            _logger.Info($"BLL.{nameof(CommodityUnitBll)}.{nameof(GetAllCommodityUnits)}: Getting all commodity units");

            return _commodityUnitDao.GetAllCommodityUnits();
        }

        public CommodityUnit GetCommodityUnitOrNull(int id)
        {
            _logger.Info($"BLL.{nameof(CommodityUnitBll)}.{nameof(GetCommodityUnitOrNull)}: Getting commodity units id = " + id);

            if (_commodityUnitDao.IsCommodityUnit(id))
            {
                _logger.Info($"BLL.{nameof(CommodityUnitBll)}.{nameof(GetCommodityUnitOrNull)}: Commodity units id = {id} received");

                return _commodityUnitDao.GetCommodityUnit(id);
            }
            else
            {
                _logger.Warn($"BLL.{nameof(CommodityUnitBll)}.{nameof(GetCommodityUnitOrNull)}: Commodity units id = {id} not found");

                return null;
            }
        }

        public IEnumerable<CommodityUnit> GetCommodityUnitsByCategory(int id)
        {
            _logger.Info($"BLL.{nameof(CommodityUnitBll)}.{nameof(GetCommodityUnitsByCategory)}: Getting commodities units by category id = " + id);

            var commodityUnits = _commodityUnitDao.GetAllCommodityUnits()
                .Where(
                    unit => unit.Product is null ?
                    false : unit.Product.Category is null ?
                    false : unit.Product.Category.Id == id
                );

            foreach (var item in commodityUnits)
            {
                yield return item;
            }
        }

        public IEnumerable<CommodityUnit> GetCommodityUnitsByProduct(int id)
        {
            _logger.Info($"BLL.{nameof(CommodityUnitBll)}.{nameof(GetCommodityUnitsByCategory)}: Getting commodities units by product id = " + id);

            foreach (var item in _commodityUnitDao.GetCommodityUnitsByProduct(id))
            {
                yield return item;
            }
        }

        public IEnumerable<CommodityUnit> GetCommodityUnitsByStatus(int id)
        {
            _logger.Info($"BLL.{nameof(CommodityUnitBll)}.{nameof(GetCommodityUnitsByCategory)}: Getting commodities units by status id = " + id);

            foreach (var item in _commodityUnitDao.GetCommodityUnitsByStatus(id))
            {
                yield return item;
            }
        }

        public IEnumerable<CommodityUnit> GetCommodityUnitsByStore(int id)
        {
            _logger.Info($"BLL.{nameof(CommodityUnitBll)}.{nameof(GetCommodityUnitsByCategory)}: Getting commodities units by store id = " + id);

            foreach (var item in _commodityUnitDao.GetCommodityUnitsByStore(id))
            {
                yield return item;
            }
        }

        public IEnumerable<CommodityUnit> GetCommodityUnitsByVendor(int id)
        {
            _logger.Info($"BLL.{nameof(CommodityUnitBll)}.{nameof(GetCommodityUnitsByCategory)}: Getting commodities units by vendor id = " + id);

            foreach (var item in _commodityUnitDao.GetCommodityUnitsByVendor(id))
            {
                yield return item;
            }
        }

        public int SetCommodityUnit(CommodityUnit commodityUnit)
        {
            _logger.Info($"BLL.{nameof(CommodityUnitBll)}.{nameof(SetCommodityUnit)}: Retention of commodity unit");

            if (commodityUnit.Id != null)
            {
                int id = _commodityUnitDao.ChangeCommodityUnit(commodityUnit);

                _logger.Info($"BLL.{nameof(CommodityUnitBll)}.{nameof(SetCommodityUnit)}: Commodity unit id = {id} changed");

                return id;
            }
            else
            {
                int id = _commodityUnitDao.AddCommodityUnit(commodityUnit);

                _logger.Info($"BLL.{nameof(CommodityUnitBll)}.{nameof(SetCommodityUnit)}: Commodity unit id = {id} added");

                return id;
            }
        }
    }
}
