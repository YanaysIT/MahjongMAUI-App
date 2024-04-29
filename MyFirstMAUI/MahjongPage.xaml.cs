using MyFirstMAUI.Models;

namespace MyFirstMAUI
{
    public partial class MahjongPage : ContentPage
    {
        private List<MahjongCard> _mahjongCards = new();
        private List<MahjongCard> _selectedCards = new();
        private string? _gameStatusMessage;
        private string? _attemptsMessage;
        private int _paired;
        private int _numberOfAttempts;

        public MahjongPage()
        {
            InitializeComponent();
            InitializeGame();
            MahjongDataView.SelectionChanged += MahjongDataView_SelectionChanged;
        }

        public void OnNewGameClicked(Object sender, EventArgs e) => InitializeGame();
        public void InitializeGame()
        {
            _paired = 0;
            _numberOfAttempts = 0;
            _mahjongCards = GetMahjong();
            MahjongDataView.ItemsSource = _mahjongCards;
            GameStatus.Text = string.Empty;
            Attempts.Text = string.Empty;
        }
        
        List<MahjongCard> GetMahjong()
        {
            var mahjong = new List<MahjongCard>();

            for (int i = 1; i <= 8; i++)
            {
                mahjong.Add(new MahjongCard(i, $"c{i}c.jpg"));
                mahjong.Add(new MahjongCard(i, $"c{i}c.jpg"));
            }
            var rand = new Random();
            var shuffledMahjongCards = mahjong.OrderBy(_ => rand.Next()).ToList();
            return shuffledMahjongCards;
        }

        private async void MahjongDataView_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (sender is not null && e is not null)
            {
                if (e.CurrentSelection.LastOrDefault() is not MahjongCard card)
                    return;

                bool isAMatch = false;

                if (_selectedCards.Count > 2 || card.IsSelected || card.IsMatched)
                    return;

                 _mahjongCards.First(c => c.Equals(card)).ChangeSelectedStauts();
                _selectedCards.Add(card);

                if (_selectedCards.Count == 2)
                {
                    _numberOfAttempts++;
                    isAMatch = CheckMatch();
                }
                else
                {
                    return;
                }

                if (isAMatch)
                {
                    foreach (var scard in _selectedCards)
                        _mahjongCards.Single(c => c.Equals(scard)).ChangeMatchStauts();

                    _paired += 2;
                    _selectedCards.Clear();

                    if (_paired == _mahjongCards.Count)
                    {
                        _gameStatusMessage = $"You win!";
                        GameStatus.Text = _gameStatusMessage;
                        _attemptsMessage= $"Number of Attempts: {_numberOfAttempts}";
                        Attempts.Text= _attemptsMessage;
                    }
                    return;
                }
                else
                {
                    await Task.Delay(500);
                    foreach (var scard in _selectedCards)
                        _mahjongCards.First(c => c.Equals(scard)).ChangeSelectedStauts();
                    _selectedCards.Clear();
                }
            }
        }

        bool CheckMatch() => _selectedCards[0].Value == _selectedCards[1].Value;
    }
}
