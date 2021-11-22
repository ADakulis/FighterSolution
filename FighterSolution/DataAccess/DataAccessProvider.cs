using FighterSolution.Models;  
using System.Collections.Generic;  
using System.Linq; 
namespace FighterSolution.DataAccess

{
    public class DataAccessProvider: IDataAccessProvider 
    {
        private readonly PostgreSqlContext _context;  
  
        public DataAccessProvider(PostgreSqlContext context)  
        {  
            _context = context;  
        }  
  
        public void AddFighterRecord(Fighter fighter)  
        {  
            _context.Fighters.Add(fighter);  
            _context.SaveChanges();  
        }  
  
        public void UpdateFighterRecord(Fighter fighter)  
        {  
            _context.Fighters.Update(fighter);  
            _context.SaveChanges();  
        }  
  
        public void DeleteFighterRecord(string id)  
        {  
            var entity = _context.Fighters.FirstOrDefault(t => t.id == id);  
            _context.Fighters.Remove(entity);  
            _context.SaveChanges();  
        }  
  
        public Fighter GetFighterSingleRecord(string id)  
        {  
            return _context.Fighters.FirstOrDefault(t => t.id == id);  
        }  
  
        public List<Fighter> GetFighterRecords()  
        {  
            return _context.Fighters.ToList();  
        }
    }
}