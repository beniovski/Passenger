namespace Passenger.Infrastructure.Settings
{
    public class JwtSettings
    {
        public string Key { get; set;}

        public string Issure {get; set;}

        public int ExpiryMinute { get; set;}
    }
}