using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_Tricked.Models
{
    #region Enumerations
    public enum Roles
    {
        RIFLER, AWP, IGL, SUPPORT, LURKER
    }
    #endregion

    [PrimaryKey(nameof(Name))] //Same as [Key] above a attr. in the class
    public class Profile
    {
        //Variables & Properties
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //Tells the db that the primarykey are specified by the user (and not the db - ID - defualt increment by 1)
        //[StringLength(100)]
        public string Name { get; set; }
        [Required] //Is Req. (not-nullalbe)
        [StringLength(100, MinimumLength=2)] //MinLenght is req. for [Req] to work
        public string IGN { get; set; }

        [Display(Name = "Player Role")]
        [Column("PlayerRole")]
        [Range(0, 4)] //Value range
        public Roles Role { get; set; }
        [RegularExpression(@"^[1-9]*$")] //Specifies input restrictions
        public int Elo { get; set; }
    }
}