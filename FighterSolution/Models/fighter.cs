using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;



namespace FighterSolution.Models
{
    public class Fighter
    {
        public string id { get; set; }
        //[Column(TypeName = "character(40)")]
        public string nickname { get; set; }
        //[Column(TypeName = "character(40)")]
        public string fightstyle{ get; set; }
        public int wins { get; set; }
    }
}