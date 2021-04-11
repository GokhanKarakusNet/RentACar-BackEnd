using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result:IResult
    {
        public Result(bool success, string message):this(success) // this success demek 2 parametli yolladıgımda burayı calıstır ama burdaki successi diğer tarafa attım kendimi tekrarlamamak için bu yüzden sen ordaki successide calıstır demek.
        {
            Message = message;
            //Success = success; dont repeat yourself! 
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }
        public string Message { get; }
    }
}
