﻿using System.Web;
using System.Web.Mvc;

namespace Harmony_Emporium
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
