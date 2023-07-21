using Microsoft.AspNetCore.Mvc;
using StajTakip.Application.Contracts.Operations;
using StajTakip.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 

namespace StajyerTakipSistemi.Controllers
{
    public class StajyerController : Controller
    {
        private readonly IStajyerService _stajyerService;
        public StajyerController(IStajyerService stajyerService)
        {
            _stajyerService = stajyerService;
        }

        public IActionResult Index()
        {
            var model = _stajyerService.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View("StajyerForm");
        }

        [HttpPost]
        public IActionResult Kaydet(Stajyer stajyer)
        {

            if (stajyer.Id == null)//Ekle
            {
                _stajyerService.Kaydet(stajyer);
            }
            else//Güncelle
            {
                _stajyerService.Guncelle(stajyer);
            }            
            return RedirectToAction("StajyerForm");
        }

        [HttpGet]
        // [Route("Stajyer/Guncelle/{id}")]
        public ActionResult Guncelle(string id)
        {
            var model = _stajyerService.Get(id);             
            return View("StajyerForm",model);
        }

        public ActionResult Sil(string id)
        {
            var silinecekStajyer = _stajyerService.Get(id); ;
            if (silinecekStajyer == null)
            {
                return NotFound();
            }
            _stajyerService.Sil(id);
            return RedirectToAction("Index");
        }

    }
}