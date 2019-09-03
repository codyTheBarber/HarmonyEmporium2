using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccesLayer
{
    class CartItemMapper:Mapper
    {
        int OffsetToUserID;
        int OffsetToProductID;
      
        public CartItemMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            OffsetToUserID = reader.GetOrdinal("UserID");
            Assert(0 == OffsetToUserID, "The UserID is not 0 as expected");
            OffsetToProductID = reader.GetOrdinal("ProductID");
            Assert(1 == OffsetToProductID, "The ProductID is not 1 as expected");
           ;

        }
        public CartItemDAL CartItemFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            CartItemDAL proposedReturnValue = new CartItemDAL();
            proposedReturnValue.UserID = GetInt32OrDefault(reader, OffsetToUserID);
            proposedReturnValue.ProductID = GetInt32OrDefault(reader, OffsetToProductID);
           
            return proposedReturnValue;
        }
    }
}
