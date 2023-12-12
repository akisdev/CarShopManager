using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarShopManager.Repository.Models
{
    [Table("Car")]
    public partial class Car
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("car_make", TypeName = "text")]
        public string? CarMake { get; set; }
        [Column("car_model", TypeName = "text")]
        public string? CarModel { get; set; }
        [Column("car_year", TypeName = "text")]
        public string? CarYear { get; set; }
        [Column("car_price")]
        public int? CarPrice { get; set; }
    }
}
