using System.Collections.Generic;  
using FighterSolution.Models;

namespace FighterSolution.DataAccess
{
    public interface IDataAccessProvider
    {
        void AddFighterRecord(fighter patient);  
        void UpdateFighterRecord(fighter patient);  
        void DeleteFighterRecord(string id);  
        fighter GetFighterSingleRecord(string id);  
        List<fighter> GetFighterRecords(); 
    }
}