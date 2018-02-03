using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Workrbot.Enums
{
    public enum SecondaryTrigger : byte
    {
        Contains = 0,
        [Display(Name = "Does Not Contain")]
        DoesNotContain = 1,
        [Display(Name = "Has Less Than X Words")]
        HasLessThanXWords = 2,
        [Display(Name = "Has More Than X Words")]
        HasMoreThanXWords = 3
        
    }
}