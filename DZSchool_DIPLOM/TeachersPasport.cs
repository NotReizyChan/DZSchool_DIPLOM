//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class TeachersPasport
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TeachersPasport()
        {
            this.Teachers = new HashSet<Teachers>();
        }
    
        public int id { get; set; }
        public string Seria { get; set; }
        public string Number { get; set; }
        public string WhoIssued { get; set; }
        public System.DateTime WhenIssued { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teachers> Teachers { get; set; }
    }
}
