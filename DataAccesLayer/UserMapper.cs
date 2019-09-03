using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    class UserMapper : Mapper
    {
        int OffsetToUserID;
        int OffsetToRoleID;
        int OffsetToEmail;
        int OffsetToHash;
        int OffsetToSalt;
        int OffsetToAddress;
        int OffsetToFirstName;
        int OffsetToLastName;
        int OffsetToBirthday;
        int OffsetToPhone;
        int OffsetToAccountCreateDate;
        int OffsetToPhotoURL;



        public UserMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            OffsetToUserID = reader.GetOrdinal("UserID");
            Assert(0 == OffsetToUserID, "The UserID is not 0 as expected");

            OffsetToRoleID = reader.GetOrdinal("RoleID");
            Assert(1 == OffsetToRoleID, "The RoleID is not 1 as expected");

            OffsetToEmail = reader.GetOrdinal("Email");
            Assert(2 == OffsetToEmail, "The Email is not 2 as expected");

            OffsetToHash = reader.GetOrdinal("Hash");
            Assert(3 == OffsetToHash, "The Hash is not 3 as expected");

            OffsetToSalt = reader.GetOrdinal("Salt");
            Assert(4 == OffsetToSalt, "The Salt is not 4 as expected");

            OffsetToAddress = reader.GetOrdinal("Address");
            Assert(5 == OffsetToAddress, "The Address is not 5 as expected");

            OffsetToFirstName = reader.GetOrdinal("FirstName");
            Assert(6 == OffsetToFirstName, "The FirstName is not 6 as expected");

            OffsetToLastName = reader.GetOrdinal("LastName");
            Assert(7 == OffsetToLastName, "The LastName is not 7 as expected");

            OffsetToBirthday = reader.GetOrdinal("Birthday");
            Assert(8 == OffsetToBirthday, "The Birthday is not 8 as expected");

            OffsetToPhone = reader.GetOrdinal("Phone");
            Assert(9 == OffsetToPhone, "The Phone is not 9 as expected");

            OffsetToAccountCreateDate = reader.GetOrdinal("AccountCreateDate");
            Assert(10 == OffsetToAccountCreateDate, "The AccountCreateDate is not 10 as expected");

            OffsetToPhotoURL = reader.GetOrdinal("PhotoURL");
            Assert(11 == OffsetToPhotoURL, "The PhotoURL is not 11 as expected");




        }
        public UserDAL UserFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            UserDAL proposedReturnValue = new UserDAL();
            proposedReturnValue.UserID = GetInt32OrDefault(reader, OffsetToRoleID);
            proposedReturnValue.Email = GetStringOrDefault(reader, OffsetToEmail);
            proposedReturnValue.Hash = GetStringOrDefault(reader, OffsetToHash);
            proposedReturnValue.Salt = GetStringOrDefault(reader, OffsetToSalt);
            proposedReturnValue.Address = GetStringOrDefault(reader, OffsetToAddress);
            proposedReturnValue.FirstName = GetStringOrDefault(reader, OffsetToFirstName);
            proposedReturnValue.LastName = GetStringOrDefault(reader, OffsetToLastName);
            proposedReturnValue.Birthday =
                GetDateTimeOrDefault(reader, OffsetToBirthday);
            proposedReturnValue.Phone =
                GetStringOrDefault(reader, OffsetToPhone);
            proposedReturnValue.AccountCreateDate =
                GetDateTimeOrDefault(reader, OffsetToAccountCreateDate);
            proposedReturnValue.PhototURL =
                GetStringOrDefault(reader, OffsetToPhotoURL);


            return proposedReturnValue;
        }
    }
}