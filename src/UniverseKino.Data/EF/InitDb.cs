using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Data.Entities;

namespace UniverseKino.Data
{
    class InitDb
    {
        //private readonly ModelBuilder _modelBuilder;

        //public InitDb(ModelBuilder modelBuilder)
        //{
        //    _modelBuilder = modelBuilder;
        //}

        //public void InitCinemaHall()
        //{
        //    _modelBuilder.Entity<CinemaHall>().HasData(
        //        new CinemaHall[]
        //        {
        //            new CinemaHall
        //            {
        //                Id = 1,
        //                Number = 1,
        //                Seats = GetSeats(10, 10, 100, 1)
        //            },
        //            new CinemaHall
        //            {
        //                Id = 2,
        //                Number = 2,
        //                Seats = GetSeats(10, 10, 150, 2)
        //            },
        //            new CinemaHall
        //            {
        //                Id = 3,
        //                Number = 3,
        //                Seats = GetSeats(10, 10, 150, 3)
        //            }
        //        });
        //}

        public List<Seat> GetSeats(int countPlace, int numberRow, decimal cost, int cinemaId)
        {
            var list = new List<Seat>();

            for (int i = 1; i <= countPlace; i++)
            {
                for (int j = 1; i <= numberRow; i++)
                {
                    list.Add(new Seat { Id = 1, Cost = cost, IdCinemaHall = 1, Number = j, Row = i });
                }
            }

            return list;
        }
    }
}