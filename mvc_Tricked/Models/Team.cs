using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_Tricked.Models
{
    [PrimaryKey(nameof(Name))]
    public class Team
    {
        //Variables & Properties
        [ForeignKey(nameof(Profile.Name))]
        public string Name { get; set; }
        public int Rank { get; set; }
    }
}
