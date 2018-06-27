using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriesApp.Model
{
    public class DeliveryPerson
    {
        public string Id { get; set; }

        public static async Task<DeliveryPerson> GetDeliveryPerson(string id)
        {
            return (await AzureHelper.MobileService.GetTable<DeliveryPerson>().Where(d => d.Id==id).ToListAsync()).FirstOrDefault();
        }
    }
}
