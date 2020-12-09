using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITtrainees.Logic
{
    [Route("api/question")]
    [ApiController]
    class QuestionAPI : ControllerBase
    {
        [HttpGet("{test1}/{test2}")]
        private string test(int test1, string test2) 
        {
            return test1.ToString() + test2;
        }
    }
}
