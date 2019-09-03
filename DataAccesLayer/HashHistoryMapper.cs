using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    class HashHistoryMapper :Mapper
    {
        int OffsetToUserID;
        int OffsetToSalt;
        int OffsetToHash;

        public HashHistoryMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            OffsetToUserID = reader.GetOrdinal("UserID");
            Assert(0 == OffsetToUserID, "The UserID is not 0 as expected");
            OffsetToSalt = reader.GetOrdinal("Salt");
            Assert(1 == OffsetToSalt, "The Salt is not 1 as expected"); 
            OffsetToHash = reader.GetOrdinal("Hash");
            Assert(2 == OffsetToHash, "The Hash is not 2 as expected");


        }
        public HashHistoryDAL HashHistoryFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            HashHistoryDAL proposedReturnValue = new HashHistoryDAL();
            proposedReturnValue.UserID = GetInt32OrDefault(reader, OffsetToUserID);

            proposedReturnValue.Salt = GetStringOrDefault(reader, OffsetToSalt);

            proposedReturnValue.Hash = GetStringOrDefault(reader, OffsetToHash);

            return proposedReturnValue;
        }
    }
}