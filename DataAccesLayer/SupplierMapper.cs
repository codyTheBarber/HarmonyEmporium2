using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{

    class SupplierMapper : Mapper
    {
        int OffsetToSupplierID;
        int OffsetToSupplierName;
        int OffsetToContactName;
        int OffsetToContactEmail;
        int OffsetToAddress;
        int OffsetToSupplierCreateDate;
        int OffsetToSuppliersPhotoURL;
        int OffsetToWebsiteURL;



        public SupplierMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            OffsetToSupplierID = reader.GetOrdinal("SupplierID");
            Assert(0 == OffsetToSupplierID, "The SupplierID is not 0 as expected");
            OffsetToSupplierName = reader.GetOrdinal("SupplierName");
            Assert(1 == OffsetToSupplierName, "The SupplierName is not 1 as expected");
            OffsetToContactName = reader.GetOrdinal("ContactName");
            Assert(2 == OffsetToContactName, "The ContactName is not 2 as expected");
            OffsetToContactEmail = reader.GetOrdinal("ContactEmail");
            Assert(3 == OffsetToContactEmail, "The ContactEmail is not 3 as expected");
            OffsetToAddress = reader.GetOrdinal("Address");
            Assert(4 == OffsetToAddress, "The Address is not 4 as expected");

            OffsetToSupplierCreateDate = reader.GetOrdinal("SupplierCreateDate");
            Assert(5 == OffsetToSupplierCreateDate, "The SupplierCreateDate is not 5 as expected");

            OffsetToSuppliersPhotoURL = reader.GetOrdinal("SuppliersPhotoURL");
            Assert(6 == OffsetToSuppliersPhotoURL, "The SuppliersPhotoURL is not 6 as expected");

            OffsetToWebsiteURL = reader.GetOrdinal("WebsiteURL");
            Assert(7 == OffsetToWebsiteURL, "The WebsiteURL is not 7 as expected");

          


        }
        public SupplierDAL SupplierFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            SupplierDAL proposedReturnValue = new SupplierDAL();
            proposedReturnValue.SupplierID = GetInt32OrDefault(reader, OffsetToSupplierID);
            proposedReturnValue.SupplierName = GetStringOrDefault(reader, OffsetToSupplierName);
            proposedReturnValue.ContactName = GetStringOrDefault(reader, OffsetToContactName);
            proposedReturnValue.ContactEmail = GetStringOrDefault(reader, OffsetToContactName);
            proposedReturnValue.Address = GetStringOrDefault(reader, OffsetToAddress);
            proposedReturnValue.SupplierCreateDate = GetDateTimeOrDefault(reader, OffsetToSupplierCreateDate);
            proposedReturnValue.SuppliersPhotoURL = GetStringOrDefault(reader, OffsetToSuppliersPhotoURL);
            proposedReturnValue.WebsiteURL =
                GetStringOrDefault(reader, OffsetToWebsiteURL);


            return proposedReturnValue;
        }
    }

}
