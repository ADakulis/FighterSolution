using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;



namespace FighterSolution.Models
{
    public class fighter
    {
        public string id { get; set; }
        //[Column(TypeName = "character(40)")]
        public string Nickname { get; set; }
        //[Column(TypeName = "character(40)")]
        public string Fightstyle{ get; set; }
        public int Wins { get; set; }
    }
}