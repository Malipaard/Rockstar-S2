using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ITtrainees.MVC.APITools
{
    public static class FileEncoder
    {
        public static string EncodePDF(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string encodedFile = Convert.ToBase64String(fileBytes);
                return encodedFile;
            }
        }

        //WIP
        public static string DecodePDF(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string encodedFile = Convert.ToBase64String(fileBytes);
                //Console.WriteLine(encodedFile);
                return encodedFile;
            }
        }

        public static string EncodeImage(IFormFile img)
        {
            //image croppen en resizen
            int headerWidth = 1200;

            using Image image = Image.Load(img.OpenReadStream());
            int cropWidth = (image.Height < image.Width / 2) ? image.Height * 2 : image.Width;
            int cropHeight = (image.Height < image.Width / 2) ? image.Height : image.Width / 2;
            image.Mutate(x => x.Crop(new Rectangle((image.Width - cropWidth) / 2, (image.Height - cropHeight) / 2, cropWidth, cropHeight))
                               .Resize(headerWidth, headerWidth / 2));

            //image encoden
            using (var ms = new MemoryStream())
            {
                image.SaveAsJpeg(ms);
                var imageBytes = ms.ToArray();
                string encodedImage = Convert.ToBase64String(imageBytes);
                return encodedImage;
            }
        }
    }
}
