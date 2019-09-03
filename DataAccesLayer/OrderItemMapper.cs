using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    class OrderItemMapper : Mapper
    {
        int OffsetToOrderID;
        int OffsetToUserID;
        int OffsetToProductID;
        int OffsetToSaleID;
        int OffsetToTimeOfOrder;

        public OrderItemMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            OffsetToOrderID = reader.GetOrdinal("OrderID");
            Assert(0 == OffsetToOrderID, "The OrderID is not 0 as expected");
            OffsetToUserID = reader.GetOrdinal("UserIDe");
            Assert(1 == OffsetToUserID, "The UserID is not 1 as expected");
            OffsetToProductID = reader.GetOrdinal("ProductID");
            Assert(2 == OffsetToProductID, "The ProductID is not 2 as expected");
            OffsetToSaleID = reader.GetOrdinal("SaleID");
            Assert(3 == OffsetToSaleID, "The SaleID is not 3 as expected");
            OffsetToTimeOfOrder = reader.GetOrdinal("TimeOfOrder");
            Assert(4 == OffsetToTimeOfOrder, "The TimeOfOrder is not 4 as expected");

        }
        public OrderItemDAL OrderItemFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            OrderItemDAL proposedReturnValue = new OrderItemDAL();
            proposedReturnValue.OrderID = GetInt32OrDefault(reader, OffsetToOrderID);

            proposedReturnValue.UserID = GetInt32OrDefault(reader, OffsetToUserID);

            proposedReturnValue.ProductID = GetInt32OrDefault(reader, OffsetToProductID);
            proposedReturnValue.SaleID = GetInt32OrDefault(reader, OffsetToSaleID);

            proposedReturnValue.TimeOfOrder = GetDateTimeOrDefault(reader, OffsetToTimeOfOrder);

            return proposedReturnValue;
        }
    }
}