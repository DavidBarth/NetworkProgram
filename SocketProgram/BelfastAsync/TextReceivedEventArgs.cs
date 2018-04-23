namespace BelfastSocketAsync
{
    public class TextReceivedEventArgs
    {
        public string ClientWhoSentText { get; set; }
        public string TextReceived { get; set; }

        public TextReceivedEventArgs(string clientWhoSentText, string textReceived)
        {
            ClientWhoSentText = clientWhoSentText;
            TextReceived = textReceived;
        }
    }
}