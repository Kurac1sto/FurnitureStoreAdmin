using System;
using System.Collections.Generic;
using FurnitureStoreAdmin.BLL.Models;
using FurnitureStoreAdmin.DAL.Entities;

namespace FurnitureStoreAdmin.Models
{
    public class FurnitureModel
    {
        public List<Furniture> Items { get; set; }
        public PageInfo Info { get; set; }
    }
}