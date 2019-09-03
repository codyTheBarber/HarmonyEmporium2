using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    class OrderMapper:Mapper
    {
        int OffsetToOrderID;
        int OffsetToUserID;
        int OffsetToProductID;
        int OffsetToFeeID;
        int OffsetToOnSale;
        int OffsetToCashOrCard;
        int OffsetToGrandTotal;
        int OffsetToTimeOfOrder;

        public OrderMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            OffsetToOrderID = reader.GetOrdinal("OrderID");
            Assert(0 == OffsetToOrderID, "The OrderID is not 0 as expected");
            OffsetToUserID = reader.GetOrdinal("UserID");
            Assert(1 == OffsetToUserID, "The UserID is not 1 as expected");
            OffsetToProductID = reader.GetOrdinal("ProductID");
            Assert(2 == OffsetToProductID, "The ProductID is not 2 as expected");

            OffsetToFeeID = reader.GetOrdinal("FeeID");
            Assert(3 == OffsetToFeeID, "The FeeID is not 3 as expected");
            OffsetToOnSale = reader.GetOrdinal("OnSale");
            Assert(4 == OffsetToOnSale, "The OnSale is not  as expected");
            OffsetToCashOrCard = reader.GetOrdinal("CashOrCard");
            Assert(5 == OffsetToCashOrCard, "The CashOrCard is not 5 as expected");
            OffsetToGrandTotal = reader.GetOrdinal("GrandTotal");
            Assert(6 == OffsetToGrandTotal, "The GrandTotal is not  as expected");
            OffsetToTimeOfOrder = reader.GetOrdinal("CashOrCard");
            Assert(7 == OffsetToTimeOfOrder, "The TimeOfOrder is not 7 as expected");



        }
        public OrderDAL CategoryFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            OrderDAL proposedReturnValue = new OrderDAL();
            proposedReturnValue.OrderID = GetInt32OrDefault(reader, OffsetToOrderID);

            proposedReturnValue.UserID = GetInt32OrDefault(reader, OffsetToUserID);

            proposedReturnValue.ProductID = GetInt32OrDefault(reader, OffsetToProductID);
            proposedReturnValue.FeeID = GetInt32OrDefault(reader, OffsetToFeeID);

            proposedReturnValue.OnSale = GetBoolOrDefault (reader, OffsetToOnSale);

            proposedReturnValue.CashOrCard = GetStringOrDefault(reader, OffsetToCashOrCard);

            proposedReturnValue.GrandTotal = GetDecimalOrDefault(reader, OffsetToGrandTotal);

            proposedReturnValue.TimeOfOrder = GetDateTimeOrDefault(reader, OffsetToTimeOfOrder);

            return proposedReturnValue;
        }
    }
}