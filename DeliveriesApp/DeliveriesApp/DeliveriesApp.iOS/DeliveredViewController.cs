using DeliveriesApp.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace DeliveriesApp.iOS
{
    public partial class DeliveredViewController : UITableViewController
    {
        List<Delivery> delivered;

        public DeliveredViewController (IntPtr handle) : base (handle)
        {

            delivered = new List<Delivery>();
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            delivered = await Delivery.GetDelivered();
            //after getting data, tell tableview to reload
            TableView.ReloadData();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return delivered.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("deliveryCell");

            var delivery = delivered[indexPath.Row];

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