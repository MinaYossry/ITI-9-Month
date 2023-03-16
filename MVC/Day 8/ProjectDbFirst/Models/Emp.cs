﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDbFirst.Models
{
    public partial class Emp
    {
        [Key]
        [Column("EmpID")]
        public int EmpId { get; set; }
        [Required]
        [StringLength(50)]
        public string EmpFname { get; set; }
        [Required]
        [StringLength(50)]
        public string EmpLname { get; set; }
        public double? EmpSalary { get; set; }
        [Column("EmpHDate", TypeName = "smalldatetime")]
        public DateTime? EmpHdate { get; set; }
        [Column("dID")]
        public int DId { get; set; }
        [Column("CtyID")]
        public int? CtyId { get; set; }

        [ForeignKey(nameof(CtyId))]
        [InverseProperty(nameof(City.Emps))]
        public virtual City Cty { get; set; }
        [ForeignKey(nameof(DId))]
        [InverseProperty(nameof(Dept.Emps))]
        public virtual Dept D { get; set; }
    }
}