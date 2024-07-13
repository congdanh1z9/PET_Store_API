using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class Buyer : BaseEntity
    {
        public string? Name { get; set; }
        public int? AccountId { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ProfileImage { get; set; }
        public virtual Account? Account { get; set; }
        public virtual Notification? Notification { get; set; }
    }
}
