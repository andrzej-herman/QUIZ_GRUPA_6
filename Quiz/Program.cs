using Quiz;


// powołanie do życia obiektów typu Backend
var backend = new Game();


// tworzenie listy wszystkich pytań => W konstruktorze
// ustawienie kategorii na najniższą = > W konstruktorze

// wyświetlanie ekranu powitalnego
Display.ShowWelcomeScreen();

while(true)
{
    // losowanie pytania
    backend.GetQuestion();

    // wyswietlanie pytania
    var playerChoice = Display.DisplayQuestionAndGetAnswer(backend.CurrentQuestion);

    // walidacja odpowiedzi gracza
    var isCorrect = backend.CheckPlayerChoice(playerChoice);

    // rozdzielenie logi w zależności od odpowiedzi gracza
    if (isCorrect)
    {
        // sprawdzanie czy to nie było ostatnie pytanie
        if (backend.CheckIfLastAnswer())
        {
            Display.Winner();
            break;
        }
        else
        {
            Display.GoodAnswer(backend.CurrentCategory);
            // podnismy kategorie na wyzszą
            backend.IncreaseCategory();
        }
    }
    else
    {
        Display.GameOver();
        break;
    }
}

Console.ReadLine();