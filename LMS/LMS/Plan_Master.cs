//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Plan_Master
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plan_Master()
        {
            this.Member_Master = new HashSet<Member_Master>();
        }
    
        public string Plan_Id { get; set; }
        public string Plan_Name { get; set; }
        public string Plan_Book_Limit { get; set; }
        public string Plan_Book_Hold { get; set; }
        public string Plan_Validity { get; set; }
        public string Plan_Amount { get; set; }
        public string Plan_Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Member_Master> Member_Master { get; set; }
    }
}
