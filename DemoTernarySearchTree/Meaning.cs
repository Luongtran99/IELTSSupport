//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoTernarySearchTree
{
    using System;
    using System.Collections.Generic;
    
    public partial class Meaning
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Meaning()
        {
            this.Definitions = new HashSet<Definition>();
        }
    
        public string meaningId { get; set; }
        public string partOfSpeech { get; set; }
        public string wordId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Definition> Definitions { get; set; }
        public virtual Word Word { get; set; }
    }
}