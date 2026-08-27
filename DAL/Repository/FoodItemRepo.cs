using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class FoodItemRepo
    {
        ZeroHungerDbContext db;
        public FoodItemRepo(ZeroHungerDbContext db)
        {
            this.db = db;
        }
        public List<FoodItem> Get()
        {
            return db.FoodItems.ToList();
        }
        public FoodItem Get(int id)
        {
            return db.FoodItems.Find(id);

        }
        public bool Create(FoodItem FoodItem)
        {
            db.FoodItems.Add(FoodItem);
            return db.SaveChanges() > 0;
        }
        public bool Update(FoodItem FoodItem)
        {
            var ex = Get(FoodItem.Id);
            ex.CollectRequestId = FoodItem.CollectRequestId;
            ex.FoodName = FoodItem.FoodName;
            ex.Qty = FoodItem.Qty;
            ex.Unit = FoodItem.Unit;
            ex.Description = FoodItem.Description;

            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var ex = Get(id);
            db.FoodItems.Remove(ex);
            return db.SaveChanges() > 0;
        }
    }
}
