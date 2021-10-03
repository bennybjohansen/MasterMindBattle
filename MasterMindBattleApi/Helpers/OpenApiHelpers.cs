using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMindBattleApi.Helpers
{
    public static class OpenApiHelpers
    {
        /// <summary>
        /// Examine if request includes a header with key=MockDataId.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="mockDataId">value of the requested mock data set</param>
        /// <returns>
        ///   true if MockDataId header is provided
        /// </returns>
        public static bool UseMockData (HttpRequest request, ref int mockDataId)
        {
            bool useMockData = false;
            foreach (var header in request.Headers)
            {
                if (header.Key.ToUpper()=="MOCKDATAID")
                {
                    useMockData = int.TryParse(header.Value, out mockDataId);
                    break;
                }
            }
            return useMockData;
        }

        public static void FetchTopAndSkip(HttpRequest request, ref int top, ref int skip)
        {
            foreach (var param in request.Query)
            {
                if (param.Key.ToUpper() == "TOP")
                {
                    int.TryParse(param.Value.ToString(), out top);
                }
                if (param.Key.ToUpper() == "SKIP")
                {
                    int.TryParse(param.Value.ToString(), out skip);
                }
            }
        }
    }
}
