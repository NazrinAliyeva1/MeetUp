using MeetUp.DataAccesLayer;
using MeetUp.ViewModels.Speakers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Controllers;


public class HomeController(MeetUpContext _sql) : Controller
{
    public async Task<IActionResult> Index()
    {
        return View(await _sql.Speakers.Select(x => new GetSpeakerVM
        {
            Description = x.Description,
            FaceBookImage = x.FaceBookImage,
            TwitterImage = x.TwitterImage,
            InImage = x.InImage,
            Image= x.Image,
        }).ToListAsync());

    }
}
