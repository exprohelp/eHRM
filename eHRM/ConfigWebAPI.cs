using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eHRM
{

    public static class ConfigWebAPI
    {
        public static string domain = ConfigurationManager.AppSettings["domainName"].ToString();
        public static string SingnalRServer = ConfigurationManager.AppSettings["SingnalRServer"].ToString();
        public static Uri BaseURL = new Uri("http://" + domain + "/PharmacyWebAPI/");
        public static Uri LocalURL = new Uri("http://" + domain + "/PharmacyAPI/");

        public static datasetWithResult CallAPI(string RoutingNameofAPI, object obj)
        {
            datasetWithResult dwr = new datasetWithResult();
            HttpClient client = new HttpClient();
            try
            {
                if (domain == "localhost")
                    client.BaseAddress = LocalURL;
                else
                    client.BaseAddress = BaseURL;

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync(RoutingNameofAPI, obj).Result;

                if (response.IsSuccessStatusCode)
                {
                    string response_data = response.Content.ReadAsStringAsync().Result;
                    dwr = JsonConvert.DeserializeObject<datasetWithResult>(response_data, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                        Formatting = Formatting.None,
                        DateFormatHandling = DateFormatHandling.IsoDateFormat,
                        FloatParseHandling = FloatParseHandling.Decimal
                    });
                }
                return dwr;
            }
            catch (Exception ex)
            {
                dwr.result = null;
                dwr.message = ex.Message;
            }
            return dwr;

        }
        public static string CallAPIObject(string RoutingNameofAPI, object obj)
        {
            datasetWithResult dwr = new datasetWithResult();
            HttpClient client = new HttpClient();
            string response_data = string.Empty;
            try
            {
                if (domain == "localhost")
                    client.BaseAddress = LocalURL;
                else
                    client.BaseAddress = BaseURL;

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync(RoutingNameofAPI, obj).Result;

                if (response.IsSuccessStatusCode)
                {
                    response_data = response.Content.ReadAsStringAsync().Result;

                }
                return response_data;
            }
            catch (Exception ex)
            {
                dwr.result = null;
                dwr.message = ex.Message;
            }
            return response_data;

        }
    }

    public static class MISProxy
    {
        public static string Baseurl = ConfigurationManager.AppSettings["APIHostPath"].ToString();
        public static resultSetMIS CallMISWebApiMethod(string methodRoute, Object obj)
        {
            resultSetMIS dwr = new resultSetMIS();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(Baseurl);
                    HttpResponseMessage response = client.PostAsJsonAsync("api/" + methodRoute + "", obj).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string response_data = response.Content.ReadAsStringAsync().Result;
                        dwr = JsonConvert.DeserializeObject<resultSetMIS>(response_data, new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                            MissingMemberHandling = MissingMemberHandling.Ignore,
                            Formatting = Formatting.None,
                            DateFormatHandling = DateFormatHandling.IsoDateFormat,
                            FloatParseHandling = FloatParseHandling.Decimal
                        });
                    }
                }
                catch (Exception ex) { dwr.ResultSet = null; dwr.Msg = ex.Message; }
            }
            return dwr;
        }
        public static string UploadDocumentByMultipart(string methodRoute, HttpContent obj)
        {
            string result = string.Empty;
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(Baseurl);
                    HttpResponseMessage response = client.PostAsync("api/" + methodRoute + "", obj).Result;
                    response.EnsureSuccessStatusCode();
                    client.Dispose();
                    result = response.Content.ReadAsStringAsync().Result.ToString();
                }
                catch (Exception ex) { result = "Error"; result = ex.Message; }
            }
            return result;
        }
    }



}