using CinemApp.Data;
using CinemApp.Models.Enums;
using CinemApp.Models;
using CinemApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemApp.Services
{
    internal class TicketManager : IPrintService
    {
        private readonly SessionManager _sessionManager;
        private readonly CinemaManager _cinemaManager;

        public TicketManager(SessionManager sessionManager, CinemaManager cinemaManager)
        {
            _sessionManager = sessionManager;
            _cinemaManager = cinemaManager;
        }

        public void BuyTicket()
        {
            Console.WriteLine("Cinemas:");

            _cinemaManager.Print();

            cinema:
            Console.Write("Cinema id:");
            var cinemaId = int.Parse(Console.ReadLine());

            var cinema = _cinemaManager.Get(cinemaId);

            if (cinema == null)
            {
                Console.WriteLine("Not found");

                goto cinema;
            }

            Console.WriteLine(cinema);

            Console.WriteLine("session:");

            _sessionManager.PrintSessionByCinema(cinema.Id);

        sesssion:
            Console.Write("Session id:");
            var sessionId = int.Parse(Console.ReadLine());

            var session = _sessionManager.Get(sessionId);

            if (session == null || session.CinemaId != cinema.Id)
            {
                Console.WriteLine("Not found");

                goto sesssion;
            }

            Console.WriteLine(session);

            _sessionManager.PrintSessionSeats(session);

        row:
            Console.Write("Row:");
            var row = int.Parse(Console.ReadLine());

            if (!(row >= 1 && row <= session.Seats.GetLength(0)))
            {
                Console.WriteLine("Row is not correct");

                goto row;
            }

        column:
            Console.Write("Column:");
            var column = int.Parse(Console.ReadLine());

            if (!(column >= 1 && column <= session.Seats.GetLength(1)))
            {
                Console.WriteLine("Column is not correct");

                goto column;
            }

            if (session.Seats[row - 1, column - 1] == State.full)
            {
                Console.WriteLine("This seat is not empty");

                goto row;
            }

            session.Seats[row - 1, column - 1] = State.full;

            var ticket = new Ticket
            {
                Session = session,
                Row = row,
                Column = column
            };

            DataContext.Tickets.Add(ticket);
            Console.WriteLine("Ticket is bought");
        }

        public void Print()
        {
            foreach (var item in DataContext.Tickets)
            {
                Console.WriteLine(item);
                Console.WriteLine("-".PadRight(20, '-'));
            }
        }
    }
}
