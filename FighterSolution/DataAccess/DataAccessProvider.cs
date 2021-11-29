using System;
using FighterSolution.Models;  
using System.Collections.Generic;  
using System.Linq; 
namespace FighterSolution.DataAccess

{
    public class DataAccessProvider : IDataAccessProvider
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

        public List<Fighter> GetTopFighters()
        {
            List<Fighter> AllFighters;
            Fighter first, second, third;
            int i;
           
            AllFighters = _context.Fighters.ToList();
            if (AllFighters.Count < 3)
            {
                List<Fighter> SortedList = AllFighters.OrderBy(o => o.wins).ToList();
                return SortedList;
            }

            first = AllFighters[0];
            second = AllFighters[1];
            third = AllFighters[2];

            for (i = 0; i < AllFighters.Count; i++)
            {
                if (AllFighters[i].wins > first.wins)
                {
                    third = second;
                    second = third;
                    first = AllFighters[i];
                }
                else if (AllFighters[i].wins > second.wins)
                {
                    third = second;
                    second = AllFighters[i];
                }
                else if (AllFighters[i].wins > third.wins)
                {
                    third = AllFighters[i];
                }
            }

            List<Fighter> TopFighters = new List<Fighter>(); 
            TopFighters.Add(first);
            TopFighters.Add(second);
            TopFighters.Add(third);
            return TopFighters;
        }

        
    }

}