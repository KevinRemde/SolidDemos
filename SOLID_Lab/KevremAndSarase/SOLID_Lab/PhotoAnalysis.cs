using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Lab
{
    class PhotoAnalysis : IPhotoAnalysis
    {
        public async Task<string> AnalyzeImage(string photoPath)
        {
            Image img = Image.FromFile(photoPath);
            byte[] byteData;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byteData = ms.ToArray();
            }

            string visionApiKey = ConfigurationManager.AppSettings["VisionApiKey"];

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", visionApiKey);
            string uri = "https://westus.api.cognitive.microsoft.com/vision/v1.0/analyze?visualFeatures=Categories&language=en";
            HttpResponseMessage response;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
            }

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return data;
                var results = JsonConvert.DeserializeObject(data);
            }

            return "";

        }


    }
}
