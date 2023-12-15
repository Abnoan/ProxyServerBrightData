using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProxyServerBrightData
{
    public static class RequestProcessor
    {
        public static async Task ProcessRequestAsync(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;

            // Forwarding logic: Create a new request to the destination server
            HttpWebRequest destinationRequest = (HttpWebRequest)WebRequest.Create(request.Url);
            destinationRequest.Method = request.HttpMethod;
            destinationRequest.UserAgent = request.UserAgent;
            destinationRequest.ContentType = request.ContentType;

            // Copy the request body for POST or PUT methods
            if (request.HttpMethod == "POST" || request.HttpMethod == "PUT")
            {
                using Stream destinationStream = destinationRequest.GetRequestStream();
                using Stream inputStream = request.InputStream;
                await inputStream.CopyToAsync(destinationStream);
            }

            // Response relay logic: Get the response from the destination server
            using HttpWebResponse destinationResponse = (HttpWebResponse)await destinationRequest.GetResponseAsync();
            HttpListenerResponse response = context.Response;

            // Set the status code and copy the response headers
            response.StatusCode = (int)destinationResponse.StatusCode;
            foreach (string header in destinationResponse.Headers)
            {
                response.Headers[header] = destinationResponse.Headers[header];
            }

            // Copy the response content
            using Stream responseStream = response.OutputStream;
            using Stream destinationResponseStream = destinationResponse.GetResponseStream();
            await destinationResponseStream.CopyToAsync(responseStream);
        }
    }
}