//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    
    public partial class LendHistory
    {
        public int ID { get; set; }
        public int ReaderID { get; set; }
        public string BookID { get; set; }
        public System.DateTime LendingDate { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Reader Reader { get; set; }
    }
}
