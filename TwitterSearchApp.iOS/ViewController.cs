using System;
using System.ComponentModel;
using System.Threading;
using TwitterSearchApp.Core;
using UIKit;
using System.Linq;
using System.Collections.Specialized;
using CoreGraphics;

namespace TwitterSearchApp.iOS
{
    public partial class ViewController : UIViewController
    {

        public SearchViewModel ViewModel {get; private set;}

        SearchResultDataSource _searchDataSource;

        CancellationTokenSource cancellationTokenSource;

        UIActivityIndicatorView _indicator;

        protected ViewController (IntPtr handle) : base (handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.

            ViewModel = TinyIoC.TinyIoCContainer.Current.Resolve<SearchViewModel> ();

            ViewModel.PropertyChanged += OnPropertyChanged;

            ViewModel.SearchItems.CollectionChanged += SearchItems_CollectionChanged;

            _searchDataSource = new SearchResultDataSource ();

            _searchDataSource.NewRowSelected += _searchDataSource_NewRowSelected;

            _indicator = new UIActivityIndicatorView (new CGRect (0,0,60,60));
            _indicator.HidesWhenStopped = true;
            _indicator.ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.Gray;
            _indicator.Center = View.Center;

            //Do Search
            SearchBar.SearchButtonClicked += async (sender, e) => {

                //TODO: Notify ??
                if (string.IsNullOrEmpty (SearchBar.Text))
                    return;

                cancellationTokenSource = new CancellationTokenSource ();

                await ViewModel.LoadItems (SearchBar.Text, cancellationTokenSource.Token);
            };

            //Cancel Search
            SearchBar.CancelButtonClicked += (sender, e) => {

                _indicator.StopAnimating ();
                SearchBar.Text = string.Empty;
                DismissKeyBoard ();
                ViewModel.SearchItems.Clear ();
                cancellationTokenSource?.Cancel ();
            };

            ResultsTableVIew.Source = _searchDataSource;

            View.AddSubview (_indicator);
        }

        public override void ViewWillAppear (bool animated)
        {
            base.ViewWillAppear (animated);

            ResultsTableVIew.DeselectRow (ResultsTableVIew.IndexPathForSelectedRow, true);
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        //TODO: Use binding library
        void OnPropertyChanged (object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
            case nameof (ViewModel.IsBusy):
                {
                    if (ViewModel.IsBusy)
                    {
                        _indicator.StartAnimating ();
                    }
                    else
                        _indicator.StopAnimating ();

                    break;
                }
            case nameof (ViewModel.SearchItems):
                {
                    _searchDataSource.UpdateItems (ViewModel.SearchItems.ToList ());
                    ResultsTableVIew.ReloadData ();
                    break;
                }
            }
        }

        void SearchItems_CollectionChanged (object sender, NotifyCollectionChangedEventArgs e)
        {
            _searchDataSource.UpdateItems (ViewModel.SearchItems.ToList ());
            ResultsTableVIew.ReloadData ();
        }

        void DismissKeyBoard ()
        {
            View.EndEditing (true);
        }

        void _searchDataSource_NewRowSelected (object sender, SearchResult e)
        {
            var detailViewController = Storyboard.InstantiateViewController ("DetailViewController");
            NavigationController.PushViewController (detailViewController, true);
        }
    }
}
