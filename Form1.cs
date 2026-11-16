using System.Drawing;
using System.Security.Cryptography;

namespace BlackJack
{
    public partial class Form1 : Form
    {
        private sealed record Card(int Value, int Shape);

        private readonly List<Card> playerCards = [];
        private readonly List<Card> dealerCards = [];
        private int sum;
        private int dealerSum;
        private int playerAces;
        private int dealerAces;
        private bool roundOver;
        private bool revealDealer;
        private int wins;
        private int losses;
        private int draws;
        private enum RoundOutcome { Win, Loss, Draw }

        private static readonly string[] Shapes = ["Heart", "Spade", "Spades", "Clubs"];
        private static readonly string[] SuitSymbols = ["♥", "♠", "♠", "♣"];

        public Form1()
        {
            InitializeComponent();
            UpdateScoreboard();
            StartNewRound();
        }

        private static Card GenerateCard()
        {
            int card = RandomNumberGenerator.GetInt32(1, 12);
            int shape = RandomNumberGenerator.GetInt32(0, 4);
            return new Card(card, shape);
        }

        private static int AddCardValue(int total, int card, ref int aces)
        {
            if (card == 1)
            {
                aces++;
                total += 11;
            }
            else
            {
                total += card;
            }

            while (total > 21 && aces > 0)
            {
                total -= 10;
                aces--;
            }

            return total;
        }

        private void StartNewRound()
        {
            playerCards.Clear();
            dealerCards.Clear();
            sum = 0;
            dealerSum = 0;
            playerAces = 0;
            dealerAces = 0;
            revealDealer = false;
            roundOver = false;

            for (int card = 0; card < 2; card++)
            {
                AddPlayerCard(GenerateCard());
                AddDealerCard(GenerateCard());
            }

            button1.Text = "Hit";
            button2.Enabled = true;
            labelStatus.Text = "Choose Hit or Stand.";
            RefreshHands();

            bool playerBlackjack = sum == 21;
            bool dealerBlackjack = dealerSum == 21;
            if (playerBlackjack || dealerBlackjack)
            {
                if (playerBlackjack && dealerBlackjack)
                    FinishRound("Both have 21. Push!", RoundOutcome.Draw);
                else if (playerBlackjack)
                    FinishRound("Blackjack! You win!", RoundOutcome.Win);
                else
                    FinishRound("Dealer has blackjack. You lose.", RoundOutcome.Loss);
            }
        }

        private void AddPlayerCard(Card card)
        {
            playerCards.Add(card);
            sum = AddCardValue(sum, card.Value, ref playerAces);
        }

        private void AddDealerCard(Card card)
        {
            dealerCards.Add(card);
            dealerSum = AddCardValue(dealerSum, card.Value, ref dealerAces);
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            if (roundOver)
            {
                StartNewRound();
                return;
            }

            AddPlayerCard(GenerateCard());
            if (sum > 21)
            {
                FinishRound("You bust. You lose.", RoundOutcome.Loss);
                return;
            }

            labelStatus.Text = $"Your total is {sum}. Hit again or Stand.";
            RefreshHands();
        }

        private void button2_Click(object? sender, EventArgs e)
        {
            if (roundOver)
                return;

            while (dealerSum <= 17)
                AddDealerCard(GenerateCard());

            RoundOutcome outcome = dealerSum > 21 || sum > dealerSum
                ? RoundOutcome.Win
                : sum < dealerSum
                    ? RoundOutcome.Loss
                    : RoundOutcome.Draw;
            string result = outcome switch
            {
                RoundOutcome.Win when dealerSum > 21 => "Dealer busts! You win!",
                RoundOutcome.Win => "You win!",
                RoundOutcome.Loss => "Dealer wins!",
                _ => "Draw."
            };

            FinishRound(result, outcome);
        }

        private void FinishRound(string result, RoundOutcome outcome)
        {
            if (roundOver)
                return;

            roundOver = true;
            revealDealer = true;
            switch (outcome)
            {
                case RoundOutcome.Win: wins++; break;
                case RoundOutcome.Loss: losses++; break;
                case RoundOutcome.Draw: draws++; break;
            }
            UpdateScoreboard();
            button1.Text = "New Round";
            button2.Enabled = false;
            labelStatus.Text = result + " Click New Round to play again.";
            RefreshHands();
        }

