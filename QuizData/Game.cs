using QuizData.Models;
using System.Text.Json;

namespace Quiz
{
    public class Game
    {
        Random _random;
        int _currentIndex;
        List<int> _categories;
        List<Question> _allQuestions;

        public Game()
        {
            _random = new Random();
            CreateAllQuestions();
            GetCategories();
            CurrentCategory = _categories![_currentIndex];
        }

      
        public int CurrentCategory { get; set; }
        public Question CurrentQuestion { get; set; }
        public void GetQuestion()
        {
            var questionsFromCurrentCategory = _allQuestions.Where(q => q.Category == CurrentCategory).ToList();
            var index = _random.Next(0, questionsFromCurrentCategory.Count);
            var selectedQuestion = questionsFromCurrentCategory[index];
            selectedQuestion.Answers = selectedQuestion.Answers.OrderBy(a => _random.Next()).ToList();
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
           var maximumIndex = _categories.Count - 1;
           return _currentIndex == maximumIndex;
        }
        public void IncreaseCategory()
        {
            _currentIndex++;
            CurrentCategory = _categories[_currentIndex];
        }

        private void CreateAllQuestions()
        {
            var path = $"{Directory.GetCurrentDirectory()}\\questions.json";
            var text = File.ReadAllText(path);
            _allQuestions = JsonSerializer.Deserialize<List<Question>>(text)!;
        }

        private void GetCategories()
        {
            _categories = _allQuestions!.Select(q => q.Category).Distinct().OrderBy(c => c).ToList();
        }
    }
}
