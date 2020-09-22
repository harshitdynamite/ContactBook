using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;

namespace ContactBook.Wrapper
{
    public class HttpClientWrapper
    {
        public ResponseWrapper Get()
        {
            string requestUri = "https://localhost:44344/Contact";
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage httpResponse = httpClient.GetAsync(requestUri).Result;
                return new ResponseWrapper()
                {
                    StatusCode = httpResponse.StatusCode,
                    Content = httpResponse.Content.ReadAsStringAsync().Result
                };
            }
        }

        public ResponseWrapper Delete(string id)
        {
            string requestUri = "https://localhost:44344/Contact/" + id;
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage httpResponse = httpClient.DeleteAsync(requestUri).Result;
                return new ResponseWrapper()
                {
                    StatusCode = httpResponse.StatusCode,
                    Content = httpResponse.Content.ReadAsStringAsync().Result
                };
            }
        }
    }
}
