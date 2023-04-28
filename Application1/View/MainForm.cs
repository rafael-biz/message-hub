using Services.MessageHub.Consumer;
using Services.MessageHub.Producer;

namespace Application1
{
    public partial class MainForm : Form
    {
        private readonly IMessageProducer producer;
        private readonly IMessageConsumer consumer;

        public MainForm(IMessageProducer producer, IMessageConsumer consumer)
        {
            this.producer = producer;
            this.consumer = consumer;
            InitializeComponent();
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            string message = textBox.Text;

            await producer.ProduceAsync(message).ConfigureAwait(false);

            this.BeginInvoke(new Action(() =>
            {
                textBox.Clear();
            }));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            while (true)
            {
                string message = consumer.ReadFromBuffer();

                if (message == null)
                {
                    break;
                }

                messagesTextBox.AppendText(message + Environment.NewLine);
            }
        }
    }
}