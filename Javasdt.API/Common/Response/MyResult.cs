
using Javasdt.Shared.Enums;

namespace Javasdt.API.Common.Response
{
    public class MyResult
    {
        public MyResult(ResultStatusEnum status, object entity = null)
        {
            Status = status;
            Entity = entity;
        }

        public ResultStatusEnum Status { get; set; }

        public object Entity { get; set; }

    }
}
