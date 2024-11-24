using Quiz;


// powołanie do życia obiektów typu Backend
var backend = new Backend();


// tworzenie listy wszystkich pytań => W konstruktorze
// ustawienie kategorii na najniższą = > W konstruktorze

// wyświetlanie ekranu powitalnego
Frontend.ShowWelcomeScreen();

while(true)
{
    // losowanie pytania
    backend.GetQuestion();

    // wyswietlanie pytania
    var playerChoice = Frontend.DisplayQuestionAndGetAnswer(backend.CurrentQuestion);

    // walidacja odpowiedzi gracza
    var isCorrect = backend.CheckPlayerChoice(playerChoice);

    // rozdzielenie logi w zależności od odpowiedzi gracza
    if (isCorrect)
    {
        // sprawdzanie czy to nie było ostatnie pytanie
        if (backend.CheckIfLastAnswer())
        {
            Frontend.Winner();
            break;
        }
        else
        {
            Frontend.GoodAnswer(backend.CurrentCategory);
            // podnismy kategorie na wyzszą
            backend.IncreaseCategory();
        }
    }
    else
    {
        Frontend.GameOver();
        break;
    }
}

Console.ReadLine();