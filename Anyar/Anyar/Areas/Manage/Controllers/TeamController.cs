using Anyar.Helpers;
using Anyar.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anyar.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeamController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly DataContext   _dataContext;

        public TeamController(DataContext dataContext , IWebHostEnvironment env)
        {
            _env = env;
            _dataContext = dataContext;
        }
        
        public IActionResult Index()
        {
            List<Team> teams = _dataContext.Teams.ToList();
            return View(teams);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (team == null) return NotFound();
            team.Image = FileManager.SaveFile(_env.WebRootPath, "uploads\\sliders", team.ImageFile);
            _dataContext.Teams.Add(team);
            _dataContext.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Update(int id )
        {
            Team team = _dataContext.Teams.Find(id);
            if (team == null) return NotFound();
            return View(team);

        }
        [HttpPost]
        
        public IActionResult Update(Team team)
        {
            Team teamex = _dataContext.Teams.FirstOrDefault(x=>x.Id == team.Id);
            if (teamex==null) return NotFound();

            string name = FileManager.SaveFile(_env.WebRootPath, "uploads\\sliders", team.ImageFile);
            FileManager.DeletFile(_env.WebRootPath, "uploads\\sliders", teamex.Image);
          
            teamex.Name = team.Name;
            teamex.Profession = team.Profession;
            teamex.Desc = team.Desc;
            teamex.TiwiterUrl = team.TiwiterUrl;
            teamex.FacebookUrl = team.FacebookUrl;
            teamex.InstagramUrl = team.InstagramUrl;
            teamex.LinkedinUrl  = team.LinkedinUrl;

         
            _dataContext.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult Delete(int id)
        {
            Team team = _dataContext.Teams.FirstOrDefault(x => x.Id == id);
            if (team==null) return NotFound();

            if (team.Image == null)
            {
                FileManager.DeletFile(_env.WebRootPath, "uploads\\sliders", team.Image);

            }
            _dataContext.Teams.Remove(team);
            _dataContext.SaveChanges();
            return RedirectToAction("INDEX");
        }
    }
}
