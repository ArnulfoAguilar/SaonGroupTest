using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobs.Core.Interfaces;

namespace Jobs.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobService _service;
        public JobController(IJobService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
