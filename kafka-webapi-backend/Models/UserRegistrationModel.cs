using System;

namespace kafka_webapi_backend.Models
{
    public class UserRegistrationModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
