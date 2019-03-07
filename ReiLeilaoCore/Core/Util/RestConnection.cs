using ReiLeilaoCore.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Util
{
    public class RestConnection
    {
        //public string GetResponseRestPost(string url, string urlRequest, List<KeyValue> parameterList, List<KeyValue> urlSegmentList)
        //{
        //    var client = new RestClient(url); // baixar via nuget o RestSharp
        //    var request = new RestRequest(urlRequest, Method.POST);
        //    request.RequestFormat = DataFormat.Json;
        //    request.AddBody()

        //}

        const string url = "http://localhost:3000/";

        public string GetRequest(string endpoint)
        {
            var client = new RestClient(url);
            var request = new RestRequest(endpoint, Method.GET);
            return client.Execute(request).Content;
        }

        public string GetRequestById(string endpoint, Entity entidade)
        {
            var client = new RestClient(url);
            var request = new RestRequest(endpoint, Method.GET);
            //request.AddParameter("id", entidade.Id);
            IRestResponse response = client.Execute(request);
            var content = response;
            return content.Content;
            //return null;
        }

        public string PostRequest(string endpoint, object Body)
        {
            var client = new RestClient(url);
            var request = new RestRequest(endpoint, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(Body);
            return client.Execute(request).Content;
        }

        public string PutRequest(string endpoint, object body)
        {
            var client = new RestClient(url);
            var request = new RestRequest(endpoint, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(body);
            return client.Execute(request).Content;
        }

        public string DeleteRequest(string endpoint, object body)
        {
            var client = new RestClient(url);
            var request = new RestRequest(endpoint, Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(body);
            return client.Execute(request).Content;
        }

    }
}
