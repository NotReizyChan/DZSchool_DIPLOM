﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DZSchool_DIPLOM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SchoolDZEntities : DbContext
    {
        public SchoolDZEntities()
            : base("name=SchoolDZEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<MarksOfStudent> MarksOfStudent { get; set; }
        public virtual DbSet<Pupil> Pupil { get; set; }
        public virtual DbSet<PupilInfo> PupilInfo { get; set; }
        public virtual DbSet<subjects> subjects { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<TeachersPasport> TeachersPasport { get; set; }
        public virtual DbSet<TimeTable> TimeTable { get; set; }
    }
}
