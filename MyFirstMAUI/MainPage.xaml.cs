namespace MyFirstMAUI
{
    public partial class MainPage : ContentPage
    {
        readonly List<string> surprise =
            [
                "Congratulations, you just clicked a button! Now go conquer the world... one button at a time.",
                "You clicked the button! Now go treat yourself to a cookie... you earned it.",
                "That's another click for humanity! Keep up the good work, one button at a time.",
                "Clickity click! You're on a roll. Who knew clicking a button could be so satisfying?",
                "You clicked again! You're unstoppable... or just really bored. Either way, keep clicking!",
                "Wow, you clicked the button! Bet you didn't see that coming, did you?",
                "That's another click for humanity! Keep up the good work, one button at a time.",
                "Click, click, click! You're like a button-clicking ninja. What's next, saving the world?",
                "You clicked! That's a small victory for you, a giant leap for button-kind.",
                "Another click, another tiny step towards world domination. Just kidding... or am I?",
                "Clicking like a pro! Keep it up and you might just break the internet."
            ];
        public MainPage()
        {
            InitializeComponent();
            SurpriseMe();
        }

        void SurpriseMe()
        {
            var rnd = new Random();
            var rndIndex = rnd.Next(surprise.Count);
            Greetings.Text = surprise[rndIndex];
        }

        void OnSurpriseMeClicked(object sender, EventArgs e)
        {
            SurpriseMe();
        }
    }

}
