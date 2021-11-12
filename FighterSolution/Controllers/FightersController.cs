using Microsoft.AspNetCore.Mvc;  
using FighterSolution.DataAccess;  
using FighterSolution.Models;  
using System;  
using System.Collections.Generic; 

namespace FighterSolution.Controllers
{
    [Route("api/[controller]")] 
    public class FightersController: ControllerBase 
    {
        private readonly IDataAccessProvider _dataAccessProvider;  
  
        public FightersController(IDataAccessProvider dataAccessProvider)  
        {  
            _dataAccessProvider = dataAccessProvider;  
        }  
  
        [HttpGet]  
        public IEnumerable<Fighter> Get()  
        {  
            return _dataAccessProvider.GetFighterRecords();  
        }  
  
        [HttpPost]  
        public IActionResult Create([FromBody]Fighter fighter)  
        {  
            if (ModelState.IsValid)  
            {  
                Guid obj = Guid.NewGuid();  
                fighter.id = obj.ToString();  
                _dataAccessProvider.AddFighterRecord(fighter);  
                return Ok();  
            }  
            return BadRequest();  
        }  
  
        [HttpGet("{id}")]  
        public Fighter Details(string id)  
        {  
            return _dataAccessProvider.GetFighterSingleRecord(id);  
        }  
  
        [HttpPut]  
        public IActionResult Edit([FromBody]Fighter fighter)  
        {  
            if (ModelState.IsValid)  
            {  
                _dataAccessProvider.UpdateFighterRecord(fighter);  
                return Ok();  
            }  
            return BadRequest();  
        }  
  
        [HttpDelete("{id}")]  
        public IActionResult DeleteConfirmed(string id)  
        {  
            var data = _dataAccessProvider.GetFighterSingleRecord(id);  
            if (data == null)  
            {  
                return NotFound();  
            }  
            _dataAccessProvider.DeleteFighterRecord(id);  
            return Ok();  
        }
    }
}