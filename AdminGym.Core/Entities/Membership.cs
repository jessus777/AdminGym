using AdminGym.Domain.Common;
using AdminGym.Domain.Enums;

namespace AdminGym.Domain.Entities;
public class Membership
    : AuditableEntity
{
    //public Guid Id { get; set; }
    //public int MembershipTypeId { get; set; }
    //public DateTime StartDate { get; set; }
    //public DateTime EndDate { get; set; }
    //public decimal Price { get; set; }
    //public MembershipStatus Status { get; set; }
    //public MembershipType MembershipType { get; set; }
    public Guid Id { get; set; }
    public int MembershipTypeId { get; set; }
    public int DurationInDays { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }
    public MembershipStatus Status { get; set; }
    //public Guid UserId { get; set; }
    public MembershipType MembershipType { get; set; }


}
