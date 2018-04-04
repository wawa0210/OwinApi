using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Application
{

    public interface ILoggerService
    {

        void WriteLog();
    }

    public class LoggerService : ILoggerService
    {
        public  IExceptionLessService ExceptionLessService { get; set; }

        public void WriteLog()
        {
            ExceptionLessService.WriteException();

            var count = 100;
            var sum = 100 + count;
        }
    }
}
