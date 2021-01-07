using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Services
{
    public interface IConvertorServices
    {
        string ConvertFileToBase64(string path);
        string ConvertImageToBase64(string path);
        void ConvertBase64ToFile(string filename, string base64Str);
    }
}
