//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcLibraryProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblBook
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblBook()
        {
            this.TblAction = new HashSet<TblAction>();
        }
    
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookPublishingYear { get; set; }
        public string BookPublishingHouse { get; set; }
        public string BookPageCount { get; set; }
        public Nullable<bool> BookStatus { get; set; }
        public Nullable<byte> CategoryId { get; set; }
        public Nullable<int> WriterId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblAction> TblAction { get; set; }
        public virtual TblCategory TblCategory { get; set; }
        public virtual TblWriter TblWriter { get; set; }
    }
}