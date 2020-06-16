using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientNotifications;
using Licenta.Data;
using Licenta.Models;
using Licenta.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static ClientNotifications.Helpers.NotificationHelper;

namespace Licenta.Controllers
{
    public class DetaliiController : Controller
    {
        private DetaliiRepository _detaliiRepository;
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;


        public DetaliiController(ApplicationDbContext context,
                                    UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _detaliiRepository = new DetaliiRepository(_context);
            _userManager = userManager;
        }
       
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var detaliis = _detaliiRepository.GetDetaliiByUserId(userId);
            return View(detaliis);
        }

        public IActionResult Informatii(int id)
        {
            var detalii = _detaliiRepository.GetSingleDetalii(id);
            return View(detalii);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.IsEditMode = "false";
            var detalii = new Detalii();
            return View(detalii);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(Detalii detalii, string IsEditMode)
        {

            try
            {
                if (IsEditMode.Equals("false"))
                {
                    var userId = _userManager.GetUserId(this.HttpContext.User);
                    detalii.UserId = userId;
                    _detaliiRepository.Create(detalii);

                }
                else
                {
                    var userId = _userManager.GetUserId(this.HttpContext.User);
                    detalii.UserId = userId;
                    _detaliiRepository.Edit(detalii);
                }
                   
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                return Content("Nu s-a putut crea sau edita inregistrarea!");
            }

        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var loggedInUserId = _userManager.GetUserId(HttpContext.User);

            ViewBag.IsEditMode = "true";
            var detalii = _detaliiRepository.GetSingleDetalii(Id);
            if (!detalii.UserId.Equals(loggedInUserId))
            {
                return Content("Nu sunteti autorizat!");
            }
            return View("Create", detalii);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var detalii = _detaliiRepository.GetSingleDetalii(id);
                _detaliiRepository.Delete(detalii);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Content("Nu s-a sters inregistrarea");
            }
        }

    }
}
