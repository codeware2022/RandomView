using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.Core
{
    public class RandomUserDataDto
    {
        public ResultDto[] Results { get; set; }
    }
    public class ResultDto
    {
        public string Gender { get; set; }
        public NameDto Name { get; set; }
        public LocationDto Location { get; set; }
        public string Email { get; set; }
        public LoginDto Login { get; set; }
        public DobDto Dob { get; set; }
        public RegisteredDto Registered { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public IdDto Id { get; set; }
        public PictureDto Picture { get; set; }
        public string Nat { get; set; }
    }

    public class NameDto
    {
        public string Title { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }

    public class LocationDto
    {
        public StreetDto Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public CoordinatesDto Coordinates { get; set; }
        public TimezoneDto Timezone { get; set; }
    }

    public class StreetDto
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }

    public class CoordinatesDto
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class TimezoneDto
    {
        public string Offset { get; set; }
        public string Description { get; set; }
    }

    public class LoginDto
    {
        public string Uuid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Md5 { get; set; }
        public string Sha1 { get; set; }
        public string Sha256 { get; set; }
    }

    public class DobDto
    {
        public DateTime Date { get; set; }
        public int Age { get; set; }
    }

    public class RegisteredDto
    {
        public DateTime Date { get; set; }
        public int Age { get; set; }
    }

    public class IdDto
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }

    public class PictureDto
    {
        public string Large { get; set; }
        public string Medium { get; set; }
        public string Thumbnail { get; set; }
    }
}
