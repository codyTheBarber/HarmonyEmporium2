using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    class ProductMapper : Mapper
    {
        int OffsetToProductID;
        int OffsetToSupplierID;
        int OffsetToCategoryID;
        int OffsetToBrandID;
        int OffsetToProductName;
        int OffsetToRetailPrice;
        int OffsetToWholeSalePrice;
        int OffsetToOnSale;
        int OffsetToQuantity;
        int OffsetToColor;
        int OffsetToDescription;
        int OffsetToProductCreateDate;

        int OffsetToProductPhotoURL;

        public ProductMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            OffsetToProductID = reader.GetOrdinal("ProductID");
            Assert(0 == OffsetToProductID, "The ProductID is not 0 as expected");
            OffsetToSupplierID = reader.GetOrdinal("SupplierID");
            Assert(1 == OffsetToSupplierID, "The SupplierID is not 1 as expected");
            OffsetToCategoryID = reader.GetOrdinal("CategoryID");
            Assert(2 == OffsetToCategoryID, "The CategoryID is not 2 as expected");

            OffsetToBrandID = reader.GetOrdinal("BrandID");
            Assert(3 == OffsetToBrandID, "The BrandID is not 3 as expected");
            OffsetToProductName = reader.GetOrdinal("ProductName");
            Assert(4 == OffsetToProductName, "The ProductName is not  as expected");
            OffsetToRetailPrice = reader.GetOrdinal("RetailPrice");
            Assert(5 == OffsetToRetailPrice, "The RetailPrice is not 5 as expected");
            OffsetToWholeSalePrice = reader.GetOrdinal("WholeSalePrice");
            Assert(6 == OffsetToWholeSalePrice, "The WholeSalePrice is not 6 as expected");
            OffsetToOnSale = reader.GetOrdinal("OnSale");
            Assert(7 == OffsetToOnSale, "The OnSale is not 7 as expected");

            OffsetToQuantity = reader.GetOrdinal("Quantity");
            Assert(8 == OffsetToQuantity, "The Quantity is not 8 as expected");
            OffsetToColor = reader.GetOrdinal("Color");
            Assert(9 == OffsetToColor, "The Color is not 9 as expected");

            OffsetToDescription = reader.GetOrdinal("Description");
            Assert(10 == OffsetToDescription, "The Description is not 10 as expected");
            OffsetToProductCreateDate = reader.GetOrdinal("ProductCreateDate");
            Assert(11 == OffsetToProductCreateDate, "The ProductCreateDate is not 11 as expected");



            OffsetToProductPhotoURL = reader.GetOrdinal("ProductPhotoURL");
            Assert(12 == OffsetToProductPhotoURL, "The ProductPhotoURL is not 12 as expected");



        }
        public ProductDAL ProductFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            ProductDAL proposedReturnValue = new ProductDAL();
            proposedReturnValue.ProductID = GetInt32OrDefault(reader, OffsetToProductID);

            proposedReturnValue.SupplierID = GetInt32OrDefault(reader, OffsetToSupplierID);

            proposedReturnValue.CategoryID = GetInt32OrDefault(reader, OffsetToCategoryID);

            proposedReturnValue.BrandID = GetInt32OrDefault(reader, OffsetToBrandID);

            proposedReturnValue.ProductName = GetStringOrDefault (reader, OffsetToProductName);

            proposedReturnValue.RetailPrice = GetInt32OrDefault(reader, OffsetToRetailPrice);

            proposedReturnValue.WholeSalePrice = GetInt32OrDefault(reader, OffsetToWholeSalePrice);

            proposedReturnValue.OnSale = GetInt32OrDefault(reader, OffsetToOnSale);

            proposedReturnValue.Quantity = GetInt32OrDefault(reader, OffsetToQuantity);

            proposedReturnValue.Color = GetStringOrDefault(reader, OffsetToColor);

            proposedReturnValue.Description = GetStringOrDefault(reader, OffsetToDescription);

            proposedReturnValue.ProductCreateDate = GetDateTimeOrDefault(reader, OffsetToProductCreateDate);

            proposedReturnValue.ProductPhotoURL = GetStringOrDefault(reader, OffsetToProductPhotoURL);

            return proposedReturnValue;
        }
    }
}