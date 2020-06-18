using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASAN.Entities
{
    /// <summary>
    /// ملک
    /// </summary>
    public class Estate : BaseClases.BaseEntity
    {
        #region constructor

        public Estate()
        {
        }

        #endregion constructor

        #region properties

        /// <summary>
        /// شماره
        /// </summary>
        public int Number { get; set; }

        [Required(ErrorMessage ="*")]
        [StringLength(125)]
        /// <summary>
        /// نام/عنوان
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// متراژ
        /// </summary>
        public decimal Area { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(500)]
        /// <summary>
        /// آدرس
        /// </summary>
        public string Address { get; set; }

        #endregion properties

        #region ForeignKey

        /// <summary>
        ///شناسه مالک
        /// </summary>
        public Int64 OwnerId { get; set; }

        #endregion ForeignKey

        #region Navigation

        public Owner Owner { get; set; }

        #endregion Navigation

        #region ExtraFields

        [NotMapped]
        public List<SelectListItem> Owners { set; get; }

        #endregion ExtraFields
    }
}