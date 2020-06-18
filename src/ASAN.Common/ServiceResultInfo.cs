using System;

namespace ASAN.Common
{
    public class ServiceResultInfo
    {
        public ServiceResultInfo()
        {
        }

        public Int64 NewId { get; set; }

        public bool Succeeded { get; set; }

        public string Message { get; set; }
    }
}