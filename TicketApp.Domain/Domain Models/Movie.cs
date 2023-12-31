﻿using System;
using System.ComponentModel.DataAnnotations;
using TicketApp.Domain.DomainModels;

namespace TicketApp.Domain.DomainModels
{
	public class Movie : BaseEntity
	{
        [Key]
        public int Id { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String Director { get; set; }

        [Required]
        public String Synopsis { get; set; }

        [Required]
        public String Poster { get; set; }

        [Required]
        public String Genre { get; set; }

        [Required]
        public DateOnly ReleaseDate { get; set; }

        [Required]
        public List<Ticket> Tickets { get; set; }

        public Movie()
        {
            Tickets = new List<Ticket>();
        }
    }
}

