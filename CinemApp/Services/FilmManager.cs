using CinemApp.Data;
using CinemApp.Models;
using CinemApp.Services.Contracts;
using CinemApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemApp.Services
{
    internal class FilmManager : ICrudService<Film>, IPrintService
    {
        public void Add(Film film)
        {
            DataContext.Films.Add(film);
        }

        public void Delete(int id)
        {
            int index = FindHelper.FindFilmIndex(id);

            if (index == -1)
            {
                Console.WriteLine("Not found");

                return;
            }

            DataContext.Halls.RemoveAt(index);
            Console.WriteLine("Deleted");
        }

        public Film Get(int id)
        {
            int index = FindHelper.FindFilmIndex(id);

            if (index == -1)
            {
                return null;
            }

            return DataContext.Films[index];
        }

        public List<Film> GetAll()
        {
            return DataContext.Films;
        }

        public void Print()
        {
            foreach (var item in DataContext.Films)
            {
                Console.WriteLine(item);
                Console.WriteLine("-".PadRight(20, '-'));
            }
        }

        public void Update(int id, Film newFilm)
        {
            int index = FindHelper.FindFilmIndex(id);

            if (index == -1)
            {
                Console.WriteLine("Not found");

                return;
            }

            DataContext.Films[index] = newFilm;
        }
    }
}
