using Commander.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Controllers
{
    public class FileManagerControllers
    {
        [Route("api/filemanager")]
        [ApiController]
        public class FileCotrollers : ControllerBase
        {

            private readonly IFileService _service;
            private readonly IWebHostEnvironment _envirnment;
            public FileCotrollers(IFileService service, IWebHostEnvironment appEnvironment)
            {
                _service = service;
                _envirnment = appEnvironment;
            }

            //GET api/people
            [HttpGet]
            public ActionResult<string> GetFile()
            {
                return Ok("Hello filemaneger");
            }
            [HttpPost]
            public ActionResult ChangeFile(IFormFile file)
            {
                if (file == null)
                {
                    return BadRequest();
                }
                if (file.Length > 0)
                {

                    using (FileStream fileStream = System.IO.File.Create(_envirnment.WebRootPath + file.FileName))
                    {
                        file.CopyTo(fileStream);

                        Console.WriteLine(file);

                        Image img = Image.FromStream(fileStream);

                        Bitmap bitmap = new Bitmap(img);

                        var bm = _service.Scale(bitmap, 2f, 2f);

                        var pathSaved = _envirnment.WebRootPath + "Changed" + file.FileName;

                        bm.Save(pathSaved);

                        byte[] imageArrayByte = System.IO.File.ReadAllBytes(pathSaved);

                        return File(imageArrayByte,"image/png");
                    }
                }
                else
                {
                    return Ok("file not download");
                }
            }
        }
    }
}
