using MasterMindBattleApi.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MasterMindBattleApi.Helpers
{
    public class OpenApiList<T>
    {
        [JsonPropertyName("__next")]
        public string? NextLink { get; set; }
        public T[] Data { get; set; }


        public OpenApiList()
        {
            //Todo: figure out how to initialize the array.
            NextLink = null;
        }

        public OpenApiList(T[] data, string? nextLink)
        {
            Data = data;
            NextLink = nextLink;
        }


        public void BuildFromDataAndQueryParams(HttpRequest request, List<T> fullList)
        {
            List<T> reducedList = new List<T>();
            int top = 10;
            int skip = 0;
            OpenApiHelpers.FetchTopAndSkip(request, ref top, ref skip);

            //Created reduced list
            string? nextLink = null;
            for (var i = skip; i < skip + top; i++)
            {
                if (i < fullList.Count)
                {
                    reducedList.Add(fullList[i]);
                }
                else
                {
                    break;
                }
            }

            //Calculate NextLink if needed
            if (skip + top < fullList.Count)
            {
                skip = skip + top;
                nextLink = string.Format("{0}://{1}{2}{3}?", request.Scheme, request.Host, request.PathBase, request.Path);
                bool ampersandNeeded = false;
                foreach (var param in request.Query)
                {
                    if (param.Key.ToUpper() != "TOP" && param.Key.ToUpper() != "SKIP")
                    {
                        if (ampersandNeeded) nextLink += "&";
                        ampersandNeeded = true;
                        nextLink += string.Format("{0}={1}", param.Key, param.Value);
                    }
                }
                if (ampersandNeeded) nextLink += "&";
                nextLink += string.Format("top={0}&skip={1}", top, skip);
            }

            NextLink = nextLink;
            Data = reducedList.ToArray();
        }
    }
}
