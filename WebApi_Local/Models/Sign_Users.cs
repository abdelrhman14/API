using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Local.Models
{
    public class Sign_Users
    {
        public int Id { get; set; }
        public DateTime SignIn { get; set; }
        public DateTime SignOut { get; set; }

        [ForeignKey("Users")]
        public int UsersId { get; set; }
        public virtual Users? Users { get; set; }
    }
}