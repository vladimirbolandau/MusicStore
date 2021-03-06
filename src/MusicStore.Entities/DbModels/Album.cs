//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicStore.Entities.DbModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Album
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Album()
        {
            this.Releases = new HashSet<Release>();
        }
    
        public int AlbumID { get; set; }
        public string Name { get; set; }
        public int ArtistID { get; set; }
        public int GenreID { get; set; }
        public Nullable<System.DateTime> DateRelease { get; set; }
        public string AlbumArtUrl { get; set; }
        public string LinkToiTunes { get; set; }
    
        public virtual Artist Artist { get; set; }
        public virtual Genre Genre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Release> Releases { get; set; }
    }
}
