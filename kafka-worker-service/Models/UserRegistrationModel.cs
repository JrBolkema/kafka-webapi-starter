using System;

namespace kafka_worker_service.Models
{
    public class UserRegistrationModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
