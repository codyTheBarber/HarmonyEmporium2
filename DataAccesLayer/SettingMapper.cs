using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    class SettingMapper :Mapper
    {
        int OffsetToUserID;
        int OffsetToFontSize;
        int OffsetToFont;
        int OffsetToPrimaryColor;
        int OffsetToSecondaryColor;
       

        public SettingMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            OffsetToUserID = reader.GetOrdinal("UserID");
            Assert(0 == OffsetToUserID, "The UserID is not 0 as expected");
            OffsetToFontSize = reader.GetOrdinal("FontSize");
            Assert(1 == OffsetToFont, "The FontSize is not 1 as expected");
            OffsetToFont = reader.GetOrdinal("Font");
            Assert(2 == OffsetToFont, "The Font is not 2 as expected");
            OffsetToPrimaryColor = reader.GetOrdinal("PrimaryColor");
            Assert(3 == OffsetToPrimaryColor, "The PrimaryColor is not 3 as expected");
            OffsetToSecondaryColor = reader.GetOrdinal("SecondaryColor");
            Assert(4 == OffsetToSecondaryColor, "The SecondaryColor is not 4 as expected");
            
            
        }
        public SettingDAL SettingFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            SettingDAL proposedReturnValue = new SettingDAL();
            proposedReturnValue.UserID = GetInt32OrDefault(reader, OffsetToUserID);
            proposedReturnValue.FontSize = GetInt32OrDefault(reader, OffsetToFontSize);
            proposedReturnValue.Font = GetStringOrDefault(reader, OffsetToFont);
            proposedReturnValue.PrimaryColor = GetStringOrDefault(reader, OffsetToPrimaryColor);
            proposedReturnValue.SecondaryColor = GetStringOrDefault(reader, OffsetToSecondaryColor);


            return proposedReturnValue;
        }
    }
}