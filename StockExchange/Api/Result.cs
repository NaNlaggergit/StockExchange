using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Api
{
    internal class Result
    {
        public bool IsSuccess;
        public string Error;
        public Result()
        {
            IsSuccess = false;
            Error = null;
        }
    }
}
