using Quiz.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            Game spiel = new Game(true);
            int counter = 0;

            Question frage1 = new Question("Wer hat die WM 2014 gewonnen?");
            frage1.AddAnswer(new Answer("Brasilien"));
            frage1.AddAnswer(new Answer("England"));
            frage1.AddAnswer(new Answer("Argentinien"));
            frage1.AddAnswer(new Answer("Deutschland", true));
            spiel.AddQuestion(frage1);

            
            Question frage2 = new Question("Wer hat ein Tor mit der Hand Gottes erzielt?");
            frage2.AddAnswer(new Answer("Maradona", true));
            frage2.AddAnswer(new Answer("Messi"));
            frage2.AddAnswer(new Answer("Neymar"));
            frage2.AddAnswer(new Answer("Crespo"));
            spiel.AddQuestion(frage2);

            
            Question frage3 = new Question("Wer wurde Torschützenkönig in der letzten Laliga Saison?");
            frage3.AddAnswer(new Answer("Gareth Bale"));
            frage3.AddAnswer(new Answer("Antoine Griezmann"));
            frage3.AddAnswer(new Answer("Lionel Messi", true));
            frage3.AddAnswer(new Answer("Karim Benzema"));
            spiel.AddQuestion(frage3);


            while (spiel.Status == GameStatus.Active)
            {
                var frage = spiel.NextQuestion;
                var antworten = frage.Answers;
                Console.WriteLine(frage.Text);

                foreach (Answer a in antworten)
                {
                    Console.WriteLine(a.Text);
                    counter++;
                }

                Console.WriteLine("Was ist deine Antwort?");
                int eingabe = Convert.ToInt32(Console.ReadLine());
                antworten[eingabe].IsChecked = true;
                spiel.ValidateCurrentQuestion();
            }

            if (spiel.Status == GameStatus.HasFinished)
            {
                Console.WriteLine("Gewonnen!");
            }
            else
            {
                Console.WriteLine("Verloren!");
            }
        }
    }
}
