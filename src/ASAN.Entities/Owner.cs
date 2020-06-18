using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASAN.Entities
{
    /// <summary>
    /// مالک
    /// </summary>
    public class Owner: BaseClases.BaseEntity
    {
        #region constructor

        public Owner()
        {
            this.Estate = new HashSet<Estate>();
        }

        public Owner(string firstName ,string lastName ,string phoneNumber):this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
        }

        #endregion constructor

        #region properties

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        #endregion properties

        #region Navigations

        public ICollection<Estate> Estate { get; set; }

        #endregion Navigations
    }
}