﻿using System.ComponentModel.DataAnnotations;

namespace RazorPagesLearn.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
    }
}