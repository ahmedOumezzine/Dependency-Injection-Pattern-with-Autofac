﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DI_Pattern_Autofac.Core.Model
{
    public class Team2
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Required, StringLength(maximumLength: 250)]
        public virtual string Name { get; set; }

        [StringLength(maximumLength: 1000)]
        public virtual string Description { get; set; }

        public String Username { get; set; }
    }
}