using ReiLeilaoCore.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;


namespace ReiLeilaoCore.Core.Util
{
    public class RestConnection
    {
        public string GetResponseRest(string url, string urlRequest, Method method, List<KeyValue> parameterList, List<KeyValue> urlSegmentList)
        {
            var client = new RestClient(url); // baixar via nuget o RestSharp
            var request = new RestRequest(urlRequest, method);

            // Adiciona os parâmetros 
            if (parameterList != null)
                foreach (var keyValueParamter in parameterList)
                    request.AddParameter(keyValueParamter.Key, keyValueParamter.Value);

            // Substitui o que está dentro do {} enviado no request. Exemplo "resource/{id}"
            if (urlSegmentList != null)
                foreach (var keyValueUrlSegment in urlSegmentList)
                    request.AddParameter(keyValueUrlSegment.Key, keyValueUrlSegment.Value);

            var response = client.Execute(request);
            return response.Content;
        }
    }
}
