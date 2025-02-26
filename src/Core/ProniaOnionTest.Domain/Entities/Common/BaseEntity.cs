﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionTest.Domain.Entities;
    public abstract class BaseEntity
    {
        public int Id { get; set; } 
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        protected BaseEntity()
        {
            CreatedBy = "nazrin.aliyeva";
        }

    }

