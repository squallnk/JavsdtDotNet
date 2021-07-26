
using Javsdt.Shared.Enum;

namespace Javsdt.API.Common.Response
{
    public class MyResult
    {
        public MyResult(ResultType status, object entity = null)
        {
            Status = status;
            Entity = entity;
        }

        public ResultType Status { get; set; }

        public object Entity { get; set; }

    }
}
