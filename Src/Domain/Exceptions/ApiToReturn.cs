using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ApiToReturn
    {
        public string Message {  get; set; }
        public int StatusCode { get; set; }
        public List<string> Messages { get; set; } = new();//new List<string>();
        public string Detail { get; set; }

        public ApiToReturn()
        {

        }
        public ApiToReturn(string message)
        {
            Message = message;
        }
        public ApiToReturn(int statuscode,string message)
        {
            StatusCode = statuscode;    
            Message = message;
        }
        public ApiToReturn(int statuscode,List<string> messages,string detail)
        {
            Messages= messages;
            Detail = detail;
            StatusCode = statuscode;
        }
        public ApiToReturn(int statuscode,List<string> messages)
        {
            Messages = messages;
            StatusCode = statuscode;
        }
        public ApiToReturn(int statuscode, string message, List<string> messages, string detail)
        {
            Messages = messages;
            Detail = detail;
            StatusCode = statuscode;
            Message = message;
        }
    }
}
