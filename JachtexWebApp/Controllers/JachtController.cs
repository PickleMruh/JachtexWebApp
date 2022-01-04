using JachtexWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JachtexWebApp.Controllers
{
    public class JachtController : Controller
    {
        private readonly DB_JachtexContext dbContext;

        public JachtController(DB_JachtexContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IActionResult Morskie()
        {
            IEnumerable<Jachty> objList = dbContext.Jachties.Where(x => x.Kategoria == "morski");
            return View(objList);
        }

        public IActionResult Srodladowe()
        {
            IEnumerable<Jachty> objList = dbContext.Jachties.Where(x => x.Kategoria == "srodladowy");
            return View(objList);
        }

        // GET - Wypozycz
        public IActionResult Wypozycz()
        {
            return View();
        }

        // POST - Wypozycz
        [HttpPost]
        public IActionResult Wypozycz(Wypozyczenium _obj)
        {

            // (StartWyp <= EndOBJ) and (EndWyp >= StartOBJ)

            IEnumerable<Wypozyczenium> wyposList = dbContext.Wypozyczenia.Where(x => x.IdJacht == _obj.IdJacht);
            Jachty jachtPoId = dbContext.Jachties.Where(x => x.IdJacht == _obj.IdJacht).SingleOrDefault();

            if (jachtPoId is null)
            {
                return BadRequest("Wypożyczenie nie udane! Nie istnieje jacht o wskazanym ID");
            }

            if (_obj.WypoKoniec < _obj.WypoStart)
            {
                return BadRequest("Wypożyczenie nie udane! Data końca nie może występować wcześniej niż data początku");
            }
            else 
            {
                foreach (var wyp in wyposList)
                {
                    if ((wyp.WypoStart < _obj.WypoKoniec) && (wyp.WypoKoniec > _obj.WypoStart))
                    {
                        return BadRequest($"Termin już zajęty. Wybrany jacht jest wypożyczony od {wyp.WypoStart} do {wyp.WypoKoniec}");
                    }
                }
                dbContext.Wypozyczenia.Add(_obj);
                dbContext.SaveChanges();
                double dni = (_obj.WypoKoniec - _obj.WypoStart).TotalDays;
                double koszt = dni * jachtPoId.DziennyKoszt;
                return Ok($"Wypożyczenie zostało zarejestrowane. Całkowity koszt wypożyczenia to: {koszt}zł. Wysokość zaliczki (10%) to: {koszt * 0.1}zł");
            }
        }
    }
}
