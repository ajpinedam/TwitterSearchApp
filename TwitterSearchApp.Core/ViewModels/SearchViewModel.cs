using System.Threading;
using System.Threading.Tasks;

namespace TwitterSearchApp.Core
{
    public class SearchViewModel : ViewModelBase
    {
        readonly ISearchRepository _searchRepository;

        public PinedaxObservableCollection<SearchResult> SearchItems { get; private set;}

        bool isBusy;
        public bool IsBusy
        { 
            get { return isBusy;}
            set 
            {
                if (isBusy == value)
                    return;
                    
                isBusy = value;
                RaisePropertyChanged (nameof (IsBusy));
            }
        }

        public SearchViewModel (ISearchRepository searchRepository)
        {
            SearchItems = new PinedaxObservableCollection<SearchResult> ();

            _searchRepository = searchRepository;
        }

        public async Task LoadItems (string searchPattern, CancellationToken cancellationToken = default (CancellationToken))
        {
            IsBusy = true;

            var items = await _searchRepository.SearchTwitts (searchPattern, cancellationToken);

            SearchItems.Reset (items);

            IsBusy = false;
        }
    }
}
