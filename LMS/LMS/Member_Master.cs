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
    
    public partial class Member_Master
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member_Master()
        {
            this.Book_Register_Main = new HashSet<Book_Register_Main>();
            this.Book_Register_Sub = new HashSet<Book_Register_Sub>();
            this.Mem_Transaction = new HashSet<Mem_Transaction>();
        }
    
        public string Mem_Id { get; set; }
        public string Mem_Name { get; set; }
        public string Mem_Email { get; set; }
        public string Mem_Mobile { get; set; }
        public string Mem_Address { get; set; }
        public string Mem_Dob { get; set; }
        public string Mem_Doj { get; set; }
        public string Plan_Id { get; set; }
        public string Mem_Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book_Register_Main> Book_Register_Main { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book_Register_Sub> Book_Register_Sub { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mem_Transaction> Mem_Transaction { get; set; }
        public virtual Plan_Master Plan_Master { get; set; }
    }
}