using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace SOLID_Lab
{
    public class Photo
    {

        public static void CopyPhoto(string photoPath)
        {
            string folder = Path.GetDirectoryName(photoPath);
            string fileName = Path.GetFileName(photoPath);
            string extension = Path.GetExtension(photoPath);
            string newFileName = folder + @"\" + Path.GetFileNameWithoutExtension(photoPath) + "_bak" + "." + extension;
            File.Copy(photoPath, newFileName, true);
        }

    }
}
