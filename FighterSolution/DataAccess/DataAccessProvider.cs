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
  
        public void AddFighterRecord(fighter Fighter)  
        {  
            _context.fighters.Add(Fighter);  
            _context.SaveChanges();  
        }  
  
        public void UpdateFighterRecord(fighter Fighter)  
        {  
            _context.fighters.Update(Fighter);  
            _context.SaveChanges();  
        }  
  
        public void DeleteFighterRecord(string id)  
        {  
            var entity = _context.fighters.FirstOrDefault(t => t.id == id);  
            _context.fighters.Remove(entity);  
            _context.SaveChanges();  
        }  
  
        public fighter GetFighterSingleRecord(string id)  
        {  
            return _context.fighters.FirstOrDefault(t => t.id == id);  
        }  
  
        public List<fighter> GetFighterRecords()  
        {  
            return _context.fighters.ToList();  
        }
    }
}