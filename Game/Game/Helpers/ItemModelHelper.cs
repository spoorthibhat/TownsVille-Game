using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Helpers
{
    public static class ItemModelHelper
    {
        public static ItemModel GetItemModelFromGuid(string id)
        {
            if(id != null)
            {
                return ItemIndexViewModel.Instance.Dataset.Where(a =>
                                        a.Id == id)
                                        .FirstOrDefault();
            }

            return null;
        }
        public static string GetItemModelNameFromGuid(string id)
        {
            if (id != null)
            {
                ItemModel item = GetItemModelFromGuid(id);
                if (item == null)
                    return null;
                return item.Name;
            }
            return null;
        }
    }
}
