using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Application
{
    public interface IExceptionLessService
    {
        void WriteException();
    }

    public class ExceptionLessService : IExceptionLessService
    {
        public void WriteException()
        {
            var count = 100;

            var sum = 100 + count;
        }
    }
}
