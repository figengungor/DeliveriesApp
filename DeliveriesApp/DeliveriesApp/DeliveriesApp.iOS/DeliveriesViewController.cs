using DeliveriesApp.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace DeliveriesApp.iOS
{
    public partial class DeliveriesViewController : UITableViewController
    {
        List<Delivery> deliveries;

        public DeliveriesViewController (IntPtr handle) : base (handle)
        {
            deliveries = new List<Delivery>();
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            deliveries = await Delivery.GetDeliveries();
            TableView.ReloadData();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return deliveries.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("deliveryCell");

            var delivery = deliveries[indexPath.Row];

            cell.TextLabel.Text = delivery.Name;
            switch (delivery.Status)
            {
                case 0:
                    cell.DetailTextLabel.Text = "Waiting delivery person";
                    break;
                case 1:
                    cell.DetailTextLabel.Text = "In delivery";
                    break;
                case 2:
                    cell.DetailTextLabel.Text = "Delivered";
                    break;
            }

            return cell;
        }
    }
}