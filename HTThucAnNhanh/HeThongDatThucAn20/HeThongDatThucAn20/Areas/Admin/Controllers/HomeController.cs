﻿using HeThongDatThucAn20.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeThongDatThucAn20.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminOrManager")]

    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }

}
