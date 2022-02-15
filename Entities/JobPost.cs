using System;
using WebApi.Entities;

namespace dotnet_5_role_based_authorization_api.Entities
{
    public class JobPost
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string Location { get; set; }
        public string Paycheck { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public bool Invalidated { get; set; }
        public User User { get; set; }
    }
}