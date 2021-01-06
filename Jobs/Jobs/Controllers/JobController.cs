using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobs.Core.Interfaces;
using Jobs.Core.Dtos.Entities;
using System.Net;
using Jobs.Core.Dtos.Responses;

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
            var model = _service.JobsList().AllJobs;
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Job job)
        {
            var response = new ResponseStatus();
            if (ModelState.IsValid)
            {
                response = _service.Add(job);
            }
            if(response.Code == HttpStatusCode.BadRequest.ToString())
            {
                return View();
            }
            return Redirect("~/Job/");
        }

        [HttpGet]
        public IActionResult Edit(int JobID)
        {
            var Job = _service.Edit(JobID);
            return View();
        }

    }
}
