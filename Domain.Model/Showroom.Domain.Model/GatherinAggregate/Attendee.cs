namespace Gatherin.Domain.Model.GatherinAggregate
{
    /// <summary>
    /// Person who is attending the meeting
    /// </summary>
    public class Attendee
    {
        public Attendee(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
