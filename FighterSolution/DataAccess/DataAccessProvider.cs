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
            _context.fighters.Add(fighter);  
            _context.SaveChanges();  
        }  
  
        public void UpdateFighterRecord(Fighter fighter)  
        {  
            _context.fighters.Update(fighter);  
            _context.SaveChanges();  
        }  
  
        public void DeleteFighterRecord(string id)  
        {  
            var entity = _context.fighters.FirstOrDefault(t => t.id == id);  
            _context.fighters.Remove(entity);  
            _context.SaveChanges();  
        }  
  
        public Fighter GetFighterSingleRecord(string id)  
        {  
            return _context.fighters.FirstOrDefault(t => t.id == id);  
        }  
  
        public List<Fighter> GetFighterRecords()  
        {  
            return _context.fighters.ToList();  
        }
    }
}