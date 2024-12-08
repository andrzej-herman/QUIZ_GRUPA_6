
namespace QuizData.Models
{
    public class Question : Base
    {
        public int Category { get; set; }    
        public List<Answer> Answers { get; set; }
    }
}
