using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    class FeeMapper : Mapper
    {
        int OffsetToFeeID;
        int OffsetToTax;
        int OffsetToShippingFee;
        int OffsetToRateCreationDate;
        int OffsetToRateEndDate;




        public FeeMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            OffsetToFeeID = reader.GetOrdinal("FeeID");
            Assert(0 == OffsetToFeeID, "The FeeID is not 0 as expected");

            OffsetToTax = reader.GetOrdinal("Tax");
            Assert(1 == OffsetToTax, "The Tax is not 1 as expected");

            OffsetToShippingFee = reader.GetOrdinal("ShippingFee");
            Assert(2 == OffsetToShippingFee, "The RateCreationDate is not 2 as expected");

            OffsetToRateCreationDate = reader.GetOrdinal("RateCreationDate");
            Assert(3 == OffsetToRateCreationDate, "The RateCreationDate is not 3 as expected");

            OffsetToRateEndDate = reader.GetOrdinal("RateEndDate");
            Assert(4 == OffsetToRateEndDate, "The RateEndDate is not 4 as expected");





        }
        public FeeDAL FeeFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            FeeDAL proposedReturnValue = new FeeDAL();
            proposedReturnValue.FeeID = GetInt32OrDefault(reader, OffsetToFeeID);
            proposedReturnValue.Tax = GetInt32OrDefault(reader, OffsetToShippingFee);
            proposedReturnValue.ShippingFee = GetInt32OrDefault(reader, OffsetToShippingFee);
            proposedReturnValue.RateCreationDate = GetDateTimeOrDefault(reader, OffsetToRateCreationDate);
            proposedReturnValue.RateEndDate = GetDateTimeOrDefault(reader, OffsetToRateEndDate);



            return proposedReturnValue;
        }
    }
}

