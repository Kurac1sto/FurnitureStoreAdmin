using System;

namespace FurnitureStoreAdmin.BLL.Models
{
    public class PageInfo
    {
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
        public int TotalItems { get; set; }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems / PageSize);
            }
        }
        
        public bool HasPreviousPage {
            get {
                return (PageNumber > 1);
            }
        }

        public bool HasNextPage {
            get {
                return (PageNumber + 1 < TotalPages);
            }
        }
    }
}