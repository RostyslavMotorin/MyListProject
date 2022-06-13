using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyList.Data.Services
{
    internal class PhotoService
    {
        public async Task<bool> AddPhotoAsync(IFormFile file)
        {
            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream());
                {
                    
                }
            }

            return true;
        }
    }
}
