using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ContactBook.Commons.Wrapper
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

        public ResponseWrapper Post(string content)
        {
            string requestUri = "https://localhost:44344/Contact/";
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage httpResponse = null;
                if (content != null)
                {
                    using (var postContent = new StringContent(content))
                    {
                        postContent.Headers.Clear();
                        postContent.Headers.Add("Content-Type", "application/json");
                        httpResponse = httpClient.PostAsync(requestUri, postContent).Result;
                    }
                }

                return new ResponseWrapper()
                {
                    StatusCode = httpResponse.StatusCode,
                    Content = httpResponse.Content.ReadAsStringAsync().Result
                };
            }
        }
    }
}
