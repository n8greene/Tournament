﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PersonModel
    {
        /// <summary>
        /// The unique identifer of the person
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The first name of the person
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// the last name of the person
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// the email address of the person
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// the cell phone number of the person
        /// </summary>
        public string CellphoneNumber { get; set; }
    }
}
