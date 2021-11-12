using System.Collections.Generic;  
using FighterSolution.Models;

namespace FighterSolution.DataAccess
{
    public interface IDataAccessProvider
    {
        void AddFighterRecord(fighter Fighter);  
        void UpdateFighterRecord(fighter Fighter);  
        void DeleteFighterRecord(string id);  
        fighter GetFighterSingleRecord(string id);  
        List<fighter> GetFighterRecords(); 
    }
}