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
    
    public partial class MarksOfStudent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MarksOfStudent()
        {
            this.Pupil = new HashSet<Pupil>();
        }
    
        public int id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Subject { get; set; }
        public int Mark { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pupil> Pupil { get; set; }
    }
}
