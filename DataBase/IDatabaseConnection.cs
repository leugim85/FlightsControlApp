using Business.Entities;
using Business.Models;
using Domain.Models;
using System.Collections.Generic;

namespace DataBase
{
    public interface IDatabaseConnection
    {
        bool AddAirline(string airline);
        bool AddCity(string city);
        bool AddFligth(FligthDto fligthDto);
        bool AddStatus(string status);
        bool AddUser(UserToAdd user);
        List<string> GetEntitiesName(string fieldName, string tableName);
        List<Fligth> GetFligths();
        bool ValidateIfExists(string entityName, string fieldName, string tableName);
        UserResultDto ValidateUser(string userName);
        int GetEntityId(string name, string columnName, string table);
        Fligth GetFligthById(int id);
    }
}