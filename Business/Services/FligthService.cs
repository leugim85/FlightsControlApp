using Business.Entities;
using Business.Models;
using DataBase;
using System;
using System.Collections.Generic;

namespace Business.Services
{
    public class FligthService : IFligthService
    {
        private readonly IDatabaseConnection database;

        public FligthService(IDatabaseConnection database)
        {
            this.database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public List<Fligth> GetFligths()
        {
            var fligths = database.GetFligths();
            return fligths;
        }

        public bool AddFligth(FligthDto fligth)
        {
            var result = database.AddFligth(fligth);
            return result;
        }

        public Fligth GetFligthByid(int id) 
        {
            return database.GetFligthById(id);
        }
    }
}
