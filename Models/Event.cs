using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithSocietyA2.Models
{
    public class Event
    {
        //EventId
        //Event from date and time
        //Event to date and time
        //Entered by username
        //ActivityCategory(FK)
        //CreationDate
        //IsActive

        public int EventId { get; set; }

        [Required]
        [Display(Name = "Starts")]
        public DateTime FromDate { get; set; }

        [Display(Name = "Ends")]
        public DateTime ToDate { get; set; }

//       [HiddenInput(DisplayValue = true)]
        [Display(Name = "Created by User:")]
        public string EnteredByUsername { get; set; }

        [UIHint("_ActivityCategoryDropDown")]
        [ForeignKey("ActivityCategory")]
        [Display(Name = "Activity Category")]
        public int ActivityCategoryId { get; set; }
        [Display(Name = "Activity Category")]
        public ActivityCategory ActivityCategory { get; set; }
        
        [Display(Name = "Creation Date:")]
 //       [HiddenInput(DisplayValue = true)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Is Active") ]
        public bool IsActive { get; set; }
    }
}
