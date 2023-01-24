using Anyar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Anyar.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _datacontext;
        public HomeController(DataContext dataContext)
        {
            _datacontext = dataContext;
        }
       

        public IActionResult Index()
        {
            List<Team> teams = _datacontext.Teams.ToList();
            return View(teams);
        }

       
    }
}