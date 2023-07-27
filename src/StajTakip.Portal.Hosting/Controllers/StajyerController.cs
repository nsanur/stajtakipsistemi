using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StajTakip.Application.Contracts.Operations;
using StajTakip.Data.Contexts;
using StajTakip.Data.Entities;
using StajTakip.Portal.Hosting.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 


namespace StajyerTakipSistemi.Controllers
{
    public class StajyerController : BaseController
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
        public IActionResult Guncelle(int id)
        {
            
            var model = _stajyerService.Get(id);
            return View("StajyerForm", model);
            
        }

        [HttpGet]
        public IActionResult Yeni()
        {

            return View("StajyerForm",new Stajyer());
        }

        [HttpPost]
        //CSRF
        [ValidateAntiForgeryToken]
        public IActionResult Kaydet(Stajyer stajyer)
        {
            if (!ModelState.IsValid)
            {
                return View("StajyerForm");
            }

            if (stajyer.Id==0)
            {
                _stajyerService.Kaydet(stajyer);
            }
            else
            {
                _stajyerService.Guncelle(stajyer);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var silinecekStajyer = _stajyerService.Get(id); ;
            if (silinecekStajyer == null)
            {
                return NotFound();
            }
            _stajyerService.Sil(id);
            return RedirectToAction("Index");
        }

        public IActionResult ExportStaticExcelList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Stajyer Listesi");
                worksheet.Cell(1, 1).Value = "TC No";
                worksheet.Cell(1, 2).Value = "Departman";
                worksheet.Cell(1, 3).Value = "Ad";
                worksheet.Cell(1, 4).Value = "Soyad";
                worksheet.Cell(1, 5).Value = "Telefon";
                worksheet.Cell(1, 6).Value = "Başlama Tarihi";

                int StajyerRowCount = 2;
                foreach(var item in _stajyerService.GetAll())
                {
                    worksheet.Cell(StajyerRowCount, 1).Value = item.TcNo;
                    worksheet.Cell(StajyerRowCount, 2).Value = item.Departman;
                    worksheet.Cell(StajyerRowCount, 3).Value = item.Ad;
                    worksheet.Cell(StajyerRowCount, 4).Value = item.Soyad;
                    worksheet.Cell(StajyerRowCount, 5).Value = item.Telefon;
                    worksheet.Cell(StajyerRowCount, 6).Value = item.BaslamaTarihi;
                    StajyerRowCount++;
                }
                using (var stream =new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vdn.openxmlformats-officedocument.spreadsheetml.sheet","StajyerLİstesi.xlsx");
                }
            }

        }

        public IActionResult StajyerListExcel()
        {
            return View();
        }

    }
}