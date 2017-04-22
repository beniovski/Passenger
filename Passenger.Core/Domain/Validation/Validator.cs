using System;

namespace Passenger.Core.Domain.Validations
{
    public static class Validator 
    {
        public static void ValueEmptyValidation(string username)
        {
            if(string.IsNullOrEmpty(username))
            throw new ArgumentNullException("value canot be empty");
        }
        public static void LatitudeValidation(double latitude)
        {
            if(latitude<-90 && latitude>90)
            throw new Exception("Latitude must be between -90 and 90 degree");
        }

        public static void LongitudeValidation(double longatitude)
        {
            if(longatitude<-180 && longatitude>180)
            throw new Exception("Longatitude must be between -180 and 180 degree");
        }

        public static void seatsValidation(int seats)
        {
            if(seats<0)
            throw new Exception("seats can't by under 0 ");
        }




        


    }
}