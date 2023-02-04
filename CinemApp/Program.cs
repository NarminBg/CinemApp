using CinemApp.Models.Enums;
using CinemApp.Models;
using CinemApp.Services;

namespace CinemApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var venera = new Hall
            {
                Id = 1,
                Name = "Venera",
                RowCount = 10,
                ColumnCount = 12
            };

            var mercuri = new Hall
            {
                Id = 2,
                Name = "Mercuri",
                RowCount = 6,
                ColumnCount = 6
            };

            var yupiter = new Hall
            {
                Id = 3,
                Name = "Yupiter",
                RowCount = 6,
                ColumnCount = 6
            };

            var cinemaPlus = new Cinema
            {
                Id = 1,
                Name = "CinemaPlus",
                Halls = new List<Hall> { venera, mercuri }
            };

            var nizamiKino = new Cinema
            {
                Id = 2,
                Name = "Nizami kinoteatr",
                Halls = new List<Hall> { yupiter }
            };

            var filmSeven = new Film
            {
                Id = 1,
                Name = "Seven",
                Director = "Nolan",
                TimeInMinute = 95
            };

            var filmZodiac = new Film
            {
                Id = 2,
                Name = "Zodiac",
                Director = "Nolan",
                TimeInMinute = 135
            };

            var sessionSeven = new Session
            {
                Id = 1,
                Film = filmSeven,
                Hall = venera,
                Seats = new State[venera.RowCount, venera.ColumnCount],
                Price = 15,
                CinemaId = 1,
                Cinema = cinemaPlus,
            };

            var sessionZodiac = new Session
            {
                Id = 2,
                Film = filmZodiac,
                Hall = mercuri,
                Seats = new State[mercuri.RowCount, mercuri.ColumnCount],
                Price = 10,
                CinemaId = 2,
                Cinema = nizamiKino
            };
            var hallManager = new HallManager();
            hallManager.Add(mercuri);
            hallManager.Add(venera);
            hallManager.Add(yupiter);

            var filmManager = new FilmManager();
            filmManager.Add(filmZodiac);
            filmManager.Add(filmSeven);

            var cinemaManager = new CinemaManager();
            cinemaManager.Add(cinemaPlus);
            cinemaManager.Add(nizamiKino);

            var sessionManager = new SessionManager();
            sessionManager.Add(sessionZodiac);
            sessionManager.Add(sessionSeven);

            var ticketManager = new TicketManager(sessionManager, cinemaManager);

            string command;

            do
            {
                Console.Write("Enter the command:");
                command = Console.ReadLine();

                if (command == "buy ticket")
                    ticketManager.BuyTicket();
                else if (command == "show tickets")
                    ticketManager.Print();
                else if (command == "show films")
                    filmManager.Print();
                else if (command == "show halls")
                    hallManager.Print();


            } while (command != "quit");
        }
    }
}