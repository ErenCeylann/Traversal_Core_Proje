﻿using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Proje.ViewComponents.AdminDashboard
{
    public class _DashboardBanner:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
