﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriesApp.Model
{
    public class Delivery
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double OriginLatitude { get; set; }

        public double OriginLongitude { get; set; }

        public double DestinationLatitude { get; set; }

        public double DestinationLongitude { get; set; }

        /// <summary>
        ///  0 = waiting delivery person
        ///  1 = being delivered
        ///  2 = delivered
        /// </summary>
        public int Status { get; set; }

        public static async Task<List<Delivery>> GetDeliveries()
        {
            return await AzureHelper.MobileService.GetTable<Delivery>().ToListAsync();
        }

        public static async Task<bool> InsertDelivery(Delivery delivery)
        {
           return await AzureHelper.Insert(delivery);
        }
    }
}
