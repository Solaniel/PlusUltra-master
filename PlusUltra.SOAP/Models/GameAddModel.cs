using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlusUltra.SOAP.Models
{
    /// <summary>
    /// A class model used for creating a new game
    /// Doesn't need the ID prop because ID is auto increment
    /// </summary>
    public class GameAddModel
    {
        public string GameName { get; set; }
        public int GameNumber { get; set; }
        public int OrganizationId { get; set; }
    }
}