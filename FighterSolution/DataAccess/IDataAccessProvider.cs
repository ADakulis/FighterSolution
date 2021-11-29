using System.Collections.Generic;  
using FighterSolution.Models;

namespace FighterSolution.DataAccess
{
    public interface IDataAccessProvider
    {
        void AddFighterRecord(Fighter fighter);  
        void UpdateFighterRecord(Fighter fighter);  
        void DeleteFighterRecord(string id);  
        Fighter GetFighterSingleRecord(string id);  
        List<Fighter> GetFighterRecords();
        List<Fighter> GetTopFighters();
    }
}