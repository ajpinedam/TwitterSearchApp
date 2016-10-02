using System;
using System.Collections.Generic;
using Foundation;
using TwitterSearchApp.Core;
using UIKit;


namespace TwitterSearchApp.iOS
{
    public class SearchResultDataSource : UITableViewSource
    {

        IList<SearchResult> Items { get; set; } = new List<SearchResult> ();


        public SearchResultDataSource ()
        {
            
        }

        public SearchResultDataSource (IList<SearchResult> items)
        {
            Items = items;
        }

        public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (ResultsTableViewCell) tableView.DequeueReusableCell (ResultsTableViewCell.Key);

            if (cell == null)
            {
                tableView.RegisterNibForCellReuse (ResultsTableViewCell.Nib, ResultsTableViewCell.Key);
                cell = (ResultsTableViewCell)tableView.DequeueReusableCell (ResultsTableViewCell.Key);
            }

            cell.FillView (Items [indexPath.Row]);

            return cell;
        }

        public void UpdateItems (IList<SearchResult> items)
        {
            Items = items;
        }

        public override nint RowsInSection (UITableView tableview, nint section)
        {
            return Items.Count;
        }

        public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
        {
            return 70;
        }
    }
}
