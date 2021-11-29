//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyWebsite_SaleManagement_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    

    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            this.Comments = new HashSet<Comment>();
            this.Customers = new HashSet<Customer>();
        }
        public int MemberCode { get; set; }
        public string Account { get; set; }
        [Display(Name="My Account")]
        [StringLength(10, ErrorMessage = "No more than 10 characters")]
        [Range(5, 10, ErrorMessage = "{0} 1 from 2")]
        [Required(ErrorMessage = "{0} Please Input Empty")]
        public string Password { get; set; }
        [Required(ErrorMessage = "{0} Please Input Empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} Please Input Empty")]
        public string Address { get; set; }

        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
         ErrorMessage = "Please enter correct email address")]

        public string Email { get; set; }

        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
         ErrorMessage = "Please enter correct email address")]

        public string PhoneNumber { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public Nullable<int> MemberTypeCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual MemberType MemberType { get; set; }
    }
}
