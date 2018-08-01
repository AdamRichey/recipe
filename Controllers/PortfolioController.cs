using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Runtime.Serialization;
using System.Net.Mail;


namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private portfoliocontext _context;
    
        public HomeController(portfoliocontext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult welcome(){
            return View("welcome");
        }

        [HttpPost]
        [Route("")]
        public IActionResult email(string data){
            return Ok(data);
        }

    }
}



