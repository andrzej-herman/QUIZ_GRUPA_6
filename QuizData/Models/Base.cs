using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizData.Models
{
    public abstract class Base
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
