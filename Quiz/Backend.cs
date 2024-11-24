using System.Text.Json;

namespace Quiz
{
    public class Backend
    {
        Random random;

        public Backend()
        {
            random = new Random();
            CreateAllQuestions();
            Categories = AllQuestions!.Select(q => q.Category).Distinct().OrderBy(c => c).ToList();
            CurrentCategory = Categories[CurrentIndex];
        }

        public int CurrentIndex { get; set; }
        public List<int> Categories { get; set; }
        public List<Question> AllQuestions { get; set; }
        public int CurrentCategory { get; set; }
        public Question CurrentQuestion { get; set; }

        public void CreateAllQuestions()
        {
            var path = $"{Directory.GetCurrentDirectory()}\\questions.json";
            var text = File.ReadAllText(path);
            AllQuestions = JsonSerializer.Deserialize<List<Question>>(text)!;
        }

        public void GetQuestion()
        {
            var questionsFromCurrentCategory = AllQuestions.Where(q => q.Category == CurrentCategory).ToList();
            var index = random.Next(0, questionsFromCurrentCategory.Count);
            var selectedQuestion = questionsFromCurrentCategory[index];
            selectedQuestion.Answers = selectedQuestion.Answers.OrderBy(a => random.Next()).ToList();
            var id = 1;
            selectedQuestion.Answers.ForEach(a => a.Id = id++);
            CurrentQuestion = selectedQuestion;
        }

        public bool CheckPlayerChoice(int playerChoice)
        {
            var anyAnswer = CurrentQuestion.Answers
                .FirstOrDefault(a => a.Id == playerChoice);

            if (anyAnswer != null)
            {
                return anyAnswer.IsCorrect;
            }

            return false;  
        }

        public bool CheckIfLastAnswer()
        {
           var maximumIndex = Categories.Count - 1;
           return CurrentIndex == maximumIndex;
        }

        public void IncreaseCategory()
        {
            CurrentIndex++;
            CurrentCategory = Categories[CurrentIndex];
        }
    }
}
