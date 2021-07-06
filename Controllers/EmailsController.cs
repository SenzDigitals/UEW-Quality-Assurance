using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using UEW_Quality_Assurance.Models;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;
using UEW_Quality_Assurance.Data;
using Microsoft.AspNetCore.Authorization;
//using MailKit.Net.Smtp;
//using MimeKit;

namespace UEW_Quality_Assurance.Controllers
{
    //[Authorize]
    public class EmailsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public EmailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {          

            return View();
        }

        [HttpPost]
        public IActionResult Index(Email email, Lecturer lecturer)
        { 
            
            string to = email.To;
            string subject = email.Subject;
            string body = email.Body;

            MailMessage mm = new MailMessage();
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;

            mm.From = new MailAddress("senzu.dogi23@gmail.com");
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 465;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("senzu.dogi23@gmail.com", "dogi.senzu23@gmail.comtem22ple12345?");
            smtp.Send(mm);

            ViewBag.Message = "Mail Sent successfully" + email.To;

            return View();
        }
    }
}
