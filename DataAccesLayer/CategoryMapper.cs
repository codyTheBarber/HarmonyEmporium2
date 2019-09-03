using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    class CategoryMapper :Mapper
    {
       
            int OffsetToCategoryID;
            int OffsetToCategoryName;
            int OffsetToCategoryCreateDate;

            public CategoryMapper(System.Data.SqlClient.SqlDataReader reader)
            {
                OffsetToCategoryID = reader.GetOrdinal("CategoryID");
                Assert(0 == OffsetToCategoryID, "The CategoryID is not 0 as expected");
                OffsetToCategoryName = reader.GetOrdinal("CategoryName");
                Assert(1 == OffsetToCategoryName, "The CategoryName is not 1 as expected");
            OffsetToCategoryCreateDate = reader.GetOrdinal("CategoryCreateDate");
            Assert(2 == OffsetToCategoryCreateDate, "The CategoryCreateDate is not 2 as expected");


        }
            public CategoryDAL CategoryFromReader(System.Data.SqlClient.SqlDataReader reader)
            {
                CategoryDAL proposedReturnValue = new CategoryDAL();
                proposedReturnValue.CategoryID = GetInt32OrDefault(reader, OffsetToCategoryID);

                proposedReturnValue.CategoryName = GetStringOrDefault(reader, OffsetToCategoryName);

            proposedReturnValue.CategoryCreateDate = GetDateTimeOrDefault(reader, OffsetToCategoryCreateDate);

            return proposedReturnValue;
            }
        }
    }