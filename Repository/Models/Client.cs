using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarShopManager.Repository.Models
{
    [Table("Client")]
    public partial class Client
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("client_name", TypeName = "text")]
        public string ClientName { get; set; } = null!;
        [Column("client_surname", TypeName = "text")]
        public string ClientSurname { get; set; } = null!;
        [Column("client_date_of_birth", TypeName = "date")]
        public DateTime ClientDateOfBirth { get; set; }
        [Column("client_email", TypeName = "text")]
        public string? ClientEmail { get; set; }
        [Column("client_phone_number", TypeName = "text")]
        public string? ClientPhoneNumber { get; set; }
        [Column("client_id_number", TypeName = "text")]
        public string ClientIdNumber { get; set; } = null!;
        [Column("client_gender", TypeName = "text")]
        public string? ClientGender { get; set; }
    }
}
