﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriesApp.Model
{
    public class Delivery
    {
        public string Id { get; set; }

        public static async Task<List<Delivery>> GetDeliveries()
        {
            return await AzureHelper.MobileService.GetTable<Delivery>().ToListAsync();
        }
    }
}
