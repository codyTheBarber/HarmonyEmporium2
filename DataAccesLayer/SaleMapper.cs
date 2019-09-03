using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    class SaleMapper :Mapper
    {
        int OffsetToSaleID;
        int OffsetToProductOnSale;
        int OffsetToCategoryOnSale;
        int OffsetToBrandOnSale;
        int OffsetToSaleName;
        int OffsetToPercentOff;
        int OffsetToActive;
        int OffsetToStartDate;
        int OffsetToEndDate;      

        public SaleMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            OffsetToSaleID = reader.GetOrdinal("SaleID");
            Assert(0 == OffsetToSaleID, "The SaleID is not 0 as expected");
            OffsetToProductOnSale = reader.GetOrdinal("ProductOnSale");
            Assert(1 == OffsetToProductOnSale, "The ProductOnSale is not 1 as expected");
            OffsetToCategoryOnSale = reader.GetOrdinal("CategoryOnSale");
            Assert(2 == OffsetToCategoryOnSale, "The CategoryOnSale is not 2 as expected");
            OffsetToBrandOnSale = reader.GetOrdinal("BrandOnSale");
            Assert(3 == OffsetToBrandOnSale, "The BrandOnSale is not 3 as expected");
            OffsetToSaleName = reader.GetOrdinal("SaleName");
            Assert(4 == OffsetToSaleName, "The SaleName is not 4 as expected");
            OffsetToPercentOff = reader.GetOrdinal("PercentOff");
            Assert(5 == OffsetToPercentOff, "The PercentOff is not 5 as expected");
            OffsetToActive = reader.GetOrdinal("Active");
            Assert(6 == OffsetToActive, "The Actuve is not 6 as expected");
            OffsetToStartDate = reader.GetOrdinal("StartDate");
            Assert(7 == OffsetToStartDate, "The StartDate is not 7 as expected");
            OffsetToEndDate = reader.GetOrdinal("EndDate");
            Assert(8 == OffsetToEndDate, "The EndDate is not 8 as expected");            
        }
        public SaleDAL SaleFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            SaleDAL proposedReturnValue = new SaleDAL();
            proposedReturnValue.SaleID = GetInt32OrDefault(reader, OffsetToSaleID);
            proposedReturnValue.ProductOnSale = GetInt32OrDefault(reader, OffsetToProductOnSale);
            proposedReturnValue.CategoryOnSale = GetInt32OrDefault(reader, OffsetToCategoryOnSale);
            proposedReturnValue.BrandOnSale = GetInt32OrDefault(reader, OffsetToBrandOnSale);
            proposedReturnValue.SaleName = GetStringOrDefault(reader, OffsetToSaleName);
            proposedReturnValue.PercentOff = GetInt32OrDefault(reader, OffsetToPercentOff);
            proposedReturnValue.Active = GetInt32OrDefault(reader, OffsetToActive);
            proposedReturnValue.StartDate = GetDateTimeOrDefault(reader, OffsetToStartDate);
            proposedReturnValue.EndDate = GetDateTimeOrDefault
            return proposedReturnValue;
        }
    }
}