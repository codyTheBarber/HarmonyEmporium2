using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    class BrandMapper:Mapper
    {
        int OffsetToBrandID;
        int OffsetToBrandName;
        int OffsetToBrandCreateDate;
        int OffsetToBrandPhotoURL;
        int OffsetToWebsiteURL;

        public BrandMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            OffsetToBrandID = reader.GetOrdinal("BrandID");
            Assert(0 == OffsetToBrandID, "The BrandID is not 0 as expected");
            OffsetToBrandName = reader.GetOrdinal("BrandName");
            Assert(1 == OffsetToBrandName, "The BrandName is not 1 as expected");
            OffsetToBrandCreateDate = reader.GetOrdinal("BrandCreateDate");
            Assert(2 == OffsetToBrandCreateDate, "The BrandCreateDate is not 2 as expected");
            OffsetToBrandPhotoURL = reader.GetOrdinal("BrandPhotoURL");
            Assert(3 == OffsetToBrandPhotoURL, "The BrandPhotoURL is not 3 as expected");
            OffsetToWebsiteURL = reader.GetOrdinal("WebsiteURL");
            Assert(4 == OffsetToWebsiteURL, "The WebsiteURL is not 4 as expected");

        }
        public BrandDAL BrandFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            BrandDAL proposedReturnValue = new BrandDAL();
            proposedReturnValue.BrandID = GetInt32OrDefault(reader, OffsetToBrandID);
            proposedReturnValue.BrandName = GetStringOrDefault(reader, OffsetToBrandName);
            proposedReturnValue.BrandCreateDate = 
               GetDateTimeOrDefault(reader, OffsetToBrandCreateDate);
            proposedReturnValue.BrandPhotoURL = GetStringOrDefault(reader, OffsetToBrandPhotoURL);
            proposedReturnValue.WebsiteURL = GetStringOrDefault(reader, OffsetToWebsiteURL);
            return proposedReturnValue;
        }
    }
}
