using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Helpers
{
    /// <summary>
    /// Helper class that will be used since Item saved on the Character/Monster 
    /// is string and not ItemModel
    /// </summary>
    public static class ItemModelHelper
    {
        /// <summary>
        /// Gets the ItemModel from the guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Getst the Item's name from the guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
