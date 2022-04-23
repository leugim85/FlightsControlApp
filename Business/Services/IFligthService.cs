using Business.Entities;
using Business.Models;
using System.Collections.Generic;

namespace Business.Services
{
    public interface IFligthService
    {
       public bool AddFligth(FligthDto fligth);

       public List<Fligth> GetFligths();
       
        public Fligth GetFligthByid(int id);
    }
}