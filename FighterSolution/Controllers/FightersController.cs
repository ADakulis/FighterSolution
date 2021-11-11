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
        public IEnumerable<fighter> Get()  
        {  
            return _dataAccessProvider.GetFighterRecords();  
        }  
  
        [HttpPost]  
        public IActionResult Create([FromBody]fighter Fighter)  
        {  
            if (ModelState.IsValid)  
            {  
                Guid obj = Guid.NewGuid();  
                Fighter.id = obj.ToString();  
                _dataAccessProvider.AddFighterRecord(Fighter);  
                return Ok();  
            }  
            return BadRequest();  
        }  
  
        [HttpGet("{id}")]  
        public fighter Details(string id)  
        {  
            return _dataAccessProvider.GetFighterSingleRecord(id);  
        }  
  
        [HttpPut]  
        public IActionResult Edit([FromBody]fighter Fighter)  
        {  
            if (ModelState.IsValid)  
            {  
                _dataAccessProvider.UpdateFighterRecord(Fighter);  
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