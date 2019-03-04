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

        public string GetRequest(string url, string endpoint)
        {
            var client = new RestClient(url);
            var request = new RestRequest(endpoint, Method.GET);
            return client.Execute(request).Content;
        }

        public string GetRequestById(string url, string endpoint, Entity entidade)
        {
            var client = new RestClient(url);
            var request = new RestRequest(endpoint, Method.GET);
            //request.AddParameter("id", entidade.Id);
            IRestResponse response = client.Execute(request);
            var content = response;
            return content.Content;
            //return null;
        }
    }
}
