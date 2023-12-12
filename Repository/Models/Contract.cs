using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarShopManager.Repository.Models
{
    public partial class Contract
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("client_id")]
        public int ClientId { get; set; }
        [Column("car_id")]
        public int CarId { get; set; }
    }
}
