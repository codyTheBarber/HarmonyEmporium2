using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    class ProductViewMapper :Mapper
    {
        int OffsetToUserID;
        int OffsetToProductID;
        int OffsetToViewDate;
       

        public ProductViewMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            OffsetToUserID = reader.GetOrdinal("UserID");
            Assert(0 == OffsetToUserID, "The UserID is not 0 as expected");
            OffsetToProductID = reader.GetOrdinal("ProductID");
            Assert(1 == OffsetToProductID, "The ProductID is not 1 as expected");
            OffsetToViewDate = reader.GetOrdinal("ViewDate");
            Assert(2 == OffsetToViewDate, "The ViewDate is not 2 as expected");
           

        }
        public ProductViewDAL ProductViewFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            ProductViewDAL proposedReturnValue = new ProductViewDAL();
            proposedReturnValue.UserID = GetInt32OrDefault(reader, OffsetToUserID);

            proposedReturnValue.ProductID = GetInt32OrDefault(reader, OffsetToProductID);

            proposedReturnValue.ViewDate = GetDateTimeOrDefault
                (reader, OffsetToViewDate);
            return proposedReturnValue;
        }
    }
}