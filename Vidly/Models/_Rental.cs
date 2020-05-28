﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class _Rental
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public Movie Movie { get; set; }

        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}