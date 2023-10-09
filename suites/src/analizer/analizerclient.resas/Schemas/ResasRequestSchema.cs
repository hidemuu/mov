using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Mov.Suite.AnalizerClient.Resas.Schemas
{
    public class ResasRequestSchema<TRequest> where TRequest : IResasRequestSchema
    {

        #region property

        public TRequest Request { get; }

        #endregion property

        #region constructor

        public ResasRequestSchema(TRequest request)
        {
            Request = request;
        }

        #endregion constructor

        #region method

        public string CreateRequestString()
        {
            var result = string.Empty;
            foreach(var parameter in Request.Parameters)
            {
                result += $"{parameter.Key}={parameter.Value}&";
            }
            result = result.TrimEnd('&');
            return result;
        }

        #endregion method

    }
}
