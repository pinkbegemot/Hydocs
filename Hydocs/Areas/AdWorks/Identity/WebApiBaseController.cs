using System;
using System.Web.Http;
using CPMS.Contrib.SimpleInjector;
using CPMS.Security.Infrastructure;
using CPMS.Core.Util;
using CPMS.Contrib.Mvc.ActionResults;
using CPMS.Core.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using CPMS.Contrib.Mvc.Json;
using System.Linq;

namespace CPMS.Web.API.GeniusDriver.Infrastructure
{
    public class WebApiBaseController : ApiController
    {
      

        [NonAction]
        protected virtual JsonNetResult AsJsonTableResultSet<TDataModel>(IEnumerable<TDataModel> results)
            where TDataModel : class
        {
            // In case enumerable hasn't been sealed yet.
            var items = results.ToList();

            // Is it a paged request?
            var paged = results as IPagedEnumerable<TDataModel>;

            var data = new
            {
                total = paged?.TotalItemCount ?? items.Count,
                rows = items
            };

            return JsonNet(data, new JsonSerializerSettings
            {
                Converters =
                {
                    // Add some custom convertors for Serialisation of special types in the DataModels.
                    new CustomStringEnumConverter(),
                    //new ActionUrlSerialiser(Url),
                    new DateTimeSerialiser(),
                    new TimeSpanSerialiser(),
                }
            });
        }

        [NonAction]
        protected JsonNetResult JsonNet(object data, JsonSerializerSettings serializerSettings = null)
        {
            return new JsonNetResult
            {
                Data = data,
                SerializerSettings = serializerSettings ?? new JsonSerializerSettings()
            };
        }
    }
}