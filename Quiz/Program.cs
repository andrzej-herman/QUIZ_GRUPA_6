using Quiz;


// powołanie do życia obiektów typu Backend
var backend = new Backend();


// tworzenie listy wszystkich pytań => W konstruktorze
// ustawienie kategorii na najniższą = > W konstruktorze

// wyświetlanie ekranu powitalnego
Frontend.ShowWelcomeScreen();

// losowanie pytania
backend.GetQuestion();

// wyswietlanie pytania
var playerChoice = Frontend.DisplayQuestion(backend.CurrentQuestion);

// walidacja odpowiedzi gracza
var isCorrect = backend.CheckPlayerChoice(playerChoice);

// rozdzielenie logi w zależności od odpowiedzi gracza
if (isCorrect)
{
    Console.WriteLine(" HURRA !!!!");
}
else
{
    Console.WriteLine(" GAME OVER !!!!");
}


Console.ReadLine();