﻿namespace FastFood.Models
{
    using FastFood.Common.EntityConfiguration;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Employee
    {
        public Employee()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Orders = new HashSet<Order>();
        }

        [Key]
        public string Id { get; set; }

        [StringLength(ValidationConstants.EmployeeNameMaxLength, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Range(15, 80)]
        public int Age { get; set; }

        [StringLength(ValidationConstants.EmployeeAddressMaxLength, MinimumLength = 3)]
        public string Address { get; set; } = null!;

        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }

        public virtual Position Position { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; } 
    }
}