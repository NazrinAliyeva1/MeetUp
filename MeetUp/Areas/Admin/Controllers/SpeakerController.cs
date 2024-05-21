using MeetUp.DataAccesLayer;
using MeetUp.Extentions;
using MeetUp.Models;
using MeetUp.ViewModels.Speakers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MeetUp.Areas.Admin.Controllers;

public class SpeakerController(MeetUpContext _sql, IWebHostEnvironment _env) : Controller
{
    [Area("Admin")]
    public async Task<IActionResult> Index()
    {
        return View(await _sql.Speakers
            .Select(a => new GetSpeakerAdminVM
            {
                Description = a.Description,
                FaceBookImage = a.FaceBookImage,
                TwitterImage = a.TwitterImage,
                InImage = a.InImage,
                CreatedTime = a.CreateTime.ToString("dd MMM ddd"),
                UpdatedTime = a.UpdateTime.ToString("dd MMM ddd")
            }).ToListAsync());
    }
    
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateSpeakerVM data)
    {
        if (data.ImageFile != null)
        {
            if (!data.ImageFile.IsValidType("image"))
                ModelState.AddModelError("ImageFile", "Fayl sekil formatinda deyil");
            if (!data.ImageFile.IsValidLength(900))
                ModelState.AddModelError("ImageFile", "Faylin olcusu 900 kb-dan cox olmamalidir.");
        }

        string fileName = await data.ImageFile.SaveFileAsync(Path.Combine(_env.WebRootPath, "imgs", "spkrs"));

        Speaker spek = new Speaker
        {
            CreateTime = DateTime.Now,
            UpdateTime = DateTime.Now,
            Description = data.Description,
            FaceBookImage = data.FaceBookImage,
            TwitterImage = data.TwitterImage,
            InImage = data.InImage,
      

        };
        await _sql.Speakers.AddAsync(spek);
        await _sql.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

    }
     
}
