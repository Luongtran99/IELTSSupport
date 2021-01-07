using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Services
{
    public class ConvertorServices : IConvertorServices
    {
        public string ConvertFileToBase64(string path)
        {
            // get file name
            string[] part = path.Split('/');
            
            // insert to folder
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(path, $"{Directory.GetCurrentDirectory()}{@"\wwwroot\audios\"}{part[part.Length - 1]}");
            }

            string imgpath = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\audios\"}{part[part.Length - 1]}";
            byte[] data = File.ReadAllBytes(imgpath);
            string base64Str = Convert.ToBase64String(data);
            return base64Str;
        }

        public string ConvertImageToBase64(string path)
        {
            string[] part = path.Split('/');

            // insert to folder
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(path, $"{Directory.GetCurrentDirectory()}{@"\wwwroot\images\"}{part[part.Length - 1]}");
            }

            string imgpath = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\images\"}{part[part.Length - 1]}";
            byte[] data = File.ReadAllBytes(imgpath);
            string base64Str = Convert.ToBase64String(data);
            return base64Str;
        }

        public void ConvertBase64ToFile(string filename, string base64Str)
        {
            var bytes = Convert.FromBase64String(base64Str);
            using (var imageFile = new FileStream($"{Directory.GetCurrentDirectory()}{@"\wwwroot\audios\"}{filename}", FileMode.Create))
            {
                imageFile.Write(bytes, 0, bytes.Length);
                imageFile.Flush();
            }
        }

    }
}
