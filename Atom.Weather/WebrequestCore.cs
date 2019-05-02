using Atom.Weather.Entity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Atom.Weather
{
    public class WebrequestCore
    {
        public string Post(Uri url, string value)
        {
            var request = WebRequest.Create(url);
            var byteData = Encoding.ASCII.GetBytes(value);
            request.ContentType = "application/json";
            request.Method = "POST";

            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(byteData, 0, byteData.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return responseString;
            }
            catch (WebException e)
            {
                return null;
            }
        }
        public string Get(Uri url)
        {
            var request = WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "GET";

            try
            {
                WebResponse response = request.GetResponse();
                return new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (WebException e)
            {
                return null;
            }
        }
    }
}
