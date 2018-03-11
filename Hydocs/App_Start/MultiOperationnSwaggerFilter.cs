using System;
using System.Collections.Generic;
using Swashbuckle.Swagger;
using System.Web.Http.Description;

namespace Hydocs.App_Start
{
    /// <summary>
    /// A customized sample code to make Swagger append Operations IDs to the Ops names. TKJ 230317
    /// </summary>
    public class MultiOperationnSwaggerFilter : IOperationFilter
    {
        public void Apply(
               Operation operation,
               SchemaRegistry schemaRegistry,
               ApiDescription apiDescription)
        {
            if (operation.parameters != null)
            {
                operation.operationId += "By";
                foreach (var parm in operation.parameters)
                {
                    operation.operationId += string.Format("{0}", parm.name);
                }
            }
        }
    }



 

}