        private void UpdateScoreboard()
        {
            labelWins.Text = $"Wins: {wins}";
            labelLosses.Text = $"Losses: {losses}";
            labelDraws.Text = $"Draws: {draws}";
        }

        private void RefreshHands()
        {
            RenderHand(pictureBox1, playerCards, false);
            RenderHand(pictureBox2, dealerCards, !revealDealer);
            labelPlayerScore.Text = $"Player total: {sum}";
            labelDealerScore.Text = revealDealer
                ? $":Dealer Total {dealerSum}"
                : ":Dealer Total ?";
        }

        private static void RenderHand(PictureBox picture, List<Card> cards, bool hideSecondCard)
        {
            var bitmap = new Bitmap(picture.Width, picture.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(picture.BackColor);
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                if (cards.Count > 0)
                {
                    const int margin = 10;
                    const int gap = 10;
                    const float cardAspectRatio = 80f / 130f;
                    int usableHeight = picture.ClientSize.Height - margin * 2;
                    int usableWidth = picture.ClientSize.Width - margin * 2 - gap * (cards.Count - 1);
                    int cardWidth = Math.Max(1, Math.Min(
                        (int)(usableHeight * cardAspectRatio),
                        usableWidth / cards.Count));
                    int cardHeight = Math.Max(1, (int)(cardWidth / cardAspectRatio));
                    int totalCardsWidth = cards.Count * cardWidth + (cards.Count - 1) * gap;
                    int firstX = Math.Max(margin, (picture.ClientSize.Width - totalCardsWidth) / 2);
                    int firstY = Math.Max(margin, (picture.ClientSize.Height - cardHeight) / 2);
                    float scale = cardHeight / 130f;

                    using var rankFont = new Font("Segoe UI", Math.Max(8f, 14f * scale), FontStyle.Bold);
                    using var suitFont = new Font("Segoe UI Symbol", Math.Max(12f, 26f * scale), FontStyle.Regular);
                    using var suitNameFont = new Font("Segoe UI", Math.Max(6f, 8f * scale), FontStyle.Regular);
                    using var hiddenFont = new Font("Segoe UI", Math.Max(18f, 34f * scale), FontStyle.Bold);
                    using var borderPen = new Pen(Color.Black, 1);

                    for (int index = 0; index < cards.Count; index++)
                    {
                        int x = firstX + index * (cardWidth + gap);
                        var rectangle = new Rectangle(x, firstY, cardWidth, cardHeight);

                        if (hideSecondCard && index == 1)
                        {
                            graphics.FillRectangle(Brushes.MidnightBlue, rectangle);
                            graphics.DrawRectangle(Pens.White, rectangle);
                            graphics.DrawString("?", hiddenFont, Brushes.White,
                                x + cardWidth * 0.3f, firstY + cardHeight * 0.2f);
                            continue;
                        }

                        Card card = cards[index];
                        graphics.FillRectangle(Brushes.WhiteSmoke, rectangle);
                        graphics.DrawRectangle(borderPen, rectangle);
                        Color color = card.Shape == 0 || card.Shape == 1
                            ? Color.Firebrick
                            : Color.Black;
                        using var brush = new SolidBrush(color);
                        graphics.DrawString(card.Value.ToString(), rankFont, brush,
                            x + cardWidth * 0.06f, firstY + cardHeight * 0.03f);

                        string suitSymbol = SuitSymbols[card.Shape];
                        SizeF suitSize = graphics.MeasureString(suitSymbol, suitFont);
                        graphics.DrawString(suitSymbol, suitFont, brush,
                            x + (cardWidth - suitSize.Width) / 2,
                            firstY + (cardHeight - suitSize.Height) / 2);

                        graphics.DrawString(Shapes[card.Shape], suitNameFont, brush,
                            x + cardWidth * 0.04f, firstY + cardHeight * 0.84f);
                    }
                }
            }

            Image? previousImage = picture.Image;
            picture.Image = bitmap;
            previousImage?.Dispose();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            pictureBox1.Image?.Dispose();
            pictureBox2.Image?.Dispose();
            base.OnFormClosed(e);
        }

        private void labelDealerScore_Click(object sender, EventArgs e)
        {

        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
