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
    internal class HallManager : ICrudService<Hall>, IPrintService
    {
        public void Add(Hall hall)
        {
            DataContext.Halls.Add(hall);
        }

        public void Delete(int id)
        {
            int index = FindHelper.FindHallIndex(id);

            if (index == -1)
            {
                Console.WriteLine("Not found");

                return;
            }

            DataContext.Halls.RemoveAt(index);
            Console.WriteLine("Deleted");
        }

        public Hall Get(int id)
        {
            int index = FindHelper.FindHallIndex(id);

            if (index == -1)
            {
                return null;
            }

            return DataContext.Halls[index];
        }

        public List<Hall> GetAll()
        {
            return DataContext.Halls;
        }

        public void Print()
        {
            foreach (var item in DataContext.Halls)
            {
                Console.WriteLine(item);
                Console.WriteLine("-".PadRight(20, '-'));
            }
        }

        public void Update(int id, Hall newHall)
        {
            int index = FindHelper.FindHallIndex(id);

            if (index == -1)
            {
                Console.WriteLine("Not found");

                return;
            }

            DataContext.Halls[index] = newHall;
        }
    }
}
