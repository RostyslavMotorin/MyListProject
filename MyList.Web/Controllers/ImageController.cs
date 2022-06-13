using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyList.Data.Contexts;

namespace MyList.Web.Controllers
{
    public class ImageController : BaseApiController
    {
        [HttpGet("GetPhoto")]
        [AllowAnonymous]
        public IActionResult GetPhoto(string path)
        {
            string file_path = Path.Combine(Directory.GetCurrentDirectory(), path);
            string type = path.Split('.').Last();
            string file_type = "image/";
            switch (type)
            {
                case "jpg":
                    file_type += "jpeg";
                    break;
                case "jpeg":
                    file_type += "jpeg";
                    break;
                case "png":
                    file_type += "png";
                    break;
                default:
                    file_type += "bmp";
                    break;

            }

            return PhysicalFile(file_path, file_type);
        }
    }
}
