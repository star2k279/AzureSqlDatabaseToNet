using AzureSqlDatabaseToNet.Models;
using AzureSqlDatabaseToNet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureSqlDatabaseToNet.Controllers
{
    public class CourseController : Controller
    {
        private CourseService _courseService;
        private readonly IConfiguration _configuration;

        public CourseController(CourseService service, IConfiguration config)
        {
            _courseService = service;
            _configuration = config;
        }
        // GET: CourseController
        public ActionResult Index()
        {
            IEnumerable<Course> _courseList = _courseService.GetCourses(_configuration.GetConnectionString("sqlconnection"));
            return View(_courseList);
        }

    }
}
