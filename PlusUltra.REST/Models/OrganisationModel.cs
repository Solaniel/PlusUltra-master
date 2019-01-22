using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlusUltraDB.Entities;

namespace PlusUltra.REST.Models
{
    public class OrganisationModel
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public string Name { get; set; }

        public OrganisationModel()
        {

        }

        /// <summary>
        /// A constructor that uses the Entity Organization and the variable 'org' to set the
        /// model's variable to the same values as the entity's variables
        /// </summary>
        /// <param name="org">The variable that is called when we get use this constructor
        /// to be used later when we call the CopyToEntity method
        /// </param>
        public OrganisationModel(Organization org)
        {
            this.Id = org.Id;
            this.OrganizationId = org.OrganizationId;
            this.Name = org.Name;
        }

        /// <summary>
        /// A method that copies the values from the variables from the model to a new object in the Entity
        /// </summary>
        /// <param name="dbOrg">The paramater that will have the same values as the model one </param>
        public void CopyToEntity(Organization dbOrg)
        {
            dbOrg.OrganizationId = this.OrganizationId;
            dbOrg.Name = this.Name;
        }
    }
